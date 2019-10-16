using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Unity.Injection;
using SHF.Controllers;


namespace SHF
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<Business.Interface.ITenant, Business.BusinessLogic.Tenant>();
            container.RegisterType<Business.Interface.IAspNetRole, Business.BusinessLogic.AspNetRole>();
            container.RegisterType<Business.Interface.IAspNetUser, Business.BusinessLogic.AspNetUser>();
            container.RegisterType<Business.Interface.IAspNetUserRole, Business.BusinessLogic.AspNetUserRole>();
            container.RegisterType<Business.Interface.ISubMenu, Business.BusinessLogic.SubMenu>();
            container.RegisterType<Business.Interface.IAspNetRoleSubMenu, Business.BusinessLogic.AspNetRoleSubMenu>();
            
            container.RegisterType<Business.Interface.ICode, Business.BusinessLogic.CodeValue>();
            container.RegisterType<Business.Interface.ICodeValue, Business.BusinessLogic.CodeValue>();
            
            container.RegisterType<Business.Interface.IMessage, Business.BusinessLogic.Message>();
            container.RegisterType<Business.Interface.IBankMaster, Business.BusinessLogic.BankMaster>();
            container.RegisterType<Business.Interface.ICategoriesMaster, Business.BusinessLogic.CategoriesMaster>();
            container.RegisterType<Business.Interface.ISubCategoriesMaster, Business.BusinessLogic.SubCategoriesMaster>();
            container.RegisterType<Business.Interface.ISubSubCategoriesMaster, Business.BusinessLogic.SubSubCategoriesMaster>();
            container.RegisterType<Business.Interface.IFAQMaster, Business.BusinessLogic.FAQMaster>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}