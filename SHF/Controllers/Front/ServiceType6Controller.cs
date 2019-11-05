
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
   
    public class ServiceType6Controller : ApiController
    {

        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        public ServiceType6Controller()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
        }
        public ServiceType6Controller(SHF.DataAccess.Implementations.UnitOfWork unitOfWork,Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
            this.UnitOfWork = unitOfWork;
            this.businessMessage = Imessage;
            this.businessCategoriesMaster = ICategoriesMaster;
            this.businessSubCategoriesMaster = ISubCategoriesMaster;
            this.businessSubSubCategoriesMaster = ISubSubCategoriesMaster;

        }
        
        //GET: api/GetAllActiveServiceType6ByTenantId? tenantId = 1
       // [EnableCors]
        [Route("api/ServiceType6/GetServiceType6ByTenantIdAndUrl/{tenantId}/{url}")]
        [HttpGet]
        public ServiceType6ViewModel GetServiceType6ByTenantIdAndUrl(string tenantId,string url)
        {
          // string tenantId = "1";
            var ServiceType6ViewModel = new ServiceType6ViewModel();
           var ServiceType6 = UnitOfWork.Services6MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
            if (ServiceType6!=null)
            {
                ServiceType6ViewModel.ID = ServiceType6.ID;
                ServiceType6ViewModel.BannerImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, ServiceType6.Tenant_ID) + "/" + ServiceType6.BannerImagePath;
                ServiceType6ViewModel.BannerOnHeading = ServiceType6.BannerOnHeading;
                ServiceType6ViewModel.Cat_Id = ServiceType6.Cat_Id;
                ServiceType6ViewModel.SubCat_Id = ServiceType6.SubCat_Id;
                ServiceType6ViewModel.SubSubCat_Id = ServiceType6.SubSubCat_Id;
                ServiceType6ViewModel.SubSubCategoryName = ServiceType6.SubSubCategoryName;
                ServiceType6ViewModel.BannerHeadingDescription = ServiceType6.BannerHeadingDescription;
                ServiceType6ViewModel.BannerOnHeading = ServiceType6.BannerOnHeading;
                ServiceType6ViewModel.Section1Description = ServiceType6.Section1Description;
                ServiceType6ViewModel.Section2Heading = ServiceType6.Section2Heading;
                ServiceType6ViewModel.Section2HeadingDescription = ServiceType6.Section2HeadingDescription;
                ServiceType6ViewModel.DisplayIndex = ServiceType6.DisplayIndex;
                ServiceType6ViewModel.Url = ServiceType6.Url.ToString();
                ServiceType6ViewModel.Metadata = ServiceType6.Metadata.ToString();
                ServiceType6ViewModel.MetaDescription = ServiceType6.MetaDescription.ToString();
                ServiceType6ViewModel.Keyword = ServiceType6.Keyword.ToString();
                ServiceType6ViewModel.IsActive = ServiceType6.IsActive;
                ServiceType6ViewModel.TotalViews = ServiceType6.TotalViews;
                ServiceType6ViewModel.Tenant_ID = Convert.ToInt64(ServiceType6.Tenant_ID);
                ServiceType6ViewModel.CreatedBy = ServiceType6.CreatedBy;
                ServiceType6ViewModel.UpdatedBy = ServiceType6.UpdatedBy;
                ServiceType6ViewModel.CreatedOn = ServiceType6.CreatedOn;
                ServiceType6ViewModel.UpdatedOn = ServiceType6.UpdatedOn;
            }
            /*some db operation*/
            // return Json("ajs");
            return ServiceType6ViewModel;
        }

        [Route("api/ServiceType6/GetServiceType6Section2MasterByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<ServiceType6Section2MasterViewModel> GetServiceType6Section2MasterByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstServiceType6Section2MasterViewModel = new List<ServiceType6Section2MasterViewModel>();
            var Services6Section2Master = UnitOfWork.Services6Section2MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x => x.DisplayIndex);

            foreach (var tempServices6Section2Master in Services6Section2Master)
            {
                var serviceType6Section2MasterViewModel = new ServiceType6Section2MasterViewModel();
                serviceType6Section2MasterViewModel.ID = tempServices6Section2Master.ID;
                serviceType6Section2MasterViewModel.SubSubCat_Id = Convert.ToInt64(tempServices6Section2Master.SubSubCat_Id);
                serviceType6Section2MasterViewModel.Title = tempServices6Section2Master.Title;
                serviceType6Section2MasterViewModel.ImageFilePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, tempServices6Section2Master.Tenant_ID) + "/" + tempServices6Section2Master.ImageFilePath;
                serviceType6Section2MasterViewModel.DisplayIndex = tempServices6Section2Master.DisplayIndex;
                serviceType6Section2MasterViewModel.IsActive = tempServices6Section2Master.IsActive;
                serviceType6Section2MasterViewModel.TotalViews = tempServices6Section2Master.TotalViews;
                serviceType6Section2MasterViewModel.Url = tempServices6Section2Master.Url;
                serviceType6Section2MasterViewModel.Metadata = tempServices6Section2Master.Metadata;
                serviceType6Section2MasterViewModel.Keyword = tempServices6Section2Master.Keyword;
                serviceType6Section2MasterViewModel.MetaDescription = tempServices6Section2Master.MetaDescription;
                serviceType6Section2MasterViewModel.Tenant_ID = Convert.ToInt64(tempServices6Section2Master.Tenant_ID);

                var objservices6Section2MasterFeaturesDetails = UnitOfWork.Services6Section2MasterFeaturesDetailsRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.S6S2M_Id == Convert.ToInt64(tempServices6Section2Master.ID) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
                var lstsServiceType6Section2MasterFeaturesDetailsViewModel = new List<ServiceType6Section2MasterFeaturesDetailsViewModel>();

                foreach (var tempServices6Section2MasterFeaturesDetails in objservices6Section2MasterFeaturesDetails)
                {
                    var ServiceType6Section2MasterFeaturesDetailsViewModel = new ServiceType6Section2MasterFeaturesDetailsViewModel();
                    ServiceType6Section2MasterFeaturesDetailsViewModel.ID = tempServices6Section2MasterFeaturesDetails.ID;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.S6S2M_Id = tempServices6Section2MasterFeaturesDetails.S6S2M_Id;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.Service_Id = tempServices6Section2MasterFeaturesDetails.Service_Id;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.SubSubCat_Id = Convert.ToInt64(tempServices6Section2MasterFeaturesDetails.SubSubCat_Id);
                    ServiceType6Section2MasterFeaturesDetailsViewModel.Price = tempServices6Section2MasterFeaturesDetails.Price;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.AncharTagTitle = tempServices6Section2MasterFeaturesDetails.AncharTagTitle;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.AncharTagUrl = tempServices6Section2MasterFeaturesDetails.AncharTagUrl;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.DisplayIndex = tempServices6Section2MasterFeaturesDetails.DisplayIndex;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.IsActive = tempServices6Section2MasterFeaturesDetails.IsActive;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.TotalViews = tempServices6Section2MasterFeaturesDetails.TotalViews;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.Url = tempServices6Section2MasterFeaturesDetails.Url;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.Metadata = tempServices6Section2MasterFeaturesDetails.Metadata;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.Keyword = tempServices6Section2MasterFeaturesDetails.Keyword;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.MetaDescription = tempServices6Section2MasterFeaturesDetails.MetaDescription;
                    ServiceType6Section2MasterFeaturesDetailsViewModel.Tenant_ID = Convert.ToInt64(tempServices6Section2MasterFeaturesDetails.Tenant_ID);
                    lstsServiceType6Section2MasterFeaturesDetailsViewModel.Add(ServiceType6Section2MasterFeaturesDetailsViewModel);
                }
                serviceType6Section2MasterViewModel.ServiceType6Section2MasterFeaturesDetailsViewModel = lstsServiceType6Section2MasterFeaturesDetailsViewModel;
                lstServiceType6Section2MasterViewModel.Add(serviceType6Section2MasterViewModel);
            }

            /*some db operation*/
            // return Json("ajs");
            return lstServiceType6Section2MasterViewModel;
        }
        #endregion
    }

}