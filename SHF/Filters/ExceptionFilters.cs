using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
//using Microsoft.AspNet.Identity;
using SHF.EntityModel;
using SHF.DataAccess;
using SHF.DataAccess.Implementations;
using SHF.Helper;


namespace SHF.Web.Filters
{
    public class ExceptionFilters : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var _activityDateTime = System.DateTime.Now;
            var _activityBy = busConstant.Numbers.Integer.ONE; //filterContext.HttpContext.User.Identity.IsAuthenticated ? filterContext.HttpContext.User.Identity.GetUserName() : busConstant.Misc.SYSTEM;

            var entity = new ExceptionLog();
            entity.Message = filterContext.Exception.Message;
            if (filterContext.Exception.InnerException.IsNotNull())
            {
                entity.InnerException = filterContext.Exception.InnerException.Message;
            }
            entity.Source = filterContext.Exception.Source;
            entity.StackTrace = filterContext.Exception.StackTrace;
            entity.TargetSite = filterContext.Exception.TargetSite.Name;
            entity.HResult = filterContext.Exception.HResult;
            entity.HelpLink = filterContext.Exception.HelpLink;
            entity.ControllerName = filterContext.RequestContext.RouteData.Values["controller"].ToString();
            entity.ActionName = filterContext.RequestContext.RouteData.Values["action"].ToString();
            entity.Url = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri.ToString();
            entity.CreatedOn = _activityDateTime;
            entity.CreatedBy = _activityBy.ToString();
            entity.UpdatedOn = _activityDateTime;
            entity.UpdatedBy = _activityBy.ToString();
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.ExceptionLogRepository.Insert(entity);
        }
    }
}