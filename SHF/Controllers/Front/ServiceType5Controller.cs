
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
   
    public class ServiceType5Controller : ApiController
    {

        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        public ServiceType5Controller()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
        }
        public ServiceType5Controller(SHF.DataAccess.Implementations.UnitOfWork unitOfWork,Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
            this.UnitOfWork = unitOfWork;
            this.businessMessage = Imessage;
            this.businessCategoriesMaster = ICategoriesMaster;
            this.businessSubCategoriesMaster = ISubCategoriesMaster;
            this.businessSubSubCategoriesMaster = ISubSubCategoriesMaster;

        }
        
        //GET: api/GetAllActiveServiceType5ByTenantId? tenantId = 1
       // [EnableCors]
        [Route("api/ServiceType5/GetServiceType5ByTenantIdAndUrl/{tenantId}/{url}")]
        [HttpGet]
        public ServiceType5ViewModel GetServiceType5ByTenantIdAndUrl(string tenantId,string url)
        {
          // string tenantId = "1";
            var ServiceType5ViewModel = new ServiceType5ViewModel();
           var ServiceType5 = UnitOfWork.Services5MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
            if (ServiceType5!=null)
            {
                ServiceType5ViewModel.ID = ServiceType5.ID;
                ServiceType5ViewModel.BannerImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, ServiceType5.Tenant_ID) + "/" + ServiceType5.BannerImagePath;
                ServiceType5ViewModel.BannerOnHeading = ServiceType5.BannerOnHeading;
                ServiceType5ViewModel.Cat_Id = ServiceType5.Cat_Id;
                ServiceType5ViewModel.SubCat_Id = ServiceType5.SubCat_Id;
                ServiceType5ViewModel.SubSubCat_Id = ServiceType5.SubSubCat_Id;
                ServiceType5ViewModel.SubSubCategoryName = ServiceType5.SubSubCategoryName;
                ServiceType5ViewModel.BannerHeadingDescription = ServiceType5.BannerHeadingDescription;
                ServiceType5ViewModel.BannerOnHeading = ServiceType5.BannerOnHeading;
                ServiceType5ViewModel.Section1Description = ServiceType5.Section1Description;
                ServiceType5ViewModel.Section2Heading = ServiceType5.Section2Heading;
                ServiceType5ViewModel.Section2HeadingDescription = ServiceType5.Section2HeadingDescription;
                ServiceType5ViewModel.DisplayIndex = ServiceType5.DisplayIndex;
                ServiceType5ViewModel.Url = ServiceType5.Url.ToString();
                ServiceType5ViewModel.Metadata = ServiceType5.Metadata.ToString();
                ServiceType5ViewModel.MetaDescription = ServiceType5.MetaDescription.ToString();
                ServiceType5ViewModel.Keyword = ServiceType5.Keyword.ToString();
                ServiceType5ViewModel.IsActive = ServiceType5.IsActive;
                ServiceType5ViewModel.TotalViews = ServiceType5.TotalViews;
                ServiceType5ViewModel.Tenant_ID = Convert.ToInt64(ServiceType5.Tenant_ID);
                ServiceType5ViewModel.CreatedBy = ServiceType5.CreatedBy;
                ServiceType5ViewModel.UpdatedBy = ServiceType5.UpdatedBy;
                ServiceType5ViewModel.CreatedOn = ServiceType5.CreatedOn;
                ServiceType5ViewModel.UpdatedOn = ServiceType5.UpdatedOn;
            }
            /*some db operation*/
            // return Json("ajs");
            return ServiceType5ViewModel;
        }

        [Route("api/ServiceType5/GetServiceType5Section2MasterByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<ServiceType5Section2MasterViewModel> GetServiceType5Section2MasterByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstServiceType5Section2MasterViewModel = new List<ServiceType5Section2MasterViewModel>();
            var Services5Section2Master = UnitOfWork.Services5Section2MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x => x.DisplayIndex);

            foreach (var tempServices5Section2Master in Services5Section2Master)
            {
                var serviceType5Section2MasterViewModel = new ServiceType5Section2MasterViewModel();
                serviceType5Section2MasterViewModel.ID = tempServices5Section2Master.ID;
                serviceType5Section2MasterViewModel.SubSubCat_Id = Convert.ToInt64(tempServices5Section2Master.SubSubCat_Id);
                serviceType5Section2MasterViewModel.AncharTagTitle = tempServices5Section2Master.AncharTagTitle;
                serviceType5Section2MasterViewModel.AncharTagUrl = tempServices5Section2Master.AncharTagUrl;
                serviceType5Section2MasterViewModel.ImageFilePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, tempServices5Section2Master.Tenant_ID) + "/" + tempServices5Section2Master.ImageFilePath;
                serviceType5Section2MasterViewModel.DisplayIndex = tempServices5Section2Master.DisplayIndex;
                serviceType5Section2MasterViewModel.IsActive = tempServices5Section2Master.IsActive;
                serviceType5Section2MasterViewModel.TotalViews = tempServices5Section2Master.TotalViews;
                serviceType5Section2MasterViewModel.Url = tempServices5Section2Master.Url;
                serviceType5Section2MasterViewModel.Metadata = tempServices5Section2Master.Metadata;
                serviceType5Section2MasterViewModel.Keyword = tempServices5Section2Master.Keyword;
                serviceType5Section2MasterViewModel.MetaDescription = tempServices5Section2Master.MetaDescription;
                serviceType5Section2MasterViewModel.Tenant_ID = Convert.ToInt64(tempServices5Section2Master.Tenant_ID);

                var objServices5Section2MasterFeaturesDetails = UnitOfWork.Services5Section2MasterFeaturesDetailsRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.S5S2M_Id == Convert.ToInt64(tempServices5Section2Master.ID) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
                var lstsserviceType5Section2MasterFeaturesDetailsViewModel = new List<ServiceType5Section2MasterFeaturesDetailsViewModel>();

                foreach (var tempServices5Section2MasterFeaturesDetails in objServices5Section2MasterFeaturesDetails)
                {
                    var serviceType5Section2MasterFeaturesDetailsViewModel = new ServiceType5Section2MasterFeaturesDetailsViewModel();
                    serviceType5Section2MasterFeaturesDetailsViewModel.ID = tempServices5Section2MasterFeaturesDetails.ID;
                    serviceType5Section2MasterFeaturesDetailsViewModel.S5S2M_Id = tempServices5Section2MasterFeaturesDetails.S5S2M_Id;
                    serviceType5Section2MasterFeaturesDetailsViewModel.Service_Id = tempServices5Section2MasterFeaturesDetails.Service_Id;
                    serviceType5Section2MasterFeaturesDetailsViewModel.SubSubCat_Id = Convert.ToInt64(tempServices5Section2MasterFeaturesDetails.SubSubCat_Id);
                    serviceType5Section2MasterFeaturesDetailsViewModel.Text = tempServices5Section2MasterFeaturesDetails.Text;
                    serviceType5Section2MasterFeaturesDetailsViewModel.DisplayIndex = tempServices5Section2MasterFeaturesDetails.DisplayIndex;
                    serviceType5Section2MasterFeaturesDetailsViewModel.IsActive = tempServices5Section2MasterFeaturesDetails.IsActive;
                    serviceType5Section2MasterFeaturesDetailsViewModel.TotalViews = tempServices5Section2MasterFeaturesDetails.TotalViews;
                    serviceType5Section2MasterFeaturesDetailsViewModel.Url = tempServices5Section2MasterFeaturesDetails.Url;
                    serviceType5Section2MasterFeaturesDetailsViewModel.Metadata = tempServices5Section2MasterFeaturesDetails.Metadata;
                    serviceType5Section2MasterFeaturesDetailsViewModel.Keyword = tempServices5Section2MasterFeaturesDetails.Keyword;
                    serviceType5Section2MasterFeaturesDetailsViewModel.MetaDescription = tempServices5Section2MasterFeaturesDetails.MetaDescription;
                    serviceType5Section2MasterFeaturesDetailsViewModel.Tenant_ID = Convert.ToInt64(tempServices5Section2MasterFeaturesDetails.Tenant_ID);
                    lstsserviceType5Section2MasterFeaturesDetailsViewModel.Add(serviceType5Section2MasterFeaturesDetailsViewModel);
                }
                serviceType5Section2MasterViewModel.ServiceType5Section2MasterFeaturesDetailsViewModel = lstsserviceType5Section2MasterFeaturesDetailsViewModel;
                lstServiceType5Section2MasterViewModel.Add(serviceType5Section2MasterViewModel);
            }

            /*some db operation*/
            // return Json("ajs");
            return lstServiceType5Section2MasterViewModel;
        }
        #endregion
    }

}