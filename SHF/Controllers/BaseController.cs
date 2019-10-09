using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Transactions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Specialized;
using SHF.Helper;
using SHF.ViewModel;
using SHF.EntityModel;
using SHF.Helpers;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing;
using System.Drawing.Text;
using SHF.Web.Filters;
using System.Drawing.Imaging;

namespace SHF.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        #region [Fields and Constructor]



        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        protected DateTime _activityDateTime;
        protected System.String _activityBy = busConstant.Misc.SYSTEM;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public BaseController()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
            _activityDateTime = DateTime.Now;
            if (Request.IsNotNull() && Request.IsAuthenticated)
            {
                _activityBy = User.Identity.GetUserName();
            }
        }

        public BaseController(SHF.DataAccess.Implementations.UnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        #endregion

        #region [Action Methods]

        [HttpGet]
        protected ActionResult ValidationResponse(JsonRequestBehavior jsonRequestBehaviour = JsonRequestBehavior.AllowGet)
        {
            if (ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            var validationMessages = new List<JsonValidationError>();
            var validationSummary = new List<string>();
            foreach (var key in ModelState.Keys)
            {
                ModelState modelState = null;
                if (ModelState.TryGetValue(key, out modelState))
                {
                    foreach (var error in modelState.Errors)
                    {
                        validationMessages.Add(new JsonValidationError()
                        {
                            Key = key,
                            Message = error.ErrorMessage
                        });
                    }
                }

            }

            validationSummary = ModelState.Keys.SelectMany(k => ModelState[k].Errors).DistinctBy(k => k.ErrorMessage)
                            .Select(m => m.ErrorMessage).ToList();


            var response = new JsonResponse<dynamic>()
            {
                Type = busConstant.Messages.Type.VALIDATION,
                Message = "",
                Errors = validationMessages,
                ValidationSummary = validationSummary
            };

            Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
            return Json(response, jsonRequestBehaviour);
        }

        [HttpGet]
        protected ActionResult ExceptionResponse(Exception ex, int exNumber = -1, JsonRequestBehavior jsonRequestBehaviour = JsonRequestBehavior.AllowGet)
        {
            var e = new List<JsonValidationError>();

            e.Add(new JsonValidationError { Key = "Message", Message = ex.Message });
            e.Add(new JsonValidationError { Key = "InnerMessage", Message = (ex.InnerException.IsNotNull() && ex.InnerException.Message.IsNotNullOrEmpty()) ? ex.InnerException.Message : String.Empty });
            e.Add(new JsonValidationError { Key = "StackTrace", Message = ex.StackTrace });
            e.Add(new JsonValidationError { Key = "TargetSiteName", Message = ex.TargetSite.Name });
            e.Add(new JsonValidationError { Key = "HResult", Message = ex.HResult.ToString() });
            e.Add(new JsonValidationError { Key = "Source", Message = ex.Source });
            e.Add(new JsonValidationError { Key = "HelpLink", Message = ex.HelpLink });
            e.Add(new JsonValidationError { Key = "DataKeys", Message = String.Join(",", ex.Data.Keys) });
            e.Add(new JsonValidationError { Key = "DataValues", Message = String.Join(",", ex.Data.Values) });

            var response = new JsonResponse<dynamic>();

            switch (exNumber)
            {
                case 2601:
                    response.Type = busConstant.Messages.Type.EXCEPTION;
                    response.Title = busConstant.Messages.Title.ERROR;
                    response.Icon = busConstant.Messages.Icon.ERROR;
                    if (ex.Message.Contains("IX_TaxDisplayNameAndTenantId"))
                    {
                        response.Message = busConstant.Messages.Type.Exceptions.IX_TaxDisplayNameAndTenantId;
                    }
                    if (ex.Message.Contains("IX_VendorIDProductIDTenantID"))
                    {
                        response.Message = busConstant.Messages.Type.Exceptions.IX_VendorIDProductIDTenantID;
                    }
                    if (ex.Message.Contains("IX_Message_Code"))
                    {
                        response.Message = busConstant.Messages.Type.Exceptions.IX_Message_Code;
                    }

                    response.Errors = e;
                    break;


                default:
                    response.Type = busConstant.Messages.Type.EXCEPTION;
                    response.Title = busConstant.Messages.Title.ERROR;
                    response.Message = busConstant.Messages.Type.Exceptions.INTERNAL_SERVER_ERROR;
                    response.Icon = busConstant.Messages.Icon.ERROR;
                    response.Errors = e;
                    break;
            }



            //Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            return Json(response, jsonRequestBehaviour);
        }

        [HttpGet]
        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }


        protected async Task Impersonate(string userName)
        {
            await ImpersonateUserAsync(userName);
            var user = await UserManager.FindByEmailAsync(userName);
        }


        protected async Task EndImpersonate()
        {
            await RevertImpersonationAsync();
        }


        #endregion


        #region [Private Methods]

        private async Task ImpersonateUserAsync(string userName)
        {
            var context = HttpContext.GetOwinContext();

            var originalUsername = User.Identity.Name;

            var impersonatedUser = await UserManager.FindByNameAsync(userName);

            var impersonatedIdentity = await UserManager.CreateIdentityAsync(impersonatedUser, DefaultAuthenticationTypes.ApplicationCookie);
            impersonatedIdentity.AddClaim(new Claim(busConstant.Misc.USER_IMPERSONATION, busConstant.Misc.FLAG_TRUE));
            impersonatedIdentity.AddClaim(new Claim(busConstant.Misc.ORIGINAL_USER_NAME, originalUsername));

            var authenticationManager = context.Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, impersonatedIdentity);
        }

        private async Task RevertImpersonationAsync()
        {
            if (!ClaimsPrincipal.Current.IsImpersonating())
            {
                throw new Exception("Unable to remove impersonation because there is no impersonation");
            }

            var context = HttpContext.GetOwinContext();
            var originalUsername = ClaimsPrincipal.Current.GetOriginalUsername();

            var originalUser = await UserManager.FindByNameAsync(originalUsername);

            var impersonatedIdentity = await UserManager.CreateIdentityAsync(originalUser, DefaultAuthenticationTypes.ApplicationCookie);
            var authenticationManager = context.Authentication;

            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, impersonatedIdentity);
        }

        #endregion




        #region [Protected Methods]

        protected void SaveCookieAsync()
        {
            HttpCookie cookie;
            NameValueCollection nameValueColletion;
            var userId = User.Identity.GetUserId<long>();
            var user = UserManager.FindById(userId);

            if (Request.Cookies[busConstant.Settings.Cookie.Name.DELMON_SOLUTIONS] != null)
            {
                cookie = Request.Cookies[busConstant.Settings.Cookie.Name.DELMON_SOLUTIONS];
                if (cookie.HasKeys)
                {
                    nameValueColletion = cookie.Values;
                    if (cookie.Values[busConstant.Settings.Cookie.SubKeys.TENANT_ID] != null)
                    {
                        cookie.Values[busConstant.Settings.Cookie.SubKeys.TENANT_ID] = null;
                    }
                    else
                    {
                        cookie.Values[busConstant.Settings.Cookie.SubKeys.TENANT_ID] = user.Tenant_ID.ToString();
                    }
                    if (cookie.Values[busConstant.Settings.Cookie.SubKeys.ROLE_NAME] != null)
                    {
                        cookie.Values[busConstant.Settings.Cookie.SubKeys.ROLE_NAME] = null;
                    }
                    else
                    {
                        cookie.Values[busConstant.Settings.Cookie.SubKeys.ROLE_NAME] = user.UserName;
                    }

                }
                else
                {
                    cookie.Values[busConstant.Settings.Cookie.SubKeys.TENANT_ID] = user.Tenant_ID.GetValueOrDefault().ToString();
                    cookie.Values[busConstant.Settings.Cookie.SubKeys.ROLE_NAME] = user.UserName;
                }


            }
            else
            {
                cookie = new HttpCookie(busConstant.Settings.Cookie.Name.DELMON_SOLUTIONS);
                cookie.Values[busConstant.Settings.Cookie.SubKeys.TENANT_ID] = user.Tenant_ID.GetValueOrDefault().ToString();
                cookie.Values[busConstant.Settings.Cookie.SubKeys.ROLE_NAME] = user.UserName;
            }
            //cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
        }

        protected void DeleteCookieAsync()
        {
            HttpCookie cookie;
            if (Request.Cookies[busConstant.Settings.Cookie.Name.DELMON_SOLUTIONS] != null)
            {
                cookie = Request.Cookies[busConstant.Settings.Cookie.Name.DELMON_SOLUTIONS];
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            Request.Cookies.Clear();
        }

        protected async Task ExistsCookieAsync()
        {
            HttpCookie aCookie = new HttpCookie(busConstant.Settings.Cookie.Name.DELMON_SOLUTIONS);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<long>());
            aCookie.Values[busConstant.Settings.Cookie.SubKeys.TENANT_ID] = user.Tenant_ID.ToString();
            //aCookie.Values[busConstant.Settings.Cookie.SubKeys.BranchID] = user.Branch_ID.ToString();
            aCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(aCookie);
        }

        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected bool HasAccess()
        {
            try
            {
                return Business.BusinessLogic.BusinessSubMenu.HasAccess(Request.Url.AbsolutePath, User.Identity.GetUserId<long>());
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /* comment as part of New BarcodeLib
        protected System.IO.MemoryStream GetBarcodeImage(int imageHeight, int imageWidth, bool bIncludeLabel, string strData, string EncodeType, string Forecolor, string Backcolor, string strImageFormat, string strAlignment)
        {
            System.IO.MemoryStream MemStream = new System.IO.MemoryStream();

            //if (Request.QueryString["d"] != null)
            //{
            //Read in the parameters
            //string strData = Request.QueryString["d"];
            //int imageHeight = Convert.ToInt32(Request.QueryString["h"]);
            //int imageWidth = Convert.ToInt32(Request.QueryString["w"]);
            //string Forecolor = Request.QueryString["fc"];
            //string Backcolor = Request.QueryString["bc"];
            //bool bIncludeLabel = Request.QueryString["il"].ToLower().Trim() == "true";
            //string strImageFormat = Request.QueryString["if"].ToLower().Trim();
            //string strAlignment = Request.QueryString["align"].ToLower().Trim();
            //Request.QueryString["t"].Trim()

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            switch (EncodeType)
            {
                case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
                case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
                case "UPC 2 Digit Ext": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
                case "UPC 5 Digit Ext": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
                case "EAN-13": type = BarcodeLib.TYPE.EAN13; break;
                case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
                case "EAN-8": type = BarcodeLib.TYPE.EAN8; break;
                case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
                case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
                case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
                case "Bookland-ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
                case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
                case "Code 39": type = BarcodeLib.TYPE.CODE39; break;
                case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
                case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
                case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
                case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
                case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
                case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
                case "Code 128": type = BarcodeLib.TYPE.CODE128; break;
                case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
                case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
                case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
                case "Telepen": type = BarcodeLib.TYPE.TELEPEN; break;
                case "FIM (Facing Identification Mark)": type = BarcodeLib.TYPE.FIM; break;
                case "Pharmacode": type = BarcodeLib.TYPE.PHARMACODE; break;
                default: break;
            }//switch

            System.Drawing.Image barcodeImage = null;
            try
            {
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {
                    b.IncludeLabel = bIncludeLabel;

                    //alignment
                    switch (strAlignment.ToLower().Trim())
                    {
                        case "c":
                            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
                            break;
                        case "r":
                            b.Alignment = BarcodeLib.AlignmentPositions.RIGHT;
                            break;
                        case "l":
                            b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
                            break;
                        default:
                            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
                            break;
                    }//switch

                    if (Forecolor.Trim() == "" && Forecolor.Trim().Length != 6)
                        Forecolor = "000000";
                    if (Backcolor.Trim() == "" && Backcolor.Trim().Length != 6)
                        Backcolor = "FFFFFF";

                    //===== Encoding performed here =====
                    barcodeImage = b.Encode(type, strData.Trim(), System.Drawing.ColorTranslator.FromHtml("#" + Forecolor), System.Drawing.ColorTranslator.FromHtml("#" + Backcolor), imageWidth, imageHeight);
                    //===================================

                    //===== Static Encoding performed here =====
                    //barcodeImage = BarcodeLib.Barcode.DoEncode(type, this.txtData.Text.Trim(), this.chkGenerateLabel.Checked, this.btnForeColor.BackColor, this.btnBackColor.BackColor);
                    //==========================================

                    //Response.ContentType = "image/" + strImageFormat;


                    switch (strImageFormat)
                    {
                        case "gif": barcodeImage.Save(MemStream, ImageFormat.Gif); break;
                        case "jpeg": barcodeImage.Save(MemStream, ImageFormat.Jpeg); break;
                        case "png": barcodeImage.Save(MemStream, ImageFormat.Png); break;
                        case "bmp": barcodeImage.Save(MemStream, ImageFormat.Bmp); break;
                        case "tiff": barcodeImage.Save(MemStream, ImageFormat.Tiff); break;
                        default: break;
                    }//switch

                    // MemStream.WriteTo(Response.OutputStream);   

                }//if

                return MemStream;

            }//try
            catch (Exception ex)
            {
                return MemStream;
                //TODO: find a way to return this to display the encoding error message
            }//catch
            finally
            {
                if (barcodeImage != null)
                {
                    //Clean up / Dispose...
                    barcodeImage.Dispose();
                }
            }//finally
            //}//if
            //return MemStream;
        }

        */


        //public virtual void HandleException(Exception exception)
        //{
        //    if (exception is DbUpdateConcurrencyException concurrencyEx)
        //    {
        //        // A custom exception of yours for concurrency issues
        //        throw new DBConcurrencyException();
        //    }
        //    else if (exception is DbUpdateException dbUpdateEx)
        //    {
        //        if (dbUpdateEx.InnerException != null
        //                && dbUpdateEx.InnerException.InnerException != null)
        //        {
        //            if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
        //            {
        //                switch (sqlException.Number)
        //                {
        //                    case 2627:  // Unique constraint error
        //                    case 547:   // Constraint check violation
        //                    case 2601:  // Duplicated key row error
        //                                // Constraint violation exception
        //                                // A custom exception of yours for concurrency issues
        //                        throw new DBConcurrencyException();
        //                    default:
        //                        // A custom exception of yours for other DB issues
        //                        //throw new DatabaseAccessException(
        //                        //  dbUpdateEx.Message, dbUpdateEx.InnerException);
        //                        throw exception;
        //                        break;
        //                }
        //            }

        //            throw new DatabaseAccessException(dbUpdateEx.Message, dbUpdateEx.InnerException);
        //        }
        //    }

        //    // If we're here then no exception has been thrown
        //    // So add another piece of code below for other exceptions not yet handled...
        //}


        /// <summary>
        /// https://www.codeproject.com/Questions/694097/How-to-Generate-a-Bar-Code-for-Items-and-Print-usi
        /// </summary>
        /// <param name="parameters"></param>
        public void printBarcodes(dynamic parameters = null)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                // Set the printer name. 
                //pd.PrinterSettings.PrinterName = "file://ns5/hpoffice";
                //pd.PrinterSettings.PrinterName = "Zebra New GK420t"               
                pd.Print();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            // Create a private font collection
            PrivateFontCollection pfc = new PrivateFontCollection();

            // Load in the temporary barcode font
            //pfc.AddFontFile("c:\\barcodefont\\free3of9.ttf");
            //var Path_IDAutomationHC39M = Server.MapPath("~/fonts/IDAutomationHC39M.ttf");
            //var Path_code128 = Server.MapPath("~/fonts/code128.ttf");


            pfc.AddFontFile(Server.MapPath("~/fonts/fre3of9x.ttf"));
            pfc.AddFontFile(Server.MapPath("~/fonts/free3of9.ttf"));


            pfc.AddFontFile(Server.MapPath("~/fonts/code128.ttf"));
            pfc.AddFontFile(Server.MapPath("~/fonts/IDAutomationHC39M.ttf"));

            //pfc.AddFontFile("C:\\Users\\Vikram\\Source\\Repos\\SHFwebapp2\\SHF\\fonts\\free3of9.ttf");

            // Select the font family to use
            var families = pfc.Families;

            FontFamily family_Code128 = new FontFamily("Code 128", pfc);
            FontFamily family_Free3of9 = new FontFamily("Free 3 of 9", pfc);
            FontFamily family_Free3of9Extended = new FontFamily("Free 3 of 9 Extended", pfc);
            FontFamily family_IDAutomationHC39M = new FontFamily("IDAutomationHC39M", pfc);
            // Create the font object with size 30
            Font f128 = new Font(family_Code128, 30);
            Font f3of9 = new Font(family_Free3of9, 30);
            Font f3of9ex = new Font(family_Free3of9Extended, 30);
            Font f39m = new Font(family_IDAutomationHC39M, 30);

            //With this easy way, you get a font object mapp


            //Font printFont = new Font("3 of 9 Barcode", 17);
            //Font printFont1 = new Font("IDAutomationHC39M", 20, FontStyle.Bold);


            //IDAutomation.NetAssembly.FontEncoder FontEncoder = new IDAutomation.NetAssembly.FontEncoder();
            //var name = FontEncoder.Code128("vikram");
            //Font oFont = new Font("IDAutomationC128L", 12, FontStyle.Regular);


            SolidBrush br = new SolidBrush(Color.Black);
            ev.Graphics.DrawString("", f128, br, 10, 65);
            ev.Graphics.DrawString("*pawar*", f128, br, 10, 65);
            ev.Graphics.DrawString("", f128, br, 10, 65);
            ev.Graphics.DrawString("*pawar*", f3of9, br, 10, 65);
            ev.Graphics.DrawString("", f128, br, 10, 65);
            ev.Graphics.DrawString("*pawar*", f3of9ex, br, 10, 65);
            ev.Graphics.DrawString("", f128, br, 10, 65);
            ev.Graphics.DrawString("*pawar*", f39m, br, 10, 85);
            ev.Graphics.DrawString("", f128, br, 10, 65);
        }


        #endregion
    }
}