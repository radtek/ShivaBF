
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

using SHF.ViewModel.FrontEnd;
using SHF.Web.Filters;

namespace SHF.Controllers.Front
{
   
    public class ServiceType1Controller : ApiController
    {

        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        public ServiceType1Controller()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
        }
        public ServiceType1Controller(SHF.DataAccess.Implementations.UnitOfWork unitOfWork,Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
            this.UnitOfWork = unitOfWork;
            this.businessMessage = Imessage;
            this.businessCategoriesMaster = ICategoriesMaster;
            this.businessSubCategoriesMaster = ISubCategoriesMaster;
            this.businessSubSubCategoriesMaster = ISubSubCategoriesMaster;

        }
        
        //GET: api/GetAllActiveServiceType1ByTenantId? tenantId = 1
       // [EnableCors]
        [Route("api/ServiceType1/GetServiceType1ByTenantIdAndUrl/{tenantId}/{url}")]
        [HttpGet]
        public ServiceType1ViewModel GetServiceType1ByTenantIdAndUrl(string tenantId,string url)
        {
          // string tenantId = "1";
            var ServiceType1ViewModel = new ServiceType1ViewModel();
           var servicetype1 = UnitOfWork.Services1MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
            if (servicetype1!=null)
            {
                ServiceType1ViewModel.ID = servicetype1.ID;
                ServiceType1ViewModel.BannerImagePath = servicetype1.BannerImagePath;
                ServiceType1ViewModel.BannerOnHeading = servicetype1.BannerOnHeading;
                ServiceType1ViewModel.Cat_Id = servicetype1.Cat_Id;
                ServiceType1ViewModel.SubCat_Id = servicetype1.SubCat_Id;
                ServiceType1ViewModel.SubSubCat_Id = servicetype1.SubSubCat_Id;
                ServiceType1ViewModel.SubSubCategoryName = servicetype1.SubSubCategoryName;
                ServiceType1ViewModel.BannerHeadingDescription = servicetype1.BannerHeadingDescription;
                ServiceType1ViewModel.BannerAncharTagTitle = servicetype1.BannerAncharTagTitle;
                ServiceType1ViewModel.BannerAncharTagUrl = servicetype1.BannerAncharTagUrl;
                ServiceType1ViewModel.Section1AfterBannerHeading = servicetype1.Section1AfterBannerHeading;
                ServiceType1ViewModel.Section1AfterBannerDescription = servicetype1.Section1AfterBannerDescription;
                ServiceType1ViewModel.Section1AfterBannerImagePath = servicetype1.Section1AfterBannerImagePath;
                ServiceType1ViewModel.Section1AfterBannerImageOnDescription = servicetype1.Section1AfterBannerImageOnDescription;
                ServiceType1ViewModel.Section2Heading = servicetype1.Section2Heading;
                ServiceType1ViewModel.Section2Description = servicetype1.Section2Description;
                ServiceType1ViewModel.Section3Heading = servicetype1.Section3Heading;
                ServiceType1ViewModel.Section3Description = servicetype1.Section3Description;
                ServiceType1ViewModel.Section3TextboxMaskedText = servicetype1.Section3TextboxMaskedText;
                ServiceType1ViewModel.Section4Heading = servicetype1.Section4Heading;
                ServiceType1ViewModel.Section5Heading = servicetype1.Section5Heading;
                ServiceType1ViewModel.Section6Heading = servicetype1.Section6Heading;
                ServiceType1ViewModel.Section6Description = servicetype1.Section6Description;
                ServiceType1ViewModel.Section7Description = servicetype1.Section7Description;
                ServiceType1ViewModel.Section8Description = servicetype1.Section8Description;
                ServiceType1ViewModel.Section96Heading = servicetype1.Section96Heading;
                ServiceType1ViewModel.Section9Description = servicetype1.Section9Description;
                ServiceType1ViewModel.Section10MappingBankFlag = servicetype1.Section10MappingBankFlag;
                ServiceType1ViewModel.DisplayIndex = servicetype1.DisplayIndex;
                ServiceType1ViewModel.Url = servicetype1.Url.ToString();
                ServiceType1ViewModel.Metadata = servicetype1.Metadata.ToString();
                ServiceType1ViewModel.MetaDescription = servicetype1.MetaDescription.ToString();
                ServiceType1ViewModel.Keyword = servicetype1.Keyword.ToString();
                ServiceType1ViewModel.IsActive = servicetype1.IsActive;
            }
            /*some db operation*/
            // return Json("ajs");
            return ServiceType1ViewModel;
        }

        [Route("api/ServiceType1/GetServiceType1Section1MasterByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<ServiceType1Section1MasterViewModel> GetServiceType1Section1MasterByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstServiceType1Section1MasterViewModel = new List<ServiceType1Section1MasterViewModel>();
            var ServiceType1Section1Master = UnitOfWork.Services1Section1MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x=>x.DisplayIndex);
            foreach (var tempservice1Section1 in ServiceType1Section1Master)
            {
                var serviceType1Section1MasterViewModel = new ServiceType1Section1MasterViewModel();
               serviceType1Section1MasterViewModel.ID = tempservice1Section1.ID;
                serviceType1Section1MasterViewModel.Service_Id = tempservice1Section1.Service_Id;
                serviceType1Section1MasterViewModel.SubSubCat_Id = Convert.ToInt64(tempservice1Section1.SubSubCat_Id);
               //serviceType1Section1MasterViewModel.SubSubCategoryName = tempservice1Section1Services.SubSubCategoryName;
               serviceType1Section1MasterViewModel.AncharTagTitle = tempservice1Section1.AncharTagTitle;
               serviceType1Section1MasterViewModel.AncharTagUrl = tempservice1Section1.AncharTagUrl;
               serviceType1Section1MasterViewModel.DisplayIndex = tempservice1Section1.DisplayIndex;
               serviceType1Section1MasterViewModel.IsActive = tempservice1Section1.IsActive;
               serviceType1Section1MasterViewModel.TotalViews = tempservice1Section1.TotalViews;
               serviceType1Section1MasterViewModel.Url = tempservice1Section1.Url;
               serviceType1Section1MasterViewModel.Metadata = tempservice1Section1.Metadata;
               serviceType1Section1MasterViewModel.Keyword = tempservice1Section1.Keyword;
               serviceType1Section1MasterViewModel.MetaDescription = tempservice1Section1.MetaDescription;
               serviceType1Section1MasterViewModel.Tenant_ID = Convert.ToInt64(tempservice1Section1.Tenant_ID);
                lstServiceType1Section1MasterViewModel.Add(serviceType1Section1MasterViewModel);
            }
            /*some db operation*/
            // return Json("ajs");
            return lstServiceType1Section1MasterViewModel;
        }


        [Route("api/ServiceType1/GetServiceType1Section4MasterByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<ServiceType1Section4MasterViewModel> GetServiceType1Section4MasterByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstServiceType1Section4MasterViewModel = new List<ServiceType1Section4MasterViewModel>();
            var ServiceType1Section4Master = UnitOfWork.Services1Section4MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
            foreach (var tempservice1Section4 in ServiceType1Section4Master)
            {
                var serviceType1Section4MasterViewModel = new ServiceType1Section4MasterViewModel();
                serviceType1Section4MasterViewModel.ID = tempservice1Section4.ID;
                serviceType1Section4MasterViewModel.Service_Id = tempservice1Section4.Service_Id;
                serviceType1Section4MasterViewModel.SubSubCat_Id = Convert.ToInt64(tempservice1Section4.SubSubCat_Id);
                serviceType1Section4MasterViewModel.HeadingText = tempservice1Section4.HeadingText;
                serviceType1Section4MasterViewModel.ShortDescription = tempservice1Section4.ShortDescription;
                serviceType1Section4MasterViewModel.AncharTagTitle = tempservice1Section4.AncharTagTitle;
                serviceType1Section4MasterViewModel.AncharTagUrl = tempservice1Section4.AncharTagUrl;
                serviceType1Section4MasterViewModel.DisplayIndex = tempservice1Section4.DisplayIndex;
                serviceType1Section4MasterViewModel.IsActive = tempservice1Section4.IsActive;
                serviceType1Section4MasterViewModel.TotalViews = tempservice1Section4.TotalViews;
                serviceType1Section4MasterViewModel.Url = tempservice1Section4.Url;
                serviceType1Section4MasterViewModel.Metadata = tempservice1Section4.Metadata;
                serviceType1Section4MasterViewModel.Keyword = tempservice1Section4.Keyword;
                serviceType1Section4MasterViewModel.MetaDescription = tempservice1Section4.MetaDescription;
                serviceType1Section4MasterViewModel.Tenant_ID = Convert.ToInt64(tempservice1Section4.Tenant_ID);
                lstServiceType1Section4MasterViewModel.Add(serviceType1Section4MasterViewModel);
            }
            /*some db operation*/
            // return Json("ajs");
            return lstServiceType1Section4MasterViewModel;
        }


        [Route("api/ServiceType1/GetServiceType1Section5MasterByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<ServiceType1Section5MasterViewModel> GetServiceType1Section5MasterByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstServiceType1Section5MasterViewModel = new List<ServiceType1Section5MasterViewModel>();
            var ServiceType1Section5Master = UnitOfWork.Services1Section5MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
            foreach (var tempservice1Section5 in ServiceType1Section5Master)
            {
                var serviceType1Section5MasterViewModel = new ServiceType1Section5MasterViewModel();
                serviceType1Section5MasterViewModel.ID = tempservice1Section5.ID;
                serviceType1Section5MasterViewModel.Service_Id = tempservice1Section5.Service_Id;
                serviceType1Section5MasterViewModel.SubSubCat_Id = Convert.ToInt64(tempservice1Section5.SubSubCat_Id);
                serviceType1Section5MasterViewModel.HeadingText = tempservice1Section5.HeadingText;
                serviceType1Section5MasterViewModel.ShortDescription = tempservice1Section5.ShortDescription;
                serviceType1Section5MasterViewModel.AncharTagTitle = tempservice1Section5.AncharTagTitle;
                serviceType1Section5MasterViewModel.AncharTagUrl = tempservice1Section5.AncharTagUrl;
                serviceType1Section5MasterViewModel.DisplayIndex = tempservice1Section5.DisplayIndex;
                serviceType1Section5MasterViewModel.IsActive = tempservice1Section5.IsActive;
                serviceType1Section5MasterViewModel.TotalViews = tempservice1Section5.TotalViews;
                serviceType1Section5MasterViewModel.Url = tempservice1Section5.Url;
                serviceType1Section5MasterViewModel.Metadata = tempservice1Section5.Metadata;
                serviceType1Section5MasterViewModel.Keyword = tempservice1Section5.Keyword;
                serviceType1Section5MasterViewModel.MetaDescription = tempservice1Section5.MetaDescription;
                serviceType1Section5MasterViewModel.Tenant_ID = Convert.ToInt64(tempservice1Section5.Tenant_ID);
                lstServiceType1Section5MasterViewModel.Add(serviceType1Section5MasterViewModel);
            }
            /*some db operation*/
            // return Json("ajs");
            return lstServiceType1Section5MasterViewModel;
        }


        [Route("api/ServiceType1/GetServiceType1Section6PriceMasterByTenantIdAndServiceId/{tenantId}/{Id}/{StateFullName}")]
        [HttpGet]
        public List<Services1Section6PriceMasterViewModel> GetServiceType1Section6PriceMasterByTenantIdAndServiceId(string tenantId, string Id,string StateFullName)
        {
            // string tenantId = "1";
            var lstServices1Section6PriceMasterViewModel = new List<Services1Section6PriceMasterViewModel>();
            var state = UnitOfWork.StateMasterRepository.Get().Where(x => x.StateFullName == StateFullName).FirstOrDefault();
            if (state != null)
            {
                var Services1Section6PriceMaster = UnitOfWork.Services1Section6PriceMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true && x.State_Id == state.ID).OrderBy(x => x.DisplayIndex);

                foreach (var tempservices1Section6PriceMaster in Services1Section6PriceMaster)
                {
                    var services1Section6PriceMasterViewModel = new Services1Section6PriceMasterViewModel();
                    services1Section6PriceMasterViewModel.ID = tempservices1Section6PriceMaster.ID;
                    services1Section6PriceMasterViewModel.SubSubCat_Id = Convert.ToInt64(tempservices1Section6PriceMaster.SubSubCat_Id);
                    services1Section6PriceMasterViewModel.HeadingText = tempservices1Section6PriceMaster.HeadingText;
                    services1Section6PriceMasterViewModel.Price = tempservices1Section6PriceMaster.Price;
                    services1Section6PriceMasterViewModel.AncharTagTitle = tempservices1Section6PriceMaster.AncharTagTitle;
                    services1Section6PriceMasterViewModel.AncharTagUrl = tempservices1Section6PriceMaster.AncharTagUrl;
                    services1Section6PriceMasterViewModel.DisplayIndex = tempservices1Section6PriceMaster.DisplayIndex;
                    services1Section6PriceMasterViewModel.IsActive = tempservices1Section6PriceMaster.IsActive;
                    services1Section6PriceMasterViewModel.TotalViews = tempservices1Section6PriceMaster.TotalViews;
                    services1Section6PriceMasterViewModel.Url = tempservices1Section6PriceMaster.Url;
                    services1Section6PriceMasterViewModel.Metadata = tempservices1Section6PriceMaster.Metadata;
                    services1Section6PriceMasterViewModel.Keyword = tempservices1Section6PriceMaster.Keyword;
                    services1Section6PriceMasterViewModel.MetaDescription = tempservices1Section6PriceMaster.MetaDescription;
                    services1Section6PriceMasterViewModel.Tenant_ID = Convert.ToInt64(tempservices1Section6PriceMaster.Tenant_ID);

                    var objPriceFeaturesMapping = UnitOfWork.PriceFeaturesMappingRepository.Get().Join(UnitOfWork.TenantRepository.Get(), PriceFeaturesMapping => PriceFeaturesMapping.Tenant_ID, tenant => tenant.ID, (PriceFeaturesMapping, tenant) => new { PriceFeaturesMapping, tenant })
                    .Join(UnitOfWork.PriceFeaturesMasterRepository.Get(), PriceFeaturesMapping_tenant => PriceFeaturesMapping_tenant.PriceFeaturesMapping.PriceFeaturesMaster_Id, PriceFeaturesMaster => PriceFeaturesMaster.ID, (PriceFeaturesMapping_tenant, PriceFeaturesMaster) => new { PriceFeaturesMapping_tenant, PriceFeaturesMaster })
                    .Where(x => x.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Tenant_ID == Convert.ToInt64(tenantId) && x.PriceFeaturesMapping_tenant.PriceFeaturesMapping.IsActive == true && x.PriceFeaturesMapping_tenant.PriceFeaturesMapping.S1S6PM_Id == Convert.ToInt64(Id)).OrderBy(a => a.PriceFeaturesMapping_tenant.PriceFeaturesMapping.DisplayIndex);
                    var lstpriceFeaturesMappingViewModel = new List<PriceFeaturesMappingViewModel>();

                    foreach (var tempPriceFeaturesMapping in objPriceFeaturesMapping)
                    {
                        var priceFeaturesMappingViewModel = new PriceFeaturesMappingViewModel();
                        priceFeaturesMappingViewModel.S1S6PM_Id = tempPriceFeaturesMapping.PriceFeaturesMapping_tenant.PriceFeaturesMapping.S1S6PM_Id;
                        priceFeaturesMappingViewModel.Service_Id = tempPriceFeaturesMapping.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Service_Id;
                        priceFeaturesMappingViewModel.SubSubCat_Id = Convert.ToInt64(tempPriceFeaturesMapping.PriceFeaturesMapping_tenant.PriceFeaturesMapping.SubSubCat_Id);
                        priceFeaturesMappingViewModel.PriceFeaturesMaster_Id = tempPriceFeaturesMapping.PriceFeaturesMapping_tenant.PriceFeaturesMapping.PriceFeaturesMaster_Id;
                        priceFeaturesMappingViewModel.Description = tempPriceFeaturesMapping.PriceFeaturesMaster.Description;
                        priceFeaturesMappingViewModel.DisplayIndex = tempPriceFeaturesMapping.PriceFeaturesMapping_tenant.PriceFeaturesMapping.DisplayIndex;
                        priceFeaturesMappingViewModel.IsActive = tempPriceFeaturesMapping.PriceFeaturesMapping_tenant.PriceFeaturesMapping.IsActive;
                        priceFeaturesMappingViewModel.TotalViews = tempPriceFeaturesMapping.PriceFeaturesMapping_tenant.PriceFeaturesMapping.TotalViews;
                        priceFeaturesMappingViewModel.Url = tempPriceFeaturesMapping.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Url;
                        priceFeaturesMappingViewModel.Metadata = tempPriceFeaturesMapping.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Metadata;
                        priceFeaturesMappingViewModel.Keyword = tempPriceFeaturesMapping.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Keyword;
                        priceFeaturesMappingViewModel.MetaDescription = tempPriceFeaturesMapping.PriceFeaturesMapping_tenant.PriceFeaturesMapping.MetaDescription;
                        priceFeaturesMappingViewModel.Tenant_ID = Convert.ToInt64(tempPriceFeaturesMapping.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Tenant_ID);
                        lstpriceFeaturesMappingViewModel.Add(priceFeaturesMappingViewModel);
                    }
                    services1Section6PriceMasterViewModel.PriceFeaturesMappingViewModel = lstpriceFeaturesMappingViewModel;
                    lstServices1Section6PriceMasterViewModel.Add(services1Section6PriceMasterViewModel);
                }
            }
            /*some db operation*/
            // return Json("ajs");
            return lstServices1Section6PriceMasterViewModel;
        }


        [Route("api/ServiceType1/GetServiceType1Section8FAQMappingByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<Services1Section8FAQMappingViewModel> GetServiceType1Section8FAQMappingByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstservices1Section8FAQMappingViewModel = new List<Services1Section8FAQMappingViewModel>();
            var services1Section8FAQMapping = UnitOfWork.Services1Section8FAQMappingRepository.Get().Join(UnitOfWork.TenantRepository.Get(), Services1Section8FAQMapping => Services1Section8FAQMapping.Tenant_ID, tenant => tenant.ID, (Services1Section8FAQMapping, tenant) => new { Services1Section8FAQMapping, tenant })
                    .Join(UnitOfWork.FAQMasterRepository.Get(), Services1Section8FAQMapping_tenant => Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.FAQMaster_Id, FAQMaster => FAQMaster.ID, (Services1Section8FAQMapping_tenant, FAQMaster) => new { Services1Section8FAQMapping_tenant, FAQMaster })
                    .Where(x => x.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Tenant_ID == Convert.ToInt64(tenantId) && x.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Service_Id == Convert.ToInt64(Id) && x.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.IsActive == true)
                    .OrderBy(x => x.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.DisplayIndex);
            if (services1Section8FAQMapping != null)
            {
                foreach (var tempservices1Section8FAQMapping in services1Section8FAQMapping)
                {
                    var services1Section8FAQMappingViewModel = new Services1Section8FAQMappingViewModel();
                    services1Section8FAQMappingViewModel.ID = tempservices1Section8FAQMapping.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.ID;
                    services1Section8FAQMappingViewModel.FAQMaster_Id = Convert.ToInt64(tempservices1Section8FAQMapping.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.FAQMaster_Id);
                    services1Section8FAQMappingViewModel.Service_Id = tempservices1Section8FAQMapping.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Service_Id;
                    services1Section8FAQMappingViewModel.SubSubCat_Id = Convert.ToInt64(tempservices1Section8FAQMapping.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.SubSubCat_Id);
                    services1Section8FAQMappingViewModel.Title = tempservices1Section8FAQMapping.FAQMaster.Title;
                    services1Section8FAQMappingViewModel.Description = tempservices1Section8FAQMapping.FAQMaster.Description;
                    services1Section8FAQMappingViewModel.DisplayIndex = tempservices1Section8FAQMapping.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.DisplayIndex;
                    services1Section8FAQMappingViewModel.IsActive = tempservices1Section8FAQMapping.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.IsActive;
                    services1Section8FAQMappingViewModel.TotalViews = tempservices1Section8FAQMapping.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.TotalViews;
                    services1Section8FAQMappingViewModel.Url = tempservices1Section8FAQMapping.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Url;
                    services1Section8FAQMappingViewModel.Metadata = tempservices1Section8FAQMapping.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Metadata;
                    services1Section8FAQMappingViewModel.Keyword = tempservices1Section8FAQMapping.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Keyword;
                    services1Section8FAQMappingViewModel.MetaDescription = tempservices1Section8FAQMapping.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.MetaDescription;
                    services1Section8FAQMappingViewModel.Tenant_ID = Convert.ToInt64(tempservices1Section8FAQMapping.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Tenant_ID);
                    lstservices1Section8FAQMappingViewModel.Add(services1Section8FAQMappingViewModel);
                }
            }
            /*some db operation*/
            // return Json("ajs");
            return lstservices1Section8FAQMappingViewModel;
        }
        #endregion
    }

}