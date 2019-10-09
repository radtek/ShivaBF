using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Dapper;
using SHF.EntityModel;
using SHF.Helper;

namespace SHF.Helpers
{
    public static class HtmlHelpers
    {
        private class ScriptBlock : IDisposable
        {
            private const string ScriptsKey = "PartialViewScripts";
            public static List<string> PartialViewScripts
            {
                get
                {
                    if (HttpContext.Current.Items[ScriptsKey] == null)
                        HttpContext.Current.Items[ScriptsKey] = new List<string>();
                    return (List<string>)HttpContext.Current.Items[ScriptsKey];
                }
            }

            readonly WebViewPage _webPageBase;

            public ScriptBlock(WebViewPage webPageBase)
            {
                _webPageBase = webPageBase;
                _webPageBase.OutputStack.Push(new StringWriter());
            }

            public void Dispose()
            {
                PartialViewScripts.Add(((StringWriter)this._webPageBase.OutputStack.Pop()).ToString());
            }
        }

        public static IDisposable BeginScripts(this HtmlHelper helper)
        {
            return new ScriptBlock((WebViewPage)helper.ViewDataContainer);
        }

        public static MvcHtmlString PartialViewScripts(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(string.Join(Environment.NewLine, ScriptBlock.PartialViewScripts.Select(s => s.ToString())));
        }

        public static IEnumerable<T> ViewData<T>(this HtmlHelper helper, string name)
        {
            if (helper.ViewData[name] != null)
            {
                return (IEnumerable<T>)helper.ViewData[name];
            }
            return new List<T>();
        }

        public static T ViewDataSingle<T>(this HtmlHelper helper, string name)
        {
            if (helper.ViewData[name] != null)
            {
                return (T)helper.ViewData[name];
            }
            return default(T);
        }

        public static string IsActive(this HtmlHelper helper, string action = "", string controller = "", string cssClass = "", string subMenuCssClass = "")
        {
            string returncssclass = string.Empty;
            ViewContext viewContext = helper.ViewContext;
            bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

            if (isChildAction)
                viewContext = helper.ViewContext.ParentActionViewContext;

            RouteValueDictionary routeValues = viewContext.RouteData.Values;
            string currentAction = routeValues["action"].ToString().ToLower();
            string currentController = routeValues["controller"].ToString().ToLower();

            if (string.IsNullOrEmpty(action))
                action = currentAction;

            if (string.IsNullOrEmpty(controller))
                controller = currentController;

            string[] acceptedActions = action.ToLower().Trim().Split(',').Distinct().ToArray();
            string[] acceptedControllers = controller.ToLower().Trim().Split(',').Distinct().ToArray();

            if ((!string.IsNullOrEmpty(cssClass)) && (string.IsNullOrEmpty(subMenuCssClass)))
            {
                returncssclass = acceptedControllers.Contains(currentController.ToLower()) ? cssClass : String.Empty;
            }
            if ((!string.IsNullOrEmpty(subMenuCssClass)) && (string.IsNullOrEmpty(cssClass)))
            {
                string[] subMenuCss = subMenuCssClass.ToLower().Split(' ').Distinct().ToArray();
                returncssclass = acceptedControllers.Contains(currentController.ToLower()) ? subMenuCss[0].ToString() : subMenuCssClass;
            }

            //return returncssclass;

            return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) ? cssClass : String.Empty;
        }

        public static string Amount(this HtmlHelper helper, double? amount)
        {
            string returnAmount = String.Empty;
            returnAmount = amount == null ? "N/A" : Convert.ToDouble(amount).ToString("0.00");
            return returnAmount;
        }

        public static string Name(this HtmlHelper helper, string name = "")
        {
            string returnName = String.Empty;
            returnName = string.IsNullOrEmpty(name) ? "N/A" : name.ToString();
            return returnName;
        }

        public static string Date(this HtmlHelper helper, DateTime? date)
        {
            string returnDate = String.Empty;
            returnDate = date == null ? "N/A" : Convert.ToDateTime(date).ToString("dd MMM yyyy");
            return returnDate;
        }

        public static string Status(this HtmlHelper helper, bool? trueFlag, bool? falseFlag, string status = "")
        {
            string returnStatus = String.Empty;

            if (trueFlag == null && falseFlag == null)
            {
                returnStatus = "N/A";
            }
            else
            {
                if (Convert.ToBoolean(trueFlag))
                {
                    returnStatus = status.ToString();
                }
                if (Convert.ToBoolean(falseFlag))
                {
                    returnStatus = "N/A";
                }
                if (Convert.ToBoolean(trueFlag) && Convert.ToBoolean(falseFlag))
                {
                    returnStatus = status.ToString();
                }
            }

            return returnStatus;
        }

