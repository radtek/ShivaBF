
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
   
    public class ServiceType3Controller : ApiController
    {

        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        public ServiceType3Controller()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
        }
        public ServiceType3Controller(SHF.DataAccess.Implementations.UnitOfWork unitOfWork,Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
            this.UnitOfWork = unitOfWork;
            this.businessMessage = Imessage;
            this.businessCategoriesMaster = ICategoriesMaster;
            this.businessSubCategoriesMaster = ISubCategoriesMaster;
            this.businessSubSubCategoriesMaster = ISubSubCategoriesMaster;

        }
        
        //GET: api/GetAllActiveServiceType3ByTenantId? tenantId = 1
       // [EnableCors]
        [Route("api/ServiceType3/GetServiceType3ByTenantIdAndUrl/{tenantId}/{url}")]
        [HttpGet]
        public ServiceType3ViewModel GetServiceType3ByTenantIdAndUrl(string tenantId,string url)
        {
          // string tenantId = "1";
            var ServiceType3ViewModel = new ServiceType3ViewModel();
           var ServiceType3 = UnitOfWork.Services3MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
            if (ServiceType3!=null)
            {
                ServiceType3ViewModel.ID = ServiceType3.ID;
                ServiceType3ViewModel.BannerImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, ServiceType3.Tenant_ID) + "/" + ServiceType3.BannerImagePath;
                ServiceType3ViewModel.BannerOnHeading = ServiceType3.BannerOnHeading;
                ServiceType3ViewModel.Cat_Id = ServiceType3.Cat_Id;
                ServiceType3ViewModel.SubCat_Id = ServiceType3.SubCat_Id;
                ServiceType3ViewModel.SubSubCat_Id = ServiceType3.SubSubCat_Id;
                ServiceType3ViewModel.SubSubCategoryName = ServiceType3.SubSubCategoryName;
                ServiceType3ViewModel.BannerHeadingDescription = ServiceType3.BannerHeadingDescription;
                ServiceType3ViewModel.BannerOnHeading = ServiceType3.BannerOnHeading;
                ServiceType3ViewModel.Section1Description = ServiceType3.Section1Description;
                ServiceType3ViewModel.Section1Heading = ServiceType3.Section1Heading;
                ServiceType3ViewModel.Section4Heading = ServiceType3.Section4Heading;
                ServiceType3ViewModel.Section5Heading = ServiceType3.Section5Heading;
                ServiceType3ViewModel.Section5Description = ServiceType3.Section5Description;
                ServiceType3ViewModel.Section5TextboxMaskedText = ServiceType3.Section5TextboxMaskedText;
                ServiceType3ViewModel.Section6PriceingHeading = ServiceType3.Section6PriceingHeading;
                ServiceType3ViewModel.Section6PriceingDescription = ServiceType3.Section6PriceingDescription;
                ServiceType3ViewModel.DisplayIndex = ServiceType3.DisplayIndex;
                ServiceType3ViewModel.Url = ServiceType3.Url.ToString();
                ServiceType3ViewModel.Metadata = ServiceType3.Metadata.ToString();
                ServiceType3ViewModel.MetaDescription = ServiceType3.MetaDescription.ToString();
                ServiceType3ViewModel.Keyword = ServiceType3.Keyword.ToString();
                ServiceType3ViewModel.IsActive = ServiceType3.IsActive;
                ServiceType3ViewModel.TotalViews = ServiceType3.TotalViews;
                ServiceType3ViewModel.Tenant_ID = Convert.ToInt64(ServiceType3.Tenant_ID);
                ServiceType3ViewModel.CreatedBy = ServiceType3.CreatedBy;
                ServiceType3ViewModel.UpdatedBy = ServiceType3.UpdatedBy;
                ServiceType3ViewModel.CreatedOn = ServiceType3.CreatedOn;
                ServiceType3ViewModel.UpdatedOn = ServiceType3.UpdatedOn;
            }
            /*some db operation*/
            // return Json("ajs");
            return ServiceType3ViewModel;
        }

        [Route("api/ServiceType3/GetServiceType3Section4ByTenantIdAndServiceId/{tenantId}/{Id}/{StateFullName}")]
        [HttpGet]
        public List<ServiceType3Section4ViewModel> GetServiceType3Section4ByTenantIdAndServiceId(string tenantId, string Id, string StateFullName)
        {
            // string tenantId = "1";
            var lstServiceType3Section4ViewModel = new List<ServiceType3Section4ViewModel>();
            var state = UnitOfWork.StateMasterRepository.Get().Where(x => x.StateFullName == StateFullName).FirstOrDefault();
            if (state != null)
            {
                var serviceType3Section4 = UnitOfWork.Services3Section4Repository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true && x.State_Id == state.ID).OrderBy(x => x.DisplayIndex);
                foreach (var tempserviceType3Section4 in serviceType3Section4)
                {
                    var serviceType3Section4ViewModel = new ServiceType3Section4ViewModel();
                    serviceType3Section4ViewModel.Heading = tempserviceType3Section4.Heading;
                    serviceType3Section4ViewModel.ShortDescription = tempserviceType3Section4.ShortDescription;
                    serviceType3Section4ViewModel.AncharTagTitle = tempserviceType3Section4.AncharTagTitle;
                    serviceType3Section4ViewModel.AncharTagUrl = tempserviceType3Section4.AncharTagUrl;
                    serviceType3Section4ViewModel.DisplayIndex = tempserviceType3Section4.DisplayIndex;
                    serviceType3Section4ViewModel.IsActive = tempserviceType3Section4.IsActive;
                    serviceType3Section4ViewModel.TotalViews = tempserviceType3Section4.TotalViews;
                    serviceType3Section4ViewModel.Url = tempserviceType3Section4.Url;
                    serviceType3Section4ViewModel.Metadata = tempserviceType3Section4.Metadata;
                    serviceType3Section4ViewModel.Keyword = tempserviceType3Section4.Keyword;
                    serviceType3Section4ViewModel.MetaDescription = tempserviceType3Section4.MetaDescription;
                    serviceType3Section4ViewModel.Tenant_ID = Convert.ToInt64(tempserviceType3Section4.Tenant_ID);
                    lstServiceType3Section4ViewModel.Add(serviceType3Section4ViewModel);
                }
            }
            /*some db operation*/
            // return Json("ajs");
            return lstServiceType3Section4ViewModel;
        }

        [Route("api/ServiceType3/GetServiceType3Section6PriceMasterByTenantIdAndServiceId/{tenantId}/{Id}/{StateFullName}")]
        [HttpGet]
        public List<ServiceType3Section6PriceMasterViewModel> GeServiceType3Section6PriceMasterByTenantIdAndServiceId(string tenantId, string Id, string StateFullName)
        {
            // string tenantId = "1";
            var lstserviceType3Section6PriceMasterViewModel = new List<ServiceType3Section6PriceMasterViewModel>();
            var state = UnitOfWork.StateMasterRepository.Get().Where(x => x.StateFullName == StateFullName).FirstOrDefault();
            if (state != null)
            {
                var serviceType3Section6PriceMaster = UnitOfWork.Services3Section6PriceMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true && x.State_Id == state.ID).OrderBy(x => x.DisplayIndex);
                foreach (var tempserviceType3Section6PriceMaster in serviceType3Section6PriceMaster)
                {
                    var serviceType3Section6PriceMasterViewModel = new ServiceType3Section6PriceMasterViewModel();
                    serviceType3Section6PriceMasterViewModel.SubSubCat_Id = Convert.ToInt64(tempserviceType3Section6PriceMaster.SubSubCat_Id);
                    serviceType3Section6PriceMasterViewModel.State_Id = Convert.ToInt64(tempserviceType3Section6PriceMaster.State_Id);
                    serviceType3Section6PriceMasterViewModel.AncharTagTitle = tempserviceType3Section6PriceMaster.AncharTagTitle;
                    serviceType3Section6PriceMasterViewModel.AncharTagUrl = tempserviceType3Section6PriceMaster.AncharTagUrl;
                    serviceType3Section6PriceMasterViewModel.Heading = tempserviceType3Section6PriceMaster.HeadingText;
                    serviceType3Section6PriceMasterViewModel.Description = tempserviceType3Section6PriceMaster.Description;
                    serviceType3Section6PriceMasterViewModel.Price = Convert.ToInt32(tempserviceType3Section6PriceMaster.Price);
                    serviceType3Section6PriceMasterViewModel.DisplayIndex = tempserviceType3Section6PriceMaster.DisplayIndex;
                    serviceType3Section6PriceMasterViewModel.IsActive = tempserviceType3Section6PriceMaster.IsActive;
                    serviceType3Section6PriceMasterViewModel.TotalViews = tempserviceType3Section6PriceMaster.TotalViews;
                    serviceType3Section6PriceMasterViewModel.Url = tempserviceType3Section6PriceMaster.Url;
                    serviceType3Section6PriceMasterViewModel.Metadata = tempserviceType3Section6PriceMaster.Metadata;
                    serviceType3Section6PriceMasterViewModel.Keyword = tempserviceType3Section6PriceMaster.Keyword;
                    serviceType3Section6PriceMasterViewModel.MetaDescription = tempserviceType3Section6PriceMaster.MetaDescription;
                    serviceType3Section6PriceMasterViewModel.Tenant_ID = Convert.ToInt64(tempserviceType3Section6PriceMaster.Tenant_ID);
                    lstserviceType3Section6PriceMasterViewModel.Add(serviceType3Section6PriceMasterViewModel);
                }
            }
            /*some db operation*/
            // return Json("ajs");
            return lstserviceType3Section6PriceMasterViewModel;
        }


        [Route("api/ServiceType3/GeServiceType3HeadingButtonsByTenantIdAndServiceId/{tenantId}/{Id}")]
        [HttpGet]
        public List<ServicesType3HeadingButtonsViewModel> GeServiceType3HeadingButtonsByTenantIdAndServiceId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstservicesType3HeadingButtonsViewModel = new List<ServicesType3HeadingButtonsViewModel>();
              var serviceType3HeadingButtons = UnitOfWork.Services3HeadingButtonsRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Service_Id == Convert.ToInt64(Id) && x.IsActive == true ).OrderBy(x => x.DisplayIndex);
                foreach (var tempserviceType3HeadingButtons in serviceType3HeadingButtons)
                {
                    var servicesType3HeadingButtonsViewModel = new ServicesType3HeadingButtonsViewModel();
                servicesType3HeadingButtonsViewModel.SubSubCat_Id = Convert.ToInt64(tempserviceType3HeadingButtons.SubSubCat_Id);
                servicesType3HeadingButtonsViewModel.AncharTagTitle = tempserviceType3HeadingButtons.AncharTagTitle;
                servicesType3HeadingButtonsViewModel.AncharTagUrl = tempserviceType3HeadingButtons.AncharTagUrl;
                servicesType3HeadingButtonsViewModel.DisplayIndex = tempserviceType3HeadingButtons.DisplayIndex;
                servicesType3HeadingButtonsViewModel.IsActive = tempserviceType3HeadingButtons.IsActive;
                servicesType3HeadingButtonsViewModel.TotalViews = tempserviceType3HeadingButtons.TotalViews;
                servicesType3HeadingButtonsViewModel.Url = tempserviceType3HeadingButtons.Url;
                servicesType3HeadingButtonsViewModel.Metadata = tempserviceType3HeadingButtons.Metadata;
                servicesType3HeadingButtonsViewModel.Keyword = tempserviceType3HeadingButtons.Keyword;
                servicesType3HeadingButtonsViewModel.MetaDescription = tempserviceType3HeadingButtons.MetaDescription;
                servicesType3HeadingButtonsViewModel.Tenant_ID = Convert.ToInt64(tempserviceType3HeadingButtons.Tenant_ID);
                lstservicesType3HeadingButtonsViewModel.Add(servicesType3HeadingButtonsViewModel);
                }
            
            /*some db operation*/
            // return Json("ajs");
            return lstservicesType3HeadingButtonsViewModel;
        }
        #endregion
    }

}