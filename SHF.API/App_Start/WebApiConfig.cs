﻿using SHF.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Unity;

namespace SHF.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //var container = new UnityContainer();
            //container.RegisterType<Business.Interface.ITenant, Business.BusinessLogic.Tenant>();
            //container.RegisterType<Business.Interface.ITenant, Business.BusinessLogic.Tenant>();
            //container.RegisterType<Business.Interface.IAspNetRole, Business.BusinessLogic.AspNetRole>();
            //container.RegisterType<Business.Interface.IAspNetUser, Business.BusinessLogic.AspNetUser>();
            //container.RegisterType<Business.Interface.IAspNetUserRole, Business.BusinessLogic.AspNetUserRole>();
            //container.RegisterType<Business.Interface.ISubMenu, Business.BusinessLogic.SubMenu>();
            //container.RegisterType<Business.Interface.IAspNetRoleSubMenu, Business.BusinessLogic.AspNetRoleSubMenu>();

            //container.RegisterType<Business.Interface.ICode, Business.BusinessLogic.CodeValue>();
            //container.RegisterType<Business.Interface.ICodeValue, Business.BusinessLogic.CodeValue>();

            //container.RegisterType<Business.Interface.IMessage, Business.BusinessLogic.Message>();
            //container.RegisterType<Business.Interface.IBankMaster, Business.BusinessLogic.BankMaster>();
            //container.RegisterType<Business.Interface.ICategoriesMaster, Business.BusinessLogic.CategoriesMaster>();
            //container.RegisterType<Business.Interface.ISubCategoriesMaster, Business.BusinessLogic.SubCategoriesMaster>();
            //container.RegisterType<Business.Interface.ISubSubCategoriesMaster, Business.BusinessLogic.SubSubCategoriesMaster>();
            //container.RegisterType<Business.Interface.IFAQMaster, Business.BusinessLogic.FAQMaster>();
            //container.RegisterType<Business.Interface.IServices1Master, Business.BusinessLogic.Services1Master>();
            //container.RegisterType<Business.Interface.IServices1Section1Master, Business.BusinessLogic.Services1Section1Master>();
            //container.RegisterType<Business.Interface.IServices1Section4Master, Business.BusinessLogic.Services1Section4Master>();
            //container.RegisterType<Business.Interface.IServices1Section5Master, Business.BusinessLogic.Services1Section5Master>();
            //container.RegisterType<Business.Interface.IServices1Section6PriceMaster, Business.BusinessLogic.Services1Section6PriceMaster>();
            //container.RegisterType<Business.Interface.IStateMaster, Business.BusinessLogic.StateMaster>();
            //container.RegisterType<Business.Interface.IPriceFeaturesMaster, Business.BusinessLogic.PriceFeaturesMaster>();
            //container.RegisterType<Business.Interface.IPriceFeaturesMapping, Business.BusinessLogic.PriceFeaturesMapping>();
            //container.RegisterType<Business.Interface.IServices1Section8FAQMapping, Business.BusinessLogic.Services1Section8FAQMapping>();
            //container.RegisterType<Business.Interface.IServices1Section10BankMapping, Business.BusinessLogic.Services1Section10BankMapping>();
            //container.RegisterType<Business.Interface.IServices2Master, Business.BusinessLogic.Services2Master>();
            //container.RegisterType<Business.Interface.IServices2Section2FAQMapping, Business.BusinessLogic.Services2Section2FAQMapping>();
            //container.RegisterType<Business.Interface.IServices2Section3DownloadMaster, Business.BusinessLogic.Services2Section3DownloadMaster>();
            //container.RegisterType<Business.Interface.IServices2Section4Master, Business.BusinessLogic.Services2Section4Master>();
            //container.RegisterType<Business.Interface.IServices3Master, Business.BusinessLogic.Services3Master>();
            //container.RegisterType<Business.Interface.IServices3HeadingButtons, Business.BusinessLogic.Services3HeadingButtons>();
            //container.RegisterType<Business.Interface.IServices3Section4, Business.BusinessLogic.Services3Section4>();
            //container.RegisterType<Business.Interface.IServices3Section6PriceMaster, Business.BusinessLogic.Services3Section6PriceMaster>();
            //container.RegisterType<Business.Interface.IServices4Master, Business.BusinessLogic.Services4Master>();
            //container.RegisterType<Business.Interface.IServices4Section2FAQMapping, Business.BusinessLogic.Services4Section2FAQMapping>();
            //container.RegisterType<Business.Interface.IServices4Section2Master, Business.BusinessLogic.Services4Section2Master>();
            //container.RegisterType<Business.Interface.IServices4Section2MasterChild, Business.BusinessLogic.Services4Section2MasterChild>();
            //container.RegisterType<Business.Interface.IServices4Section3, Business.BusinessLogic.Services4Section3>();
            //container.RegisterType<Business.Interface.IServices4Section3DownloadMaster, Business.BusinessLogic.Services4Section3DownloadMaster>();
            //container.RegisterType<Business.Interface.IServices4Section567FieldMaster, Business.BusinessLogic.Services4Section567FieldMaster>();
            //container.RegisterType<Business.Interface.IServices4Section567FieldValues, Business.BusinessLogic.Services4Section567FieldValues>();
            //container.RegisterType<Business.Interface.IServices5Master, Business.BusinessLogic.Services5Master>();
            //container.RegisterType<Business.Interface.IServices5Section2Master, Business.BusinessLogic.Services5Section2Master>();
            //container.RegisterType<Business.Interface.IServices5Section2MasterFeaturesDetails, Business.BusinessLogic.Services5Section2MasterFeaturesDetails>();
            //container.RegisterType<Business.Interface.IServices6Master, Business.BusinessLogic.Services6Master>();
            //container.RegisterType<Business.Interface.IServices6Section2Master, Business.BusinessLogic.Services6Section2Master>();
            //container.RegisterType<Business.Interface.IServices6Section2MasterFeaturesDetails, Business.BusinessLogic.Services6Section2MasterFeaturesDetails>();
            //container.RegisterType<Business.Interface.IServices7Master, Business.BusinessLogic.Services7Master>();
            //container.RegisterType<Business.Interface.IServices7HeadingButtons, Business.BusinessLogic.Services7HeadingButtons>();
            //container.RegisterType<Business.Interface.IServices7Section6PriceMaster, Business.BusinessLogic.Services7Section6PriceMaster>();
            //container.RegisterType<Business.Interface.IServices7Section4, Business.BusinessLogic.Services7Section4>();
            //container.RegisterType<Business.Interface.IServices8Master, Business.BusinessLogic.Services8Master>();
            //container.RegisterType<Business.Interface.IServices8HeadingButtons, Business.BusinessLogic.Services8HeadingButtons>();
            //container.RegisterType<Business.Interface.IServices8Section6Master, Business.BusinessLogic.Services8Section6Master>();
            //container.RegisterType<Business.Interface.IBlogMaster, Business.BusinessLogic.BlogMaster>();
            //container.RegisterType<Business.Interface.IBannerNavigationsDetails, Business.BusinessLogic.BannerNavigationsDetails>();
            //container.RegisterType<Business.Interface.IRelatedBlogsMapping, Business.BusinessLogic.RelatedBlogsMapping>();

            //config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();
            // Web API routes
          

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