        public static string IsSelected(this HtmlHelper html, string controllers = "", string actions = "", string cssClass = "")
        {
            ViewContext viewContext = html.ViewContext;
            bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

            if (isChildAction)
                viewContext = html.ViewContext.ParentActionViewContext;

            RouteValueDictionary routeValues = viewContext.RouteData.Values;
            string currentAction = routeValues["action"].ToString();
            string currentController = routeValues["controller"].ToString();

            if (actions.IsNull())
                actions = currentAction;

            if (String.IsNullOrEmpty(controllers))
                controllers = currentController;

            string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
            string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();

            return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) ?
                cssClass : String.Empty;
        }

        public static MvcHtmlString Avatar(this HtmlHelper helper, long userId, string cssClass = "", int w = 32, int h = 32)
        {
            string src, fileName;
            if (userId != default(int))
            {
                var p = new DynamicParameters();
                p.Add("@AspNetUserId", userId);
                using (var con = DBUtility.GetNewOpenConnection())
                {
                    fileName = con.ExecuteScalar<string>(sql: "[dbo].[usp_GetAvatarByLoginId]", param: p, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                fileName = "Avatar.png";
            }
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = "Avatar.png";
            }
            src = string.Format("/Media/Uploads/ProfileImages/{0}?w={1}&h={2}", fileName, w, h);
            return new MvcHtmlString(String.Format("<img src=\"{0}\" class=\"{1}\" id=\"avatar_{2}\" alt=\"Avatar-Image\"/>", src, cssClass, userId));
        }

        public static string UserName(this HtmlHelper helper, long userId)
        {
            string name;
            if (userId != default(int))
            {
                var p = new DynamicParameters();
                p.Add("@AspNetUserId", userId);
                using (var con = DBUtility.GetNewOpenConnection())
                {
                    name = con.ExecuteScalar<string>(sql: "[dbo].[uSP_GetUserNameByLoginId]", param: p, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                name = "Guest";
            }
            if (string.IsNullOrEmpty(name))
            {
                name = "Guest";
            }
            return name;
        }


        public static MvcHtmlString GetNavigationMenu(this HtmlHelper helper, long userId, EntityModel.SubMenu subMneu)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                subMneu.SubMenus = Business.BusinessLogic.BusinessSubMenu.GetChildMenuAsync(userId, subMneu.ID);
                if (subMneu.IsNotNull() && subMneu.SubMenus.IsNotNull() && subMneu.SubMenus.Count() > busConstant.Numbers.Integer.ZERO)
                {

                    sb.Append("<a href='#'><i class=" + subMneu.IconClass + "></i><span>" + subMneu.Name + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>");
                    sb.Append("<ul id=ul_sub_" + subMneu.Name.Replace(" ", "_") + " class='treeview-menu'>");

                    GetChildnavigationMenu(subMneu.SubMenus, userId, sb);
                    sb.Append("</ul>");
                }
                else
                {
                    sb.Append("<a href=" + subMneu.Url + "><i class=" + subMneu.IconClass + "></i><span>" + subMneu.Name + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>");
                    //sb.Append("<a href='#/Configurations/Master/Tenant/Index'><i class=" + subMneu.IconClass + "></i><span>" + subMneu.Name + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>");
                }
                return new MvcHtmlString(sb.ToString());
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }


        }

        private static void GetChildnavigationMenu(IEnumerable<SubMenu> subMenus, long userId, StringBuilder sb)
        {
            try
            {
                foreach (var item in subMenus)
                {
                    item.SubMenus = Business.BusinessLogic.BusinessSubMenu.GetChildMenuAsync(userId, item.ID);

                    if (item.IsNotNull() && item.SubMenus.IsNotNull() && item.SubMenus.Count() > busConstant.Numbers.Integer.ZERO)
                    {

                        sb.Append("<li id=li_" + item.Name.Replace(" ", "_") + " class='treeview'>");
                        sb.Append("<a href='#'><i class=" + item.IconClass + "></i><span>" + item.Name + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>");
                        sb.Append("<ul class='treeview-menu'>");
                        GetChildnavigationMenu(item.SubMenus, userId, sb);
                        sb.Append("</ul>");
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("<li id=li_" + item.Name.Replace(" ", "_") + "><a href=" + item.Url + "><i class=" + item.IconClass + "></i>" + item.Name + "</a></li>");
                        //sb.Append("<a href='#/Configurations/Master/Tenant/Index'><i class=" + item.IconClass + "></i><span>" + item.Name + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>");
                    }
                }
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
            }
        }
    }

    public static class ImageHelper
    {
        /// <summary>
        /// Determines if the browser is able to handle Data URIs based on its version.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can browser handle data uris]; otherwise, <c>false</c>.
        /// </returns>
        private static bool CanBrowserHandleDataUris()
        {
            float browserVersion = -1;

            HttpRequest httpRequest = HttpContext.Current.Request;
            HttpBrowserCapabilities browser = httpRequest.Browser;

            if (browser.Browser == "IE")
            {
                browserVersion = (float)(browser.MajorVersion + browser.MinorVersion);
            }

            if (browserVersion > 8 || browserVersion == -1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determine if the size of the file matches the minimum requirements.
        /// The size of the image needs to be less than 32KB.
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        private static bool IsFileSizeCorrect(string imageUrl)
        {
            string imagepath = HttpContext.Current.Server.MapPath(imageUrl);

            // determine the length
            long fileLength = new FileInfo(imagepath).Length;

            return fileLength < 5000 * 1000;
        }


        /// <summary>
        /// Converts the image to base64 string.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <returns></returns>
        private static string ConvertImageToBase64String(string imageUrl)
        {
            string imagepath = HttpContext.Current.Server.MapPath(imageUrl);

            using (Image image = Image.FromFile(imagepath))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Convert Image to byte[]
                    image.Save(memoryStream, image.RawFormat);
                    byte[] imageBytes = memoryStream.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }


        public static MvcHtmlString DrawImage(this HtmlHelper helper, string imageUrl, string alt, string cssClass)
        {
            if (CanBrowserHandleDataUris() & IsFileSizeCorrect(imageUrl))
            {
                // Get the file type
                string fileType = Path.GetExtension(imageUrl);
                if (fileType != null)
                {
                    fileType = fileType.Replace(".", "");
                }

                // Convert the image
                imageUrl = ConvertImageToBase64String(imageUrl);

                return new MvcHtmlString(String.Format("<img  alt=\"{0}\" class=\"{1}\" " +
                                      "src=\"data:image/{2};base64,{3}\" />", alt, cssClass,
                                      fileType, imageUrl));
            }

            return new MvcHtmlString(String.Format("<img class=\"{0}\" src=\"{1}\" alt=\"{2}\"/>", cssClass, imageUrl, alt));
        }
    }




}