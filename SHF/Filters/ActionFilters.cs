using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SHF.Helper;
using SHF.ViewModel;


namespace SHF.Web.Filters
{
    public class AuditAttribute : ActionFilterAttribute, IActionFilter
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var _activityDateTime = System.DateTime.Now;
            var _activityBy = filterContext.HttpContext.Request.IsAuthenticated ? filterContext.HttpContext.User.Identity.Name : busConstant.Misc.SYSTEM;

            filterContext.RequestContext.HttpContext.Session[busConstant.Settings.Session.Keys.ACTIVITY_BY] = _activityBy;
            filterContext.RequestContext.HttpContext.Session[busConstant.Settings.Session.Keys.ACTIVITY_DATETIME] = _activityDateTime;

            //Object modelObject = filterContext.ActionParameters["model"] as Object;

            //SetValuesOfAuditProperty(_activityDateTime, _activityBy, modelObject);

            base.OnActionExecuting(filterContext);
        }

        private void SetValuesOfAuditProperty(DateTime _activityDateTime, int _activityBy, object modelObject)
        {
            if (modelObject.IsNotNull())
            {
                BaseViewModel baseViewModel = modelObject as BaseViewModel;


                if (baseViewModel.IsNotNull() && baseViewModel.ID.GetValueOrDefault() == default(long))
                {
                    PropertyInfo[] properties = modelObject.GetType().GetProperties();

                    foreach (PropertyInfo propInfo in properties)
                    {
                        if (propInfo.PropertyType.Name.Contains("IEnumerable"))
                        {
                            object value = propInfo.GetValue(modelObject);

                            ManualTypeChecking(_activityDateTime, _activityBy, value);

                            Type elementType = Type.GetType(propInfo.DeclaringType.FullName.ToString());
                            var listType = typeof(List<>).MakeGenericType(new Type[] { elementType });
                            var list = Activator.CreateInstance(listType);

                        }
                        else
                        {
                            switch (propInfo.Name)
                            {
                                case busConstant.SwitchCase.BaseViewModel.CREATED_BY:
                                    propInfo.SetValue(modelObject, _activityBy);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.CREATED_ON:
                                    propInfo.SetValue(modelObject, _activityDateTime);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.UPDATED_BY:
                                    propInfo.SetValue(modelObject, _activityBy);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.UPDATED_ON:
                                    propInfo.SetValue(modelObject, _activityDateTime);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.IS_DELETED:
                                    propInfo.SetValue(modelObject, busConstant.Misc.FALSE);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.IS_ACTIVE:
                                    propInfo.SetValue(modelObject, busConstant.Misc.TRUE);
                                    break;

                                default:

                                    break;

                            }
                        }
                    }
                }
                else
                {
                    PropertyInfo[] properties = modelObject.GetType().GetProperties();

                    foreach (PropertyInfo propInfo in properties)
                    {

                        if (propInfo.PropertyType.Name.Contains("IEnumerable"))
                        {
                            object value = propInfo.GetValue(modelObject);

                            ManualTypeChecking(_activityDateTime, _activityBy, value);

                            Type elementType = Type.GetType(propInfo.DeclaringType.FullName.ToString());
                            var listType = typeof(List<>).MakeGenericType(new Type[] { elementType });
                            var list = Activator.CreateInstance(listType);

                        }
                        else
                        {
                            switch (propInfo.Name)
                            {

                                case busConstant.SwitchCase.BaseViewModel.UPDATED_BY:
                                    propInfo.SetValue(modelObject, _activityBy);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.UPDATED_ON:
                                    propInfo.SetValue(modelObject, _activityDateTime);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.IS_DELETED:
                                    propInfo.SetValue(modelObject, busConstant.Misc.FALSE);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.IS_ACTIVE:
                                    propInfo.SetValue(modelObject, busConstant.Misc.TRUE);
                                    break;

                                default:

                                    break;

                            }
                        }
                    }
                }
            }
        }

        private void ManualTypeChecking(DateTime _activityDateTime, int _activityBy, object value)
        {
            //if (value.IsNotNull() && value is System.Collections.Generic.List<SHF.ViewModel.AddToStockItemCreateViewModel>)
            //{
            //    System.Collections.Generic.List<SHF.ViewModel.AddToStockItemCreateViewModel> lclbBaseViewModel = value as System.Collections.Generic.List<SHF.ViewModel.AddToStockItemCreateViewModel>;
            //    foreach (BaseViewModel lbusbaseViewModel in lclbBaseViewModel)
            //    {
            //        Object lbusObject = lbusbaseViewModel as Object;

            //        SetValuesOfAuditProperty(_activityDateTime, _activityBy, lbusObject);
            //    }
            //}
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Session.Remove(busConstant.Settings.Session.Keys.ACTIVITY_BY);
            filterContext.RequestContext.HttpContext.Session.Remove(busConstant.Settings.Session.Keys.ACTIVITY_DATETIME);

            base.OnActionExecuted(filterContext);
        }


    }

    public class AccessAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        private bool hasAccess = busConstant.Misc.FALSE;

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            hasAccess = busConstant.Misc.FALSE;

            if (Business.BusinessLogic.BusinessSubMenu.HasAccess(filterContext.RequestContext.HttpContext.Request.Url.AbsolutePath, filterContext.RequestContext.HttpContext.User.Identity.GetUserId<long>()))
            {
                hasAccess = busConstant.Misc.TRUE;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!hasAccess)
            {
                filterContext.RequestContext.HttpContext.Response.Redirect("/Settings/Security/Account/UnAuthorize-Request", busConstant.Misc.TRUE);
            }
            base.OnActionExecuting(filterContext);
        }
    }

}
