using System;
using System.Web.Mvc;
using SHF.ViewModel;

namespace SHF.Web.Models.Error
{
    public class CustomHandleErrorInfo : HandleErrorInfo
    {
        public string DisplayErrorMessage { get; set; }

        public CustomHandleErrorInfo(Exception exception, string controllerName, string actionName)
            : base(exception, controllerName, actionName)
        {
        }
    }
}