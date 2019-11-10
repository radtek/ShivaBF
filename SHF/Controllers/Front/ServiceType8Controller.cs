
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

    public class ServiceType8Controller : ApiController
    {

        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        public ServiceType8Controller()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
        }
        public ServiceType8Controller(SHF.DataAccess.Implementations.UnitOfWork unitOfWork, Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
            this.UnitOfWork = unitOfWork;
            this.businessMessage = Imessage;
            this.businessCategoriesMaster = ICategoriesMaster;
            this.businessSubCategoriesMaster = ISubCategoriesMaster;
            this.businessSubSubCategoriesMaster = ISubSubCategoriesMaster;

        }

        //GET: api/GetAllActiveServiceType8ByTenantId? tenantId = 1
        // [EnableCors]
        [Route("api/ServiceType8/GetServiceType8ByTenantIdAndUrl/{tenantId}/{url}")]
        [HttpGet]
        public ServiceType8ViewModel GetServiceType8ByTenantIdAndUrl(string tenantId, string url)
        {
            // string tenantId = "1";
            var ServiceType8ViewModel = new ServiceType8ViewModel();
            var ServiceType8 = UnitOfWork.Services8MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
            if (ServiceType8 != null)
            {
                ServiceType8ViewModel.ID = ServiceType8.ID;
                ServiceType8ViewModel.BannerImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, ServiceType8.Tenant_ID) + "/" + ServiceType8.BannerImagePath;
                ServiceType8ViewModel.BannerOnHeading = ServiceType8.BannerOnHeading;
                ServiceType8ViewModel.Cat_Id = ServiceType8.Cat_Id;
                ServiceType8ViewModel.SubCat_Id = ServiceType8.SubCat_Id;
                ServiceType8ViewModel.SubSubCat_Id = ServiceType8.SubSubCat_Id;
                ServiceType8ViewModel.SubSubCategoryName = ServiceType8.SubSubCategoryName;
                ServiceType8ViewModel.BannerHeadingDescription = ServiceType8.BannerHeadingDescription;
                ServiceType8ViewModel.BannerOnHeading = ServiceType8.BannerOnHeading;
                ServiceType8ViewModel.Section1Description = ServiceType8.Section1Description;
                ServiceType8ViewModel.Section1Heading = ServiceType8.Section1Heading;
                ServiceType8ViewModel.Section4Heading = ServiceType8.Section4Heading;
                ServiceType8ViewModel.Section5Heading = ServiceType8.Section5Heading;
                ServiceType8ViewModel.Section5Description = ServiceType8.Section5Description;
                ServiceType8ViewModel.Section5TextboxMaskedText = ServiceType8.Section5TextboxMaskedText;
                ServiceType8ViewModel.Section2BannerPath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, ServiceType8.Tenant_ID) + "/" + ServiceType8.Section2BannerPath;
                ServiceType8ViewModel.Section2BannerHeadingDescription = ServiceType8.Section2BannerHeadingDescription;
                ServiceType8ViewModel.DisplayIndex = ServiceType8.DisplayIndex;
                ServiceType8ViewModel.Url = ServiceType8.Url.ToString();
                ServiceType8ViewModel.Metadata = ServiceType8.Metadata.ToString();
                ServiceType8ViewModel.MetaDescription = ServiceType8.MetaDescription.ToString();
                ServiceType8ViewModel.Keyword = ServiceType8.Keyword.ToString();
                ServiceType8ViewModel.IsActive = ServiceType8.IsActive;
                ServiceType8ViewModel.TotalViews = ServiceType8.TotalViews;
                ServiceType8ViewModel.Tenant_ID = Convert.ToInt64(ServiceType8.Tenant_ID);
                ServiceType8ViewModel.CreatedBy = ServiceType8.CreatedBy;
                ServiceType8ViewModel.UpdatedBy = ServiceType8.UpdatedBy;
                ServiceType8ViewModel.CreatedOn = ServiceType8.CreatedOn;
                ServiceType8ViewModel.UpdatedOn = ServiceType8.UpdatedOn;
            }
            /*some db operation*/
            // return Json("ajs");
            return ServiceType8ViewModel;
        }

        [Route("api/ServiceType8/GetServiceType8Section6MasterByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<ServiceType8Section6MasterViewModel> GetServiceType8Section6MasterByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstServiceType8Section6MasterViewModel = new List<ServiceType8Section6MasterViewModel>();
            var ServiceType8Section6Master = UnitOfWork.Services8Section6MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
            foreach (var tempServiceType8Section6Master in ServiceType8Section6Master)
            {
                var serviceType8Section6MasterViewModel = new ServiceType8Section6MasterViewModel();
                serviceType8Section6MasterViewModel.ID = tempServiceType8Section6Master.ID;
                serviceType8Section6MasterViewModel.SubSubCat_Id = Convert.ToInt64(tempServiceType8Section6Master.SubSubCat_Id);
                serviceType8Section6MasterViewModel.HeadingText = tempServiceType8Section6Master.HeadingText;
                serviceType8Section6MasterViewModel.ShortDescription = tempServiceType8Section6Master.ShortDescription;
                serviceType8Section6MasterViewModel.AncharTagTitle = tempServiceType8Section6Master.AncharTagTitle;
                serviceType8Section6MasterViewModel.AncharTagUrl = tempServiceType8Section6Master.AncharTagUrl;
                serviceType8Section6MasterViewModel.DisplayIndex = tempServiceType8Section6Master.DisplayIndex;
                serviceType8Section6MasterViewModel.IsActive = tempServiceType8Section6Master.IsActive;
                serviceType8Section6MasterViewModel.TotalViews = tempServiceType8Section6Master.TotalViews;
                serviceType8Section6MasterViewModel.Url = tempServiceType8Section6Master.Url;
                serviceType8Section6MasterViewModel.Metadata = tempServiceType8Section6Master.Metadata;
                serviceType8Section6MasterViewModel.Keyword = tempServiceType8Section6Master.Keyword;
                serviceType8Section6MasterViewModel.MetaDescription = tempServiceType8Section6Master.MetaDescription;
                serviceType8Section6MasterViewModel.Tenant_ID = Convert.ToInt64(tempServiceType8Section6Master.Tenant_ID);
                lstServiceType8Section6MasterViewModel.Add(serviceType8Section6MasterViewModel);
            }
            /*some db operation*/
            // return Json("ajs");
            return lstServiceType8Section6MasterViewModel;
        }

       
        [Route("api/ServiceType8/GeServiceType8HeadingButtonsByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<ServicesType8HeadingButtonsViewModel> GeServiceType8HeadingButtonsByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstservicesType8HeadingButtonsViewModel = new List<ServicesType8HeadingButtonsViewModel>();
            var ServiceType8HeadingButtons = UnitOfWork.Services8HeadingButtonsRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
            foreach (var tempServiceType8HeadingButtons in ServiceType8HeadingButtons)
            {
                var servicesType3HeadingButtonsViewModel = new ServicesType8HeadingButtonsViewModel();
                servicesType3HeadingButtonsViewModel.SubSubCat_Id = Convert.ToInt64(tempServiceType8HeadingButtons.SubSubCat_Id);
                servicesType3HeadingButtonsViewModel.AncharTagTitle = tempServiceType8HeadingButtons.AncharTagTitle;
                servicesType3HeadingButtonsViewModel.AncharTagUrl = tempServiceType8HeadingButtons.AncharTagUrl;
                servicesType3HeadingButtonsViewModel.DisplayIndex = tempServiceType8HeadingButtons.DisplayIndex;
                servicesType3HeadingButtonsViewModel.IsActive = tempServiceType8HeadingButtons.IsActive;
                servicesType3HeadingButtonsViewModel.TotalViews = tempServiceType8HeadingButtons.TotalViews;
                servicesType3HeadingButtonsViewModel.Url = tempServiceType8HeadingButtons.Url;
                servicesType3HeadingButtonsViewModel.Metadata = tempServiceType8HeadingButtons.Metadata;
                servicesType3HeadingButtonsViewModel.Keyword = tempServiceType8HeadingButtons.Keyword;
                servicesType3HeadingButtonsViewModel.MetaDescription = tempServiceType8HeadingButtons.MetaDescription;
                servicesType3HeadingButtonsViewModel.Tenant_ID = Convert.ToInt64(tempServiceType8HeadingButtons.Tenant_ID);
                lstservicesType8HeadingButtonsViewModel.Add(servicesType3HeadingButtonsViewModel);
            }

            /*some db operation*/
            // return Json("ajs");
            return lstservicesType8HeadingButtonsViewModel;
        }
        #endregion
    }

}