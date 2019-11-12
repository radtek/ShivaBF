
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
   
    public class ServiceType4Controller : ApiController
    {

        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        public ServiceType4Controller()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
        }
        public ServiceType4Controller(SHF.DataAccess.Implementations.UnitOfWork unitOfWork,Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
            this.UnitOfWork = unitOfWork;
            this.businessMessage = Imessage;
            this.businessCategoriesMaster = ICategoriesMaster;
            this.businessSubCategoriesMaster = ISubCategoriesMaster;
            this.businessSubSubCategoriesMaster = ISubSubCategoriesMaster;

        }
        
        //GET: api/GetAllActiveServiceType4ByTenantId? tenantId = 1
       // [EnableCors]
        [Route("api/ServiceType4/GetServiceType4ByTenantIdAndUrl/{tenantId}/{url}")]
        [HttpGet]
        public ServiceType4ViewModel GetServiceType4ByTenantIdAndUrl(string tenantId,string url)
        {
          // string tenantId = "1";
            var ServiceType4ViewModel = new ServiceType4ViewModel();
           var ServiceType4 = UnitOfWork.Services4MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
            if (ServiceType4!=null)
            {
                ServiceType4ViewModel.ID = ServiceType4.ID;
                ServiceType4ViewModel.BannerImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, ServiceType4.Tenant_ID) + "/" + ServiceType4.BannerImagePath;
                ServiceType4ViewModel.BannerOnHeading = ServiceType4.BannerOnHeading;
                ServiceType4ViewModel.Cat_Id = ServiceType4.Cat_Id;
                ServiceType4ViewModel.SubCat_Id = ServiceType4.SubCat_Id;
                ServiceType4ViewModel.SubSubCat_Id = ServiceType4.SubSubCat_Id;
                ServiceType4ViewModel.SubSubCategoryName = ServiceType4.SubSubCategoryName;
                ServiceType4ViewModel.BannerHeadingDescription = ServiceType4.BannerHeadingDescription;
                ServiceType4ViewModel.BannerOnHeading = ServiceType4.BannerOnHeading;
                ServiceType4ViewModel.Section1Description = ServiceType4.Section1Description;
                ServiceType4ViewModel.Section2PriceingHeading = ServiceType4.Section2PriceingHeading;
                ServiceType4ViewModel.Section2PriceingDescription = ServiceType4.Section2PriceingDescription;
                ServiceType4ViewModel.Section3PriceingHeading = ServiceType4.Section3PriceingHeading;
                ServiceType4ViewModel.Section3PriceingDescription = ServiceType4.Section3PriceingDescription;
                ServiceType4ViewModel.Section4PriceingHeading = ServiceType4.Section4PriceingHeading;
                ServiceType4ViewModel.Section4PriceingDescription = ServiceType4.Section4PriceingDescription;
                ServiceType4ViewModel.Section5PriceingHeading = ServiceType4.Section5PriceingHeading;
                ServiceType4ViewModel.Section6PriceingHeading = ServiceType4.Section6PriceingHeading;
                ServiceType4ViewModel.Section7PriceingHeading = ServiceType4.Section7PriceingHeading;
                ServiceType4ViewModel.DisplayIndex = ServiceType4.DisplayIndex;
                ServiceType4ViewModel.Url = ServiceType4.Url.ToString();
                ServiceType4ViewModel.Metadata = ServiceType4.Metadata.ToString();
                ServiceType4ViewModel.MetaDescription = ServiceType4.MetaDescription.ToString();
                ServiceType4ViewModel.Keyword = ServiceType4.Keyword.ToString();
                ServiceType4ViewModel.IsActive = ServiceType4.IsActive;
                ServiceType4ViewModel.TotalViews = ServiceType4.TotalViews;
                ServiceType4ViewModel.Tenant_ID = Convert.ToInt64(ServiceType4.Tenant_ID);
                ServiceType4ViewModel.CreatedBy = ServiceType4.CreatedBy;
                ServiceType4ViewModel.UpdatedBy = ServiceType4.UpdatedBy;
                ServiceType4ViewModel.CreatedOn = ServiceType4.CreatedOn;
                ServiceType4ViewModel.UpdatedOn = ServiceType4.UpdatedOn;
            }
            /*some db operation*/
            // return Json("ajs");
            return ServiceType4ViewModel;
        }
        [Route("api/ServiceType4/GetServiceType4Section678MasterByTenantIdAndServiceId/{tenantId}/{Id}/{SectionTypeValue}")]
        [HttpGet]
        public List<ServiceType4Section678FieldMasterViewModel> GetServiceType4Section678MasterByTenantIdAndServiceId(string tenantId, string Id, string SectionTypeValue)
        {
             int maxfieldvalue = 0;
            var lstServiceType4Section678FieldMasterViewModel = new List<ServiceType4Section678FieldMasterViewModel>();
            var services4Section678FieldMaster = UnitOfWork.Services4Section678FieldMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true && x.SectionTypeValue == SectionTypeValue).OrderBy(x => x.DisplayIndex);

            foreach (var tempservices4Section678FieldMaster in services4Section678FieldMaster)
            {
                var serviceType4Section678FieldMasterViewModel = new ServiceType4Section678FieldMasterViewModel();
                serviceType4Section678FieldMasterViewModel.Service_Id = tempservices4Section678FieldMaster.ID;
                serviceType4Section678FieldMasterViewModel.SubSubCat_Id = tempservices4Section678FieldMaster.SubSubCat_Id;
                serviceType4Section678FieldMasterViewModel.FieldName = tempservices4Section678FieldMaster.FieldName;
                serviceType4Section678FieldMasterViewModel.DisplayIndex = tempservices4Section678FieldMaster.DisplayIndex;
                serviceType4Section678FieldMasterViewModel.IsActive = tempservices4Section678FieldMaster.IsActive;
                serviceType4Section678FieldMasterViewModel.TotalViews = tempservices4Section678FieldMaster.TotalViews;
                serviceType4Section678FieldMasterViewModel.Url = tempservices4Section678FieldMaster.Url;
                serviceType4Section678FieldMasterViewModel.Metadata = tempservices4Section678FieldMaster.Metadata;
                serviceType4Section678FieldMasterViewModel.Keyword = tempservices4Section678FieldMaster.Keyword;
                serviceType4Section678FieldMasterViewModel.MetaDescription = tempservices4Section678FieldMaster.MetaDescription;
                serviceType4Section678FieldMasterViewModel.Tenant_ID = Convert.ToInt64(tempservices4Section678FieldMaster.Tenant_ID);

                var objServices4Section678FieldValues = UnitOfWork.Services4Section678FieldValuesRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.S4S678FM_Id == Convert.ToInt64(tempservices4Section678FieldMaster.ID) && x.IsActive == true).OrderBy(x => x.S4S678FM_Id);
                var lstserviceType4Section678FieldValuesViewModel = new List<ServiceType4Section678FieldValuesViewModel>();
                if (objServices4Section678FieldValues.ToList().Count > maxfieldvalue)
                {
                    maxfieldvalue = objServices4Section678FieldValues.ToList().Count;
                }
                foreach (var tempservices4Section678FieldValues in objServices4Section678FieldValues)
                {
                    var serviceType4Section678FieldValuesViewModel = new ServiceType4Section678FieldValuesViewModel();
                    serviceType4Section678FieldValuesViewModel.Service_Id = tempservices4Section678FieldValues.ID;
                    serviceType4Section678FieldValuesViewModel.Service_Id = tempservices4Section678FieldValues.ID;
                    serviceType4Section678FieldValuesViewModel.SubSubCat_Id = tempservices4Section678FieldValues.SubSubCat_Id;
                    serviceType4Section678FieldValuesViewModel.RowNumber = tempservices4Section678FieldValues.RowNumber;
                    serviceType4Section678FieldValuesViewModel.DisplayText = tempservices4Section678FieldValues.DisplayText;
                    serviceType4Section678FieldValuesViewModel.DownloadFilePath = tempservices4Section678FieldValues.DownloadFilePath;
                    serviceType4Section678FieldValuesViewModel.S4S678FM_Id = tempservices4Section678FieldValues.S4S678FM_Id;
                    serviceType4Section678FieldValuesViewModel.DisplayIndex = tempservices4Section678FieldValues.DisplayIndex;
                    serviceType4Section678FieldValuesViewModel.IsActive = tempservices4Section678FieldValues.IsActive;
                    serviceType4Section678FieldValuesViewModel.TotalViews = tempservices4Section678FieldValues.TotalViews;
                    serviceType4Section678FieldValuesViewModel.Url = tempservices4Section678FieldValues.Url;
                    serviceType4Section678FieldValuesViewModel.Metadata = tempservices4Section678FieldValues.Metadata;
                    serviceType4Section678FieldValuesViewModel.Keyword = tempservices4Section678FieldValues.Keyword;
                    serviceType4Section678FieldValuesViewModel.MetaDescription = tempservices4Section678FieldValues.MetaDescription;
                    serviceType4Section678FieldValuesViewModel.Tenant_ID = Convert.ToInt64(tempservices4Section678FieldValues.Tenant_ID);
                    lstserviceType4Section678FieldValuesViewModel.Add(serviceType4Section678FieldValuesViewModel);
                }
                serviceType4Section678FieldMasterViewModel.ServiceType4Section678FieldValuesViewModel = lstserviceType4Section678FieldValuesViewModel;
                serviceType4Section678FieldMasterViewModel.maxfieldvalue = maxfieldvalue;
                lstServiceType4Section678FieldMasterViewModel.Add(serviceType4Section678FieldMasterViewModel);
            }

            /*some db operation*/
            // return Json("ajs");
            return lstServiceType4Section678FieldMasterViewModel;
        }
        [Route("api/ServiceType4/GetServiceType4Section345MasterByTenantIdAndServiceId/{tenantId}/{Id}/{SectionTypeValue}")]
        [HttpGet]
        public List<ServiceType4Section345MasterViewModel> GetServiceType4Section345MasterByTenantIdAndServiceId(string tenantId, string Id,string SectionTypeValue)
        {
            // string tenantId = "1";
            var lstServiceType4Section345MasterViewModel = new List<ServiceType4Section345MasterViewModel>();
            var services4Section345Master = UnitOfWork.Services4Section345MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true && x.SectionTypeValue== SectionTypeValue).OrderBy(x => x.DisplayIndex);

            foreach (var tempservices4Section345Master in services4Section345Master)
            {
                var serviceType4Section345MasterViewModel = new ServiceType4Section345MasterViewModel();
                serviceType4Section345MasterViewModel.Service_Id = tempservices4Section345Master.ID;
                serviceType4Section345MasterViewModel.SubSubCat_Id = tempservices4Section345Master.SubSubCat_Id;
                serviceType4Section345MasterViewModel.Heading = tempservices4Section345Master.Heading;
                serviceType4Section345MasterViewModel.SectionType_ID = busConstant.Code.SECTION_TYPE;
                serviceType4Section345MasterViewModel.SectionTypeValue = tempservices4Section345Master.SectionTypeValue;
                serviceType4Section345MasterViewModel.DisplayIndex = tempservices4Section345Master.DisplayIndex;
                serviceType4Section345MasterViewModel.IsActive = tempservices4Section345Master.IsActive;
                serviceType4Section345MasterViewModel.TotalViews = tempservices4Section345Master.TotalViews;
                serviceType4Section345MasterViewModel.Url = tempservices4Section345Master.Url;
                serviceType4Section345MasterViewModel.Metadata = tempservices4Section345Master.Metadata;
                serviceType4Section345MasterViewModel.Keyword = tempservices4Section345Master.Keyword;
                serviceType4Section345MasterViewModel.MetaDescription = tempservices4Section345Master.MetaDescription;
                serviceType4Section345MasterViewModel.Tenant_ID = Convert.ToInt64(tempservices4Section345Master.Tenant_ID);

                var objservices4Section345MasterFeaturesDetails = UnitOfWork.Services4Section345MasterFeaturesDetailsRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.S4S345M_id == Convert.ToInt64(tempservices4Section345Master.ID) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
                var lstservices4Section345MasterFeaturesDetailsViewModel = new List<Services4Section345MasterFeaturesDetailsViewModel>();

                foreach (var tempservices4Section345MasterFeaturesDetails in objservices4Section345MasterFeaturesDetails)
                {
                    var services4Section345MasterFeaturesDetailsViewModel = new Services4Section345MasterFeaturesDetailsViewModel();
                    services4Section345MasterFeaturesDetailsViewModel.Service_Id = tempservices4Section345MasterFeaturesDetails.ID;
                    services4Section345MasterFeaturesDetailsViewModel.S4S345M_id = tempservices4Section345MasterFeaturesDetails.S4S345M_id;
                    services4Section345MasterFeaturesDetailsViewModel.ShortDescription = tempservices4Section345MasterFeaturesDetails.ShortDescription;
                    services4Section345MasterFeaturesDetailsViewModel.DisplayIndex = tempservices4Section345MasterFeaturesDetails.DisplayIndex;
                    services4Section345MasterFeaturesDetailsViewModel.IsActive = tempservices4Section345MasterFeaturesDetails.IsActive;
                    services4Section345MasterFeaturesDetailsViewModel.TotalViews = tempservices4Section345MasterFeaturesDetails.TotalViews;
                    services4Section345MasterFeaturesDetailsViewModel.Url = tempservices4Section345MasterFeaturesDetails.Url;
                    services4Section345MasterFeaturesDetailsViewModel.Metadata = tempservices4Section345MasterFeaturesDetails.Metadata;
                    services4Section345MasterFeaturesDetailsViewModel.Keyword = tempservices4Section345MasterFeaturesDetails.Keyword;
                    services4Section345MasterFeaturesDetailsViewModel.MetaDescription = tempservices4Section345MasterFeaturesDetails.MetaDescription;
                    services4Section345MasterFeaturesDetailsViewModel.Tenant_ID = Convert.ToInt64(tempservices4Section345MasterFeaturesDetails.Tenant_ID);
                    lstservices4Section345MasterFeaturesDetailsViewModel.Add(services4Section345MasterFeaturesDetailsViewModel);
                }
                serviceType4Section345MasterViewModel.Services4Section345MasterFeaturesDetailsViewModel = lstservices4Section345MasterFeaturesDetailsViewModel;

                var objservices4Section345MasterButtonsChild = UnitOfWork.Services4Section345MasterButtonsChildRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.S4S345M_id == Convert.ToInt64(tempservices4Section345Master.ID) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
                var lstservices4Section345MasterButtonsChildViewModel = new List<Services4Section345MasterButtonsChildViewModel>();

                foreach (var tempservices4Section345MasterButtonsChild in objservices4Section345MasterButtonsChild)
                {
                    var services4Section345MasterButtonsChildViewModel = new Services4Section345MasterButtonsChildViewModel();
                    services4Section345MasterButtonsChildViewModel.Service_Id = tempservices4Section345MasterButtonsChild.ID;
                    services4Section345MasterButtonsChildViewModel.S4S345M_id = tempservices4Section345MasterButtonsChild.S4S345M_id;
                    services4Section345MasterButtonsChildViewModel.FeatureDescription = tempservices4Section345MasterButtonsChild.FeatureDescription;
                    services4Section345MasterButtonsChildViewModel.Price = tempservices4Section345MasterButtonsChild.Price;
                    services4Section345MasterButtonsChildViewModel.AncharTagTitle = tempservices4Section345MasterButtonsChild.AncharTagTitle;
                    services4Section345MasterButtonsChildViewModel.AncharTagUrl = tempservices4Section345MasterButtonsChild.AncharTagUrl;
                    services4Section345MasterButtonsChildViewModel.DisplayIndex = tempservices4Section345MasterButtonsChild.DisplayIndex;
                    services4Section345MasterButtonsChildViewModel.IsActive = tempservices4Section345MasterButtonsChild.IsActive;
                    services4Section345MasterButtonsChildViewModel.TotalViews = tempservices4Section345MasterButtonsChild.TotalViews;
                    services4Section345MasterButtonsChildViewModel.Url = tempservices4Section345MasterButtonsChild.Url;
                    services4Section345MasterButtonsChildViewModel.Metadata = tempservices4Section345MasterButtonsChild.Metadata;
                    services4Section345MasterButtonsChildViewModel.Keyword = tempservices4Section345MasterButtonsChild.Keyword;
                    services4Section345MasterButtonsChildViewModel.MetaDescription = tempservices4Section345MasterButtonsChild.MetaDescription;
                    services4Section345MasterButtonsChildViewModel.Tenant_ID = Convert.ToInt64(tempservices4Section345MasterButtonsChild.Tenant_ID);
                    lstservices4Section345MasterButtonsChildViewModel.Add(services4Section345MasterButtonsChildViewModel);
                }
                serviceType4Section345MasterViewModel.Services4Section345MasterButtonsChildViewModel = lstservices4Section345MasterButtonsChildViewModel;


                lstServiceType4Section345MasterViewModel.Add(serviceType4Section345MasterViewModel);
            }

            /*some db operation*/
            // return Json("ajs");
            return lstServiceType4Section345MasterViewModel;
        }
        [Route("api/ServiceType4/GetServiceType4Section2FAQMappingByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<Services4Section2FAQMappingViewModel> GetServiceType4Section2FAQMappingByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstServices4Section2FAQMappingViewModel = new List<Services4Section2FAQMappingViewModel>();
            var services4Section2FAQMapping = UnitOfWork.Services4Section2FAQMappingRepository.Get().Join(UnitOfWork.TenantRepository.Get(), Services4Section2FAQMapping => Services4Section2FAQMapping.Tenant_ID, tenant => tenant.ID, (Services4Section2FAQMapping, tenant) => new { Services4Section2FAQMapping, tenant })
                    .Join(UnitOfWork.FAQMasterRepository.Get(), Services4Section2FAQMapping_tenant => Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.FAQMaster_Id, FAQMaster => FAQMaster.ID, (Services4Section2FAQMapping_tenant, FAQMaster) => new { Services4Section2FAQMapping_tenant, FAQMaster })
                    .Where(x => x.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Tenant_ID == Convert.ToInt64(tenantId) && x.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Service_Id == Convert.ToInt64(Id) && x.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.IsActive == true)
                    .OrderBy(x => x.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.DisplayIndex);
            if (services4Section2FAQMapping != null)
            {
                foreach (var tempServices4Section2FAQMapping in services4Section2FAQMapping)
                {
                    var Services4Section2FAQMappingViewModel = new Services4Section2FAQMappingViewModel();
                    Services4Section2FAQMappingViewModel.ID = tempServices4Section2FAQMapping.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.ID;
                    Services4Section2FAQMappingViewModel.FAQMaster_Id = Convert.ToInt64(tempServices4Section2FAQMapping.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.FAQMaster_Id);
                    Services4Section2FAQMappingViewModel.Service_Id = tempServices4Section2FAQMapping.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Service_Id;
                    Services4Section2FAQMappingViewModel.SubSubCat_Id = Convert.ToInt64(tempServices4Section2FAQMapping.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.SubSubCat_Id);
                    Services4Section2FAQMappingViewModel.Title = tempServices4Section2FAQMapping.FAQMaster.Title;
                    Services4Section2FAQMappingViewModel.Description = tempServices4Section2FAQMapping.FAQMaster.Description;
                    Services4Section2FAQMappingViewModel.DisplayIndex = tempServices4Section2FAQMapping.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.DisplayIndex;
                    Services4Section2FAQMappingViewModel.IsActive = tempServices4Section2FAQMapping.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.IsActive;
                    Services4Section2FAQMappingViewModel.TotalViews = tempServices4Section2FAQMapping.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.TotalViews;
                    Services4Section2FAQMappingViewModel.Url = tempServices4Section2FAQMapping.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Url;
                    Services4Section2FAQMappingViewModel.Metadata = tempServices4Section2FAQMapping.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Metadata;
                    Services4Section2FAQMappingViewModel.Keyword = tempServices4Section2FAQMapping.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Keyword;
                    Services4Section2FAQMappingViewModel.MetaDescription = tempServices4Section2FAQMapping.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.MetaDescription;
                    Services4Section2FAQMappingViewModel.Tenant_ID = Convert.ToInt64(tempServices4Section2FAQMapping.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Tenant_ID);
                    lstServices4Section2FAQMappingViewModel.Add(Services4Section2FAQMappingViewModel);
                }
            }
            /*some db operation*/
            // return Json("ajs");
            return lstServices4Section2FAQMappingViewModel;
        }
        #endregion
    }

}