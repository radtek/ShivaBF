
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

        [Route("api/ServiceType4/GetServiceType4Section2MasterByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<ServiceType4Section2MasterViewModel> ServiceType4Section2MasterByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstServiceType4Section2MasterViewModel = new List<ServiceType4Section2MasterViewModel>();
            var services4Section2Master = UnitOfWork.Services4Section2MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x => x.DisplayIndex);

                foreach (var tempservices4Section2Master in services4Section2Master)
                {
                    var ServiceType4Section2MasterViewModel = new ServiceType4Section2MasterViewModel();
                    ServiceType4Section2MasterViewModel.ID = tempservices4Section2Master.ID;
                    ServiceType4Section2MasterViewModel.SubSubCat_Id = Convert.ToInt64(tempservices4Section2Master.SubSubCat_Id);
                    ServiceType4Section2MasterViewModel.Heading = tempservices4Section2Master.Heading;
                    ServiceType4Section2MasterViewModel.Description = tempservices4Section2Master.Description;
                    ServiceType4Section2MasterViewModel.DisplayIndex = tempservices4Section2Master.DisplayIndex;
                    ServiceType4Section2MasterViewModel.IsActive = tempservices4Section2Master.IsActive;
                    ServiceType4Section2MasterViewModel.TotalViews = tempservices4Section2Master.TotalViews;
                    ServiceType4Section2MasterViewModel.Url = tempservices4Section2Master.Url;
                    ServiceType4Section2MasterViewModel.Metadata = tempservices4Section2Master.Metadata;
                    ServiceType4Section2MasterViewModel.Keyword = tempservices4Section2Master.Keyword;
                    ServiceType4Section2MasterViewModel.MetaDescription = tempservices4Section2Master.MetaDescription;
                    ServiceType4Section2MasterViewModel.Tenant_ID = Convert.ToInt64(tempservices4Section2Master.Tenant_ID);

                var objservices4Section2MasterChild = UnitOfWork.Services4Section2MasterChildRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.S4S2M_id == Convert.ToInt64(tempservices4Section2Master.ID) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
                var lstserviceType4Section2MasterChildViewModel = new List<ServiceType4Section2MasterChildViewModel>();

                    foreach (var tempservices4Section2MasterChild in objservices4Section2MasterChild)
                    {
                        var serviceType4Section2MasterChildViewModel = new ServiceType4Section2MasterChildViewModel();
                        serviceType4Section2MasterChildViewModel.ID = tempservices4Section2MasterChild.ID;
                        serviceType4Section2MasterChildViewModel.SubSubCat_Id = Convert.ToInt64(tempservices4Section2MasterChild.SubSubCat_Id);
                        serviceType4Section2MasterChildViewModel.AncharTagTitle = tempservices4Section2MasterChild.AncharTagTitle;
                        serviceType4Section2MasterChildViewModel.AncharTagUrl = tempservices4Section2MasterChild.AncharTagUrl;
                        serviceType4Section2MasterChildViewModel.FeatureDescription = tempservices4Section2MasterChild.FeatureDescription;
                        serviceType4Section2MasterChildViewModel.Price = Convert.ToInt32(tempservices4Section2MasterChild.Price);
                        serviceType4Section2MasterChildViewModel.DisplayIndex = tempservices4Section2MasterChild.DisplayIndex;
                        serviceType4Section2MasterChildViewModel.IsActive = tempservices4Section2MasterChild.IsActive;
                        serviceType4Section2MasterChildViewModel.TotalViews = tempservices4Section2MasterChild.TotalViews;
                        serviceType4Section2MasterChildViewModel.Url = tempservices4Section2MasterChild.Url;
                        serviceType4Section2MasterChildViewModel.Metadata = tempservices4Section2MasterChild.Metadata;
                        serviceType4Section2MasterChildViewModel.Keyword = tempservices4Section2MasterChild.Keyword;
                        serviceType4Section2MasterChildViewModel.MetaDescription = tempservices4Section2MasterChild.MetaDescription;
                        serviceType4Section2MasterChildViewModel.Tenant_ID = Convert.ToInt64(tempservices4Section2MasterChild.Tenant_ID);
                        lstserviceType4Section2MasterChildViewModel.Add(serviceType4Section2MasterChildViewModel);
                    }
                 ServiceType4Section2MasterViewModel.ServiceType4Section2MasterChildViewModel= lstserviceType4Section2MasterChildViewModel;
                lstServiceType4Section2MasterViewModel.Add(ServiceType4Section2MasterViewModel);
                }
           
            /*some db operation*/
            // return Json("ajs");
            return lstServiceType4Section2MasterViewModel;
        }
        #endregion
    }

}