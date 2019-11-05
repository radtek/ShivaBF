
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using SHF.Helper;
using SHF.ViewModel.FrontEnd;
using SHF.Web.Filters;

namespace SHF.Controllers.Front
{
   
    public class ServiceType7Controller : ApiController
    {

        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        public ServiceType7Controller()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
        }
        public ServiceType7Controller(SHF.DataAccess.Implementations.UnitOfWork unitOfWork,Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
            this.UnitOfWork = unitOfWork;
            this.businessMessage = Imessage;
            this.businessCategoriesMaster = ICategoriesMaster;
            this.businessSubCategoriesMaster = ISubCategoriesMaster;
            this.businessSubSubCategoriesMaster = ISubSubCategoriesMaster;

        }
        
        //GET: api/GetAllActiveServiceType7ByTenantId? tenantId = 1
       // [EnableCors]
        [Route("api/ServiceType7/GetServiceType7ByTenantIdAndUrl/{tenantId}/{url}")]
        [HttpGet]
        public ServiceType7ViewModel GetServiceType7ByTenantIdAndUrl(string tenantId,string url)
        {
          // string tenantId = "1";
            var ServiceType7ViewModel = new ServiceType7ViewModel();
           var ServiceType7 = UnitOfWork.Services7MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
            if (ServiceType7!=null)
            {
                ServiceType7ViewModel.ID = ServiceType7.ID;
                ServiceType7ViewModel.BannerImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, ServiceType7.Tenant_ID) + "/" + ServiceType7.BannerImagePath;
                ServiceType7ViewModel.BannerOnHeading = ServiceType7.BannerOnHeading;
                ServiceType7ViewModel.Cat_Id = ServiceType7.Cat_Id;
                ServiceType7ViewModel.SubCat_Id = ServiceType7.SubCat_Id;
                ServiceType7ViewModel.SubSubCat_Id = ServiceType7.SubSubCat_Id;
                ServiceType7ViewModel.SubSubCategoryName = ServiceType7.SubSubCategoryName;
                ServiceType7ViewModel.BannerHeadingDescription = ServiceType7.BannerHeadingDescription;
                ServiceType7ViewModel.BannerOnHeading = ServiceType7.BannerOnHeading;
                ServiceType7ViewModel.Section1Description = ServiceType7.Section1Description;
                ServiceType7ViewModel.Section1Heading = ServiceType7.Section1Heading;
                ServiceType7ViewModel.Section4Heading = ServiceType7.Section4Heading;
                ServiceType7ViewModel.Section5Heading = ServiceType7.Section5Heading;
                ServiceType7ViewModel.Section5Description = ServiceType7.Section5Description;
                ServiceType7ViewModel.Section5TextboxMaskedText = ServiceType7.Section5TextboxMaskedText;
                ServiceType7ViewModel.Section6PriceingHeading = ServiceType7.Section6PriceingHeading;
                ServiceType7ViewModel.Section6PriceingDescription = ServiceType7.Section6PriceingDescription;
                ServiceType7ViewModel.DisplayIndex = ServiceType7.DisplayIndex;
                ServiceType7ViewModel.Url = ServiceType7.Url.ToString();
                ServiceType7ViewModel.Metadata = ServiceType7.Metadata.ToString();
                ServiceType7ViewModel.MetaDescription = ServiceType7.MetaDescription.ToString();
                ServiceType7ViewModel.Keyword = ServiceType7.Keyword.ToString();
                ServiceType7ViewModel.IsActive = ServiceType7.IsActive;
                ServiceType7ViewModel.TotalViews = ServiceType7.TotalViews;
                ServiceType7ViewModel.Tenant_ID = Convert.ToInt64(ServiceType7.Tenant_ID);
                ServiceType7ViewModel.CreatedBy = ServiceType7.CreatedBy;
                ServiceType7ViewModel.UpdatedBy = ServiceType7.UpdatedBy;
                ServiceType7ViewModel.CreatedOn = ServiceType7.CreatedOn;
                ServiceType7ViewModel.UpdatedOn = ServiceType7.UpdatedOn;
            }
            /*some db operation*/
            // return Json("ajs");
            return ServiceType7ViewModel;
        }

        [Route("api/ServiceType7/GetServiceType7Section4ByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<ServiceType7Section4ViewModel> GetServiceType7Section4ByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstServiceType7Section4ViewModel = new List<ServiceType7Section4ViewModel>();
            var ServiceType7Section4 = UnitOfWork.Services7Section4Repository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true ).OrderBy(x => x.DisplayIndex);
                foreach (var tempServiceType7Section4 in ServiceType7Section4)
                {
                    var ServiceType7Section4ViewModel = new ServiceType7Section4ViewModel();
                    ServiceType7Section4ViewModel.Heading = tempServiceType7Section4.Heading;
                    ServiceType7Section4ViewModel.ShortDescription = tempServiceType7Section4.ShortDescription;
                    ServiceType7Section4ViewModel.AncharTagTitle = tempServiceType7Section4.AncharTagTitle;
                    ServiceType7Section4ViewModel.AncharTagUrl = tempServiceType7Section4.AncharTagUrl;
                    ServiceType7Section4ViewModel.DisplayIndex = tempServiceType7Section4.DisplayIndex;
                    ServiceType7Section4ViewModel.IsActive = tempServiceType7Section4.IsActive;
                    ServiceType7Section4ViewModel.TotalViews = tempServiceType7Section4.TotalViews;
                    ServiceType7Section4ViewModel.Url = tempServiceType7Section4.Url;
                    ServiceType7Section4ViewModel.Metadata = tempServiceType7Section4.Metadata;
                    ServiceType7Section4ViewModel.Keyword = tempServiceType7Section4.Keyword;
                    ServiceType7Section4ViewModel.MetaDescription = tempServiceType7Section4.MetaDescription;
                    ServiceType7Section4ViewModel.Tenant_ID = Convert.ToInt64(tempServiceType7Section4.Tenant_ID);
                    lstServiceType7Section4ViewModel.Add(ServiceType7Section4ViewModel);
                }
            
            /*some db operation*/
            // return Json("ajs");
            return lstServiceType7Section4ViewModel;
        }

        [Route("api/ServiceType7/GetServiceType7Section6PriceMasterByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<ServiceType7Section6PriceMasterViewModel> GeServiceType7Section6PriceMasterByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstServiceType7Section6PriceMasterViewModel = new List<ServiceType7Section6PriceMasterViewModel>();
            var ServiceType7Section6PriceMaster = UnitOfWork.Services7Section6PriceMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true ).OrderBy(x => x.DisplayIndex);
                foreach (var tempServiceType7Section6PriceMaster in ServiceType7Section6PriceMaster)
                {
                    var ServiceType7Section6PriceMasterViewModel = new ServiceType7Section6PriceMasterViewModel();
                ServiceType7Section6PriceMasterViewModel.ID = tempServiceType7Section6PriceMaster.ID;
                ServiceType7Section6PriceMasterViewModel.SubSubCat_Id = Convert.ToInt64(tempServiceType7Section6PriceMaster.SubSubCat_Id);
                ServiceType7Section6PriceMasterViewModel.HeadingText = tempServiceType7Section6PriceMaster.HeadingText;
                ServiceType7Section6PriceMasterViewModel.Price = tempServiceType7Section6PriceMaster.Price;
                ServiceType7Section6PriceMasterViewModel.AncharTagTitle = tempServiceType7Section6PriceMaster.AncharTagTitle;
                ServiceType7Section6PriceMasterViewModel.AncharTagUrl = tempServiceType7Section6PriceMaster.AncharTagUrl;
                ServiceType7Section6PriceMasterViewModel.DisplayIndex = tempServiceType7Section6PriceMaster.DisplayIndex;
                ServiceType7Section6PriceMasterViewModel.IsActive = tempServiceType7Section6PriceMaster.IsActive;
                ServiceType7Section6PriceMasterViewModel.TotalViews = tempServiceType7Section6PriceMaster.TotalViews;
                ServiceType7Section6PriceMasterViewModel.Url = tempServiceType7Section6PriceMaster.Url;
                ServiceType7Section6PriceMasterViewModel.Metadata = tempServiceType7Section6PriceMaster.Metadata;
                ServiceType7Section6PriceMasterViewModel.Keyword = tempServiceType7Section6PriceMaster.Keyword;
                ServiceType7Section6PriceMasterViewModel.MetaDescription = tempServiceType7Section6PriceMaster.MetaDescription;
                ServiceType7Section6PriceMasterViewModel.Tenant_ID = Convert.ToInt64(tempServiceType7Section6PriceMaster.Tenant_ID);
                lstServiceType7Section6PriceMasterViewModel.Add(ServiceType7Section6PriceMasterViewModel);
                }
            
            /*some db operation*/
            // return Json("ajs");
            return lstServiceType7Section6PriceMasterViewModel;
        }


        [Route("api/ServiceType7/GeServiceType7HeadingButtonsByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<ServicesType3HeadingButtonsViewModel> GeServiceType7HeadingButtonsByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstservicesType3HeadingButtonsViewModel = new List<ServicesType3HeadingButtonsViewModel>();
              var ServiceType7HeadingButtons = UnitOfWork.Services7HeadingButtonsRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true ).OrderBy(x => x.DisplayIndex);
                foreach (var tempServiceType7HeadingButtons in ServiceType7HeadingButtons)
                {
                    var servicesType3HeadingButtonsViewModel = new ServicesType3HeadingButtonsViewModel();
                servicesType3HeadingButtonsViewModel.SubSubCat_Id = Convert.ToInt64(tempServiceType7HeadingButtons.SubSubCat_Id);
                servicesType3HeadingButtonsViewModel.AncharTagTitle = tempServiceType7HeadingButtons.AncharTagTitle;
                servicesType3HeadingButtonsViewModel.AncharTagUrl = tempServiceType7HeadingButtons.AncharTagUrl;
                servicesType3HeadingButtonsViewModel.DisplayIndex = tempServiceType7HeadingButtons.DisplayIndex;
                servicesType3HeadingButtonsViewModel.IsActive = tempServiceType7HeadingButtons.IsActive;
                servicesType3HeadingButtonsViewModel.TotalViews = tempServiceType7HeadingButtons.TotalViews;
                servicesType3HeadingButtonsViewModel.Url = tempServiceType7HeadingButtons.Url;
                servicesType3HeadingButtonsViewModel.Metadata = tempServiceType7HeadingButtons.Metadata;
                servicesType3HeadingButtonsViewModel.Keyword = tempServiceType7HeadingButtons.Keyword;
                servicesType3HeadingButtonsViewModel.MetaDescription = tempServiceType7HeadingButtons.MetaDescription;
                servicesType3HeadingButtonsViewModel.Tenant_ID = Convert.ToInt64(tempServiceType7HeadingButtons.Tenant_ID);
                lstservicesType3HeadingButtonsViewModel.Add(servicesType3HeadingButtonsViewModel);
                }
            
            /*some db operation*/
            // return Json("ajs");
            return lstservicesType3HeadingButtonsViewModel;
        }
        #endregion
    }

}