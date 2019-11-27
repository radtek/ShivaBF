using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Transactions;
using AutoMapper;
using AutoMapper.EntityFramework;
using AutoMapper.Collection;
using AutoMapper.Collection.LinqToSQL;
using SHF.Helper;
using SHF.Web.Filters;
using SHF.Models;
using SHF.ViewModel;
using System.IO;
using SHF.Helpers;

namespace SHF.Controllers
{
    [AllowAnonymous]
    public class PageViewsReportController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private Business.Interface.IPageViewsReport businessPageViewsReport;

        public PageViewsReportController(Business.Interface.IMessage Imessage, Business.Interface.IPageViewsReport IPageViewsReport)
        {
            this.businessMessage = Imessage;
            this.businessPageViewsReport = IPageViewsReport;

        }
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
        #endregion

        #region [ActionMethod]
        // GET: PageViewsReport Master
        [HttpGet]
        [Access]
        [OutputCache(Duration = busConstant.Settings.Cache.OutputCache.TimeOut.S300)]
        [Route("Configurations/Master/PageViewsReport/Index")]
        [Route("Settings/Master/PageViewsReport/Index")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<long>();
            ViewBag.TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            return View();
        }
        [HttpPost]
        [Route("Post/PageViewsReport/IndexAsync")]
        [ValidateAntiForgeryTokens]
        public async Task<ActionResult> IndexAsync()
        {
            BusinessResultViewModel<ViewModel.PageViewsReportIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        long? tenantId = Request.Form.AllKeys.Contains("tenantId") ? Convert.ToInt64(Request.Form.GetValues("tenantId").FirstOrDefault()) : busConstant.Numbers.Integer.ZERO;
                        tenantId = tenantId > busConstant.Numbers.Integer.ZERO ? tenantId : null;

                        businessResult = this.businessPageViewsReport.Index(Request, tenantId);
                        transaction.Complete();
                    }
                    catch
                    {
                        transaction.Dispose();
                        throw;
                    }
                }

                var response = new { draw = businessResult.Draw, recordsFiltered = businessResult.RecordsFiltered, recordsTotal = businessResult.RecordsTotal, data = businessResult.Data };

                return Json(data: response);
            }
            catch (Exception ex)
            {
                //ExceptionResponse(ex);
                var response = new { draw = Request.Form.GetValues("draw").FirstOrDefault(), recordsFiltered = 0, recordsTotal = 0, data = string.Empty, error = ex.Message };

                return Json(data: response);
            }
            finally
            {
                businessResult = null;
            }


        }


        [HttpPost]
        [Audit]
        [ValidateAntiForgeryTokens]
        [Route("Post/PageViewsReport/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.PageViewsReportCreateOrEditViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationResponse();
                }
                else
                {
                    using (var transaction = new TransactionScope())
                    {
                        try
                        {
                            var PageViewsReportId = businessPageViewsReport.FindBy(PageViewsReport => PageViewsReport.Tenant_ID == model.Tenant_ID && PageViewsReport.ID == model.ID).FirstOrDefault();

                            if (PageViewsReportId.IsNotNull())
                            {
                                transaction.Complete();
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.EXCEPTION,
                                    Title = busConstant.Messages.Title.ERROR,
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    MessageCode = busConstant.Messages.MessageCode.SKU_ALREADY_EXIST,
                                    Message = busConstant.Messages.Type.Responses.ALREADY_EXIST
                                };
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                var entity = new EntityModel.PageViewsReport();

                                entity.Url = model.Url;
                                entity.Count = model.Count;

                                entity.Tenant_ID = model.Tenant_ID;
                                entity.Tenant = null;
                                this.businessPageViewsReport.Create(entity);
                                transaction.Complete();

                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Title = busConstant.Messages.Title.SUCCESS,
                                    Icon = busConstant.Messages.Icon.SUCCESS,
                                    MessageCode = busConstant.Messages.MessageCode.SAVE,
                                    Message = busConstant.Messages.Type.Responses.SAVE
                                };

                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Dispose();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ExceptionResponse(ex);
            }
            finally
            {
                // unitOfWork.Dispose();
            }
        }


        [HttpGet]
        [Route("Get/PageViewsReport/EditAsync")]
        public async Task<ActionResult> EditAsync(long Id)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        if (Id == default(long))
                        {
                            transaction.Complete();
                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.EXCEPTION,
                                Message = busConstant.Messages.Type.Exceptions.BAD_REQUEST,
                            };

                            Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entity = this.businessPageViewsReport.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                var model = new ViewModel.PageViewsReportCreateOrEditViewModel();
                                model.ID = entity.ID;
                                model.Url = entity.Url;
                                model.Count = entity.Count;
                                model.Tenant_ID = Convert.ToInt64(entity.Tenant_ID);

                                var response = new JsonResponse<PageViewsReportCreateOrEditViewModel>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Entity = model
                                };

                                transaction.Complete();
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.EXCEPTION,
                                    Message = busConstant.Messages.Type.Exceptions.NOT_FOUND,
                                };

                                transaction.Complete();
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    catch
                    {
                        transaction.Dispose();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                return ExceptionResponse(ex);
            }
            finally
            {
                //unitOfWork.Dispose();
            }
        }


        [HttpPost]
        [Audit]
        [ValidateAntiForgeryTokens]
        [Route("Post/PageViewsReport/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.PageViewsReportCreateOrEditViewModel model)
        {
            try
            {
                ModelState.Remove("CreatedOn");
                ModelState.Remove("UpdatedOn");
                if (!ModelState.IsValid)
                {
                    return ValidationResponse();
                }
                else
                {
                    using (var transaction = new TransactionScope())
                    {
                        try
                        {
                            var PageViewsReportData = businessPageViewsReport.FindBy(PageViewsReport => PageViewsReport.Tenant_ID == model.Tenant_ID && PageViewsReport.ID == model.ID).FirstOrDefault();

                            if (PageViewsReportData.IsNull())
                            {
                                transaction.Complete();
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.VALIDATION,
                                    Title = busConstant.Messages.Title.ERROR,
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    MessageCode = busConstant.Messages.MessageCode.SKU_ALREADY_EXIST,
                                    Message = busConstant.Messages.Type.Responses.ALREADY_EXIST
                                };
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                var entity = this.businessPageViewsReport.GetById(Convert.ToInt64(model.ID));
                                if (entity.IsNotNull())
                                {

                                    entity.ID = Convert.ToInt64(model.ID);
                                    entity.Url = model.Url;
                                    entity.Count = model.Count;

                                    entity.Tenant_ID = model.Tenant_ID;
                                    entity.Tenant = null;

                                    this.businessPageViewsReport.Update(entity);

                                    transaction.Complete();
                                }
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Title = busConstant.Messages.Title.SUCCESS,
                                    Icon = busConstant.Messages.Icon.SUCCESS,
                                    Message = busConstant.Messages.Type.Responses.SAVE,
                                    MessageCode = busConstant.Messages.MessageCode.SAVE
                                };
                                return Json(response);
                            }

                        }
                        catch
                        {
                            transaction.Dispose();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ExceptionResponse(ex);
            }
            finally
            {
                // unitOfWork.Dispose();
            }
        }
        [HttpGet]
        [Route("Get/PageViewsReport/DropdownListbyTenantAsync")]
        public async Task<ActionResult> GetPageViewsReportByTenantIdAsync(long Id)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        if (Id == 0)
                        {
                            transaction.Complete();
                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.EXCEPTION,
                                Message = busConstant.Messages.Type.Exceptions.BAD_REQUEST,
                                StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest)
                            };

                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entities = this.businessPageViewsReport.GetAll().Where(PageViewsReport => PageViewsReport.Tenant_ID == Id).Select(x => new ViewModel.PageViewsReportDropdownListViewModel
                            {
                                ID = x.ID,
                                Url = x.Url
                            });

                            if (entities.IsNotNull())
                            {
                                var response = new JsonResponse<IEnumerable<ViewModel.PageViewsReportDropdownListViewModel>>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Entity = entities
                                };

                                transaction.Complete();
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.EXCEPTION,
                                    Message = busConstant.Messages.Type.Exceptions.NOT_FOUND,
                                    StatusCode = Convert.ToInt32(HttpStatusCode.NotFound)
                                };
                                transaction.Complete();

                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Dispose();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                return ExceptionResponse(ex);
            }
        }

      
        [HttpPost]
        [Route("POST/PageViewsReport/FileUpload")]
        public virtual string UploadFiles(object obj)
        {
            //  var tenantId = ViewBag.TenantID;
            var length = Request.ContentLength;
            var bytes = new byte[length];
            Request.InputStream.Read(bytes, 0, length);

            var fileName = Request.Headers["X-File-Name"];
            var fileSize = Request.Headers["X-File-Size"];
            var fileType = Request.Headers["X-File-Type"];
            var tenantId = Request.Headers["tenantId"];
            string temppath = Server.MapPath("~/" + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY));
            string path = Server.MapPath("~/" + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, tenantId));
            //string path = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (fileType.Contains("image"))
            {
                var saveToFileLoc = temppath + "/" + fileName;
                // var destToFileLoc = path + "/" + fileName;
                var fileStream = new FileStream(saveToFileLoc, FileMode.Create, FileAccess.ReadWrite);
                fileStream.Write(bytes, 0, length);
                fileStream.Close();
                //Image file compress
                CompressImage.CompressImageMethod(saveToFileLoc, path, 30);
                System.IO.File.Delete(saveToFileLoc);
            }
            else
            {
                var saveToFileLoc = path + "/" + fileName;
                // var destToFileLoc = path + "/" + fileName;
                var fileStream = new FileStream(saveToFileLoc, FileMode.Create, FileAccess.ReadWrite);
                fileStream.Write(bytes, 0, length);
                fileStream.Close();
            }

            return string.Format("{0} bytes uploaded", bytes.Length);
        }


        #endregion

    }
}