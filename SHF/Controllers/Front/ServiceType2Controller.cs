
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using SHF.Helper;
using SHF.ViewModel.FrontEnd;
using SHF.Web.Filters;

namespace SHF.Controllers.Front
{
   
    public class ServiceType2Controller : ApiController
    {

        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        public ServiceType2Controller()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
        }
        public ServiceType2Controller(SHF.DataAccess.Implementations.UnitOfWork unitOfWork,Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
            this.UnitOfWork = unitOfWork;
            this.businessMessage = Imessage;
            this.businessCategoriesMaster = ICategoriesMaster;
            this.businessSubCategoriesMaster = ISubCategoriesMaster;
            this.businessSubSubCategoriesMaster = ISubSubCategoriesMaster;

        }
        
        //GET: api/GetAllActiveServiceType2ByTenantId? tenantId = 1
       // [EnableCors]
        [Route("api/ServiceType2/GetServiceType2ByTenantIdAndUrl/{tenantId}/{url}")]
        [HttpGet]
        public ServiceType2ViewModel GetServiceType2ByTenantIdAndUrl(string tenantId,string url)
        {
          // string tenantId = "1";
            var ServiceType2ViewModel = new ServiceType2ViewModel();
           var ServiceType2 = UnitOfWork.Services2MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
            if (ServiceType2!=null)
            {
                ServiceType2ViewModel.ID = ServiceType2.ID;
                ServiceType2ViewModel.BannerImagePath = ServiceType2.BannerImagePath;
                ServiceType2ViewModel.BannerOnHeading = ServiceType2.BannerOnHeading;
                ServiceType2ViewModel.Cat_Id = ServiceType2.Cat_Id;
                ServiceType2ViewModel.SubCat_Id = ServiceType2.SubCat_Id;
                ServiceType2ViewModel.SubSubCat_Id = ServiceType2.SubSubCat_Id;
                ServiceType2ViewModel.SubSubCategoryName = ServiceType2.SubSubCategoryName;
                ServiceType2ViewModel.BannerHeadingDescription = ServiceType2.BannerHeadingDescription;
                ServiceType2ViewModel.BannerOnHeading = ServiceType2.BannerOnHeading;
                ServiceType2ViewModel.Section1Description = ServiceType2.Section1Description;
                ServiceType2ViewModel.Section2FAQDescription = ServiceType2.Section2FAQDescription;
                ServiceType2ViewModel.Section3DownloadDescription = ServiceType2.Section3DownloadDescription;
                ServiceType2ViewModel.Section4PriceingHeading = ServiceType2.Section4PriceingHeading;
                ServiceType2ViewModel.Section4PriceingDescription = ServiceType2.Section4PriceingDescription;
                ServiceType2ViewModel.DisplayIndex = ServiceType2.DisplayIndex;
                ServiceType2ViewModel.Url = ServiceType2.Url.ToString();
                ServiceType2ViewModel.Metadata = ServiceType2.Metadata.ToString();
                ServiceType2ViewModel.MetaDescription = ServiceType2.MetaDescription.ToString();
                ServiceType2ViewModel.Keyword = ServiceType2.Keyword.ToString();
                ServiceType2ViewModel.IsActive = ServiceType2.IsActive;
                ServiceType2ViewModel.TotalViews = ServiceType2.TotalViews;
                ServiceType2ViewModel.Tenant_ID = Convert.ToInt64(ServiceType2.Tenant_ID);
                ServiceType2ViewModel.CreatedBy = ServiceType2.CreatedBy;
                ServiceType2ViewModel.UpdatedBy = ServiceType2.UpdatedBy;
                ServiceType2ViewModel.CreatedOn = ServiceType2.CreatedOn;
                ServiceType2ViewModel.UpdatedOn = ServiceType2.UpdatedOn;
            }
            /*some db operation*/
            // return Json("ajs");
            return ServiceType2ViewModel;
        }

        [Route("api/ServiceType2/GetServiceType2Section3DownloadMasterByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<Services2Section3DownloadMasterViewModel> GetServiceType2Section3DownloadMasterByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstservices2Section3DownloadMasterViewModel = new List<Services2Section3DownloadMasterViewModel>();
            var ServiceType23DownloadMaster = UnitOfWork.Services2Section3DownloadMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x=>x.DisplayIndex);
            foreach (var tempserviceType23DownloadMaster in ServiceType23DownloadMaster)
            {
                var services2Section3DownloadMasterViewModel = new Services2Section3DownloadMasterViewModel();
                services2Section3DownloadMasterViewModel.ID = tempserviceType23DownloadMaster.ID;
                services2Section3DownloadMasterViewModel.SubSubCat_Id = Convert.ToInt64(tempserviceType23DownloadMaster.SubSubCat_Id);
                services2Section3DownloadMasterViewModel.AncharTagTitle = tempserviceType23DownloadMaster.AncharTagTitle;
                services2Section3DownloadMasterViewModel.AncharTagUrl = tempserviceType23DownloadMaster.AncharTagUrl;
                services2Section3DownloadMasterViewModel.DownloadFilePath = tempserviceType23DownloadMaster.DownloadFilePath;
                services2Section3DownloadMasterViewModel.DisplayIndex = tempserviceType23DownloadMaster.DisplayIndex;
                services2Section3DownloadMasterViewModel.IsActive = tempserviceType23DownloadMaster.IsActive;
                services2Section3DownloadMasterViewModel.TotalViews = tempserviceType23DownloadMaster.TotalViews;
                services2Section3DownloadMasterViewModel.Url = tempserviceType23DownloadMaster.Url;
                services2Section3DownloadMasterViewModel.Metadata = tempserviceType23DownloadMaster.Metadata;
                services2Section3DownloadMasterViewModel.Keyword = tempserviceType23DownloadMaster.Keyword;
                services2Section3DownloadMasterViewModel.MetaDescription = tempserviceType23DownloadMaster.MetaDescription;
                services2Section3DownloadMasterViewModel.Tenant_ID = Convert.ToInt64(tempserviceType23DownloadMaster.Tenant_ID);
                lstservices2Section3DownloadMasterViewModel.Add(services2Section3DownloadMasterViewModel);
            }
            /*some db operation*/
            // return Json("ajs");
            return lstservices2Section3DownloadMasterViewModel;
        }


        [Route("api/ServiceType2/GetServiceType2Section4MasterByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<Services2Section4MasterViewModel> GetServiceType2Section4MasterByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstServiceType2Section4MasterViewModel = new List<Services2Section4MasterViewModel>();
            var ServiceType2Section4Master = UnitOfWork.Services2Section4MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
            foreach (var tempservice2Section4 in ServiceType2Section4Master)
            {
                var ServiceType2Section4MasterViewModel = new Services2Section4MasterViewModel();
                ServiceType2Section4MasterViewModel.ID = tempservice2Section4.ID;
                ServiceType2Section4MasterViewModel.SubSubCat_Id = Convert.ToInt64(tempservice2Section4.SubSubCat_Id);
                ServiceType2Section4MasterViewModel.AncharTagTitle = tempservice2Section4.AncharTagTitle;
                ServiceType2Section4MasterViewModel.AncharTagUrl = tempservice2Section4.AncharTagUrl;
                ServiceType2Section4MasterViewModel.HeadingText = tempservice2Section4.Heading;
                ServiceType2Section4MasterViewModel.Price = tempservice2Section4.Price;
                ServiceType2Section4MasterViewModel.DisplayIndex = tempservice2Section4.DisplayIndex;
                ServiceType2Section4MasterViewModel.IsActive = tempservice2Section4.IsActive;
                ServiceType2Section4MasterViewModel.TotalViews = tempservice2Section4.TotalViews;
                ServiceType2Section4MasterViewModel.Url = tempservice2Section4.Url;
                ServiceType2Section4MasterViewModel.Metadata = tempservice2Section4.Metadata;
                ServiceType2Section4MasterViewModel.Keyword = tempservice2Section4.Keyword;
                ServiceType2Section4MasterViewModel.MetaDescription = tempservice2Section4.MetaDescription;
                ServiceType2Section4MasterViewModel.Tenant_ID = Convert.ToInt64(tempservice2Section4.Tenant_ID);
                lstServiceType2Section4MasterViewModel.Add(ServiceType2Section4MasterViewModel);
            }
            /*some db operation*/
            // return Json("ajs");
            return lstServiceType2Section4MasterViewModel;
        }
        
        [Route("api/ServiceType2/GetServiceType2Section2FAQMappingByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<Services2Section2FAQMappingViewModel> GetServiceType2Section2FAQMappingByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstServices2Section2FAQMappingViewModel = new List<Services2Section2FAQMappingViewModel>();
            var Services2Section2FAQMapping = UnitOfWork.Services2Section2FAQMappingRepository.Get().Join(UnitOfWork.TenantRepository.Get(), services2Section2FAQMapping => services2Section2FAQMapping.Tenant_ID, tenant => tenant.ID, (services2Section2FAQMapping, tenant) => new { services2Section2FAQMapping, tenant })
                    .Join(UnitOfWork.FAQMasterRepository.Get(), Services2Section2FAQMapping_tenant => Services2Section2FAQMapping_tenant.services2Section2FAQMapping.FAQMaster_Id, FAQMaster => FAQMaster.ID, (Services2Section2FAQMapping_tenant, FAQMaster) => new { Services2Section2FAQMapping_tenant, FAQMaster })
                    .Where(x => x.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.Tenant_ID == Convert.ToInt64(tenantId) && x.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.Service_Id == Convert.ToInt64(Id) && x.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.IsActive == true)
                    .OrderBy(x => x.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.DisplayIndex);
            if (Services2Section2FAQMapping != null)
            {
                foreach (var tempServices2Section2FAQMapping in Services2Section2FAQMapping)
                {
                    var Services2Section2FAQMappingViewModel = new Services2Section2FAQMappingViewModel();
                    Services2Section2FAQMappingViewModel.ID = tempServices2Section2FAQMapping.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.ID;
                    Services2Section2FAQMappingViewModel.FAQMaster_Id = Convert.ToInt64(tempServices2Section2FAQMapping.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.FAQMaster_Id);
                    Services2Section2FAQMappingViewModel.Service_Id = tempServices2Section2FAQMapping.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.Service_Id;
                    Services2Section2FAQMappingViewModel.SubSubCat_Id = Convert.ToInt64(tempServices2Section2FAQMapping.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.SubSubCat_Id);
                    Services2Section2FAQMappingViewModel.Title = tempServices2Section2FAQMapping.FAQMaster.Title;
                    Services2Section2FAQMappingViewModel.Description = tempServices2Section2FAQMapping.FAQMaster.Description;
                    Services2Section2FAQMappingViewModel.DisplayIndex = tempServices2Section2FAQMapping.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.DisplayIndex;
                    Services2Section2FAQMappingViewModel.IsActive = tempServices2Section2FAQMapping.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.IsActive;
                    Services2Section2FAQMappingViewModel.TotalViews = tempServices2Section2FAQMapping.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.TotalViews;
                    Services2Section2FAQMappingViewModel.Url = tempServices2Section2FAQMapping.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.Url;
                    Services2Section2FAQMappingViewModel.Metadata = tempServices2Section2FAQMapping.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.Metadata;
                    Services2Section2FAQMappingViewModel.Keyword = tempServices2Section2FAQMapping.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.Keyword;
                    Services2Section2FAQMappingViewModel.MetaDescription = tempServices2Section2FAQMapping.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.MetaDescription;
                    Services2Section2FAQMappingViewModel.Tenant_ID = Convert.ToInt64(tempServices2Section2FAQMapping.Services2Section2FAQMapping_tenant.services2Section2FAQMapping.Tenant_ID);
                    lstServices2Section2FAQMappingViewModel.Add(Services2Section2FAQMappingViewModel);
                }
            }
            /*some db operation*/
            // return Json("ajs");
            return lstServices2Section2FAQMappingViewModel;
        }


        #endregion
    }

}