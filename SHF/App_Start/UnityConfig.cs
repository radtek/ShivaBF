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
            container.RegisterType<Business.Interface.IServices1Master, Business.BusinessLogic.Services1Master>();
            container.RegisterType<Business.Interface.IServices1Section1Master, Business.BusinessLogic.Services1Section1Master>();
            container.RegisterType<Business.Interface.IServices1Section4Master, Business.BusinessLogic.Services1Section4Master>();
            container.RegisterType<Business.Interface.IServices1Section5Master, Business.BusinessLogic.Services1Section5Master>();
            container.RegisterType<Business.Interface.IServices1Section6PriceMaster, Business.BusinessLogic.Services1Section6PriceMaster>();
            container.RegisterType<Business.Interface.IStateMaster, Business.BusinessLogic.StateMaster>();
            container.RegisterType<Business.Interface.IPriceFeaturesMaster, Business.BusinessLogic.PriceFeaturesMaster>();
            container.RegisterType<Business.Interface.IPriceFeaturesMapping, Business.BusinessLogic.PriceFeaturesMapping>();
            container.RegisterType<Business.Interface.IServices1Section8FAQMapping, Business.BusinessLogic.Services1Section8FAQMapping>();
            container.RegisterType<Business.Interface.IServices1Section10BankMapping, Business.BusinessLogic.Services1Section10BankMapping>();
            container.RegisterType<Business.Interface.IServices2Master, Business.BusinessLogic.Services2Master>();
            container.RegisterType<Business.Interface.IServices2Section2FAQMapping, Business.BusinessLogic.Services2Section2FAQMapping>();
            container.RegisterType<Business.Interface.IServices2Section3DownloadMaster, Business.BusinessLogic.Services2Section3DownloadMaster>();
            container.RegisterType<Business.Interface.IServices2Section4Master, Business.BusinessLogic.Services2Section4Master>();
            container.RegisterType<Business.Interface.IServices3Master, Business.BusinessLogic.Services3Master>();
            container.RegisterType<Business.Interface.IServices3HeadingButtons, Business.BusinessLogic.Services3HeadingButtons>();
            container.RegisterType<Business.Interface.IServices3Section4, Business.BusinessLogic.Services3Section4>();
            container.RegisterType<Business.Interface.IServices3Section6PriceMaster, Business.BusinessLogic.Services3Section6PriceMaster>();
            container.RegisterType<Business.Interface.IServices4Master, Business.BusinessLogic.Services4Master>();
            container.RegisterType<Business.Interface.IServices4Section2FAQMapping, Business.BusinessLogic.Services4Section2FAQMapping>();
            container.RegisterType<Business.Interface.IServices4Section2Master, Business.BusinessLogic.Services4Section2Master>();
            container.RegisterType<Business.Interface.IServices4Section2MasterChild, Business.BusinessLogic.Services4Section2MasterChild>();
            container.RegisterType<Business.Interface.IServices4Section3, Business.BusinessLogic.Services4Section3>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}