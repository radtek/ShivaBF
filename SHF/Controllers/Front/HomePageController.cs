
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

    public class HomePageController : ApiController
    {

        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        public HomePageController()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
        }
        public HomePageController(SHF.DataAccess.Implementations.UnitOfWork unitOfWork, Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
            this.UnitOfWork = unitOfWork;
            this.businessMessage = Imessage;
            this.businessCategoriesMaster = ICategoriesMaster;
            this.businessSubCategoriesMaster = ISubCategoriesMaster;
            this.businessSubSubCategoriesMaster = ISubSubCategoriesMaster;

        }

        //GET: api/GetHomePageBannerByTenantId? tenantId = 1
        // [EnableCors]
        [Route("api/HomePage/GetHomePageBannerByTenantId/{tenantId}")]
        [HttpGet]
        public List<HomePageBannerViewModel> GetHomePageBannerByTenantId(string tenantId)
        {
            // string tenantId = "1";
            var lstHomePageBannerViewModel = new List<HomePageBannerViewModel>();
            var homePageBanner = UnitOfWork.HomePageBannerRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
            foreach (var temphomePageBanner in homePageBanner)
            {
                var homePageBannerViewModel = new HomePageBannerViewModel();
                homePageBannerViewModel.BannerImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, temphomePageBanner.Tenant_ID) + "/" + temphomePageBanner.BannerImagePath;
                homePageBannerViewModel.BannerOnHeading1 = temphomePageBanner.BannerOnHeading1;
                homePageBannerViewModel.BannerOnHeading2 = temphomePageBanner.BannerOnHeading2;
                homePageBannerViewModel.BannerHeadingDescription = temphomePageBanner.BannerHeadingDescription;
                homePageBannerViewModel.AncharTagTitle = temphomePageBanner.AncharTagTitle;
                homePageBannerViewModel.AncharTagUrl = temphomePageBanner.AncharTagUrl;
                homePageBannerViewModel.DisplayIndex = temphomePageBanner.DisplayIndex;
                homePageBannerViewModel.Url = temphomePageBanner.Url;
                homePageBannerViewModel.Metadata = temphomePageBanner.Metadata;
                homePageBannerViewModel.MetaDescription = temphomePageBanner.MetaDescription;
                homePageBannerViewModel.Keyword = temphomePageBanner.Keyword;
                homePageBannerViewModel.TotalViews = temphomePageBanner.TotalViews;
                homePageBannerViewModel.IsActive = temphomePageBanner.IsActive;
                homePageBannerViewModel.Tenant_ID = Convert.ToInt64(temphomePageBanner.Tenant_ID);
                lstHomePageBannerViewModel.Add(homePageBannerViewModel);
            }
            /*some db operation*/
            // return Json("ajs");
            return lstHomePageBannerViewModel;
        }

        //GET: api/GetHomePageSection1ByTenantId? tenantId = 1
        // [EnableCors]
        [Route("api/HomePage/GetHomePageSection1ByTenantId/{tenantId}")]
        [HttpGet]
        public List<HomePageSection1ViewModel> GetHomePageSection1ByTenantId(string tenantId)
        {
            // string tenantId = "1";
            var lstHomePageSection1ViewModel = new List<HomePageSection1ViewModel>();
            var homePageSection1 = UnitOfWork.HomePageSection1Repository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
            foreach (var temphomePageSection1 in homePageSection1)
            {
                var homePageSection1ViewModel = new HomePageSection1ViewModel();
                homePageSection1ViewModel.BannerImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, temphomePageSection1.Tenant_ID) + "/" + temphomePageSection1.BannerImagePath;
                homePageSection1ViewModel.ShortDescription = temphomePageSection1.ShortDescription;
                homePageSection1ViewModel.LongtDescription = temphomePageSection1.LongtDescription;
                homePageSection1ViewModel.AncharTagTitle = temphomePageSection1.AncharTagTitle;
                homePageSection1ViewModel.AncharTagUrl = temphomePageSection1.AncharTagUrl;
                homePageSection1ViewModel.DisplayIndex = temphomePageSection1.DisplayIndex;
                homePageSection1ViewModel.DisplayOnHome = temphomePageSection1.DisplayOnHome;
                homePageSection1ViewModel.Url = temphomePageSection1.Url;
                homePageSection1ViewModel.Metadata = temphomePageSection1.Metadata;
                homePageSection1ViewModel.MetaDescription = temphomePageSection1.MetaDescription;
                homePageSection1ViewModel.Keyword = temphomePageSection1.Keyword;
                homePageSection1ViewModel.TotalViews = temphomePageSection1.TotalViews;
                homePageSection1ViewModel.IsActive = temphomePageSection1.IsActive;
                homePageSection1ViewModel.Tenant_ID = Convert.ToInt64(temphomePageSection1.Tenant_ID);
                lstHomePageSection1ViewModel.Add(homePageSection1ViewModel);
            }
            /*some db operation*/
            // return Json("ajs");
            return lstHomePageSection1ViewModel;
        }

        //GET: api/GetHomePageSection2ByTenantId? tenantId = 1
        // [EnableCors]
        [Route("api/HomePage/GetHomePageSection2ByTenantId/{tenantId}")]
        [HttpGet]
        public HomePageSection2ViewModel GetHomePageSection2ByTenantId(string tenantId)
        {
            // string tenantId = "1";
            var homePageSection2ViewModel = new HomePageSection2ViewModel();
            var homePageSection2 = UnitOfWork.HomePageSection2Repository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.IsActive == true).OrderBy(x => x.DisplayIndex).FirstOrDefault();
            if (homePageSection2.IsNotNull())
            {
                homePageSection2ViewModel.BannerImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, homePageSection2.Tenant_ID) + "/" + homePageSection2.BannerImagePath;
                homePageSection2ViewModel.Heading1 = homePageSection2.Heading1;
                homePageSection2ViewModel.Heading2 = homePageSection2.Heading2;
                homePageSection2ViewModel.Heading3 = homePageSection2.Heading3;
                homePageSection2ViewModel.Description1 = homePageSection2.Description1;
                homePageSection2ViewModel.Description2 = homePageSection2.Description2;
                homePageSection2ViewModel.DisplayIndex = homePageSection2.DisplayIndex;
                homePageSection2ViewModel.DisplayOnHome = homePageSection2.DisplayOnHome;
                homePageSection2ViewModel.Url = homePageSection2.Url;
                homePageSection2ViewModel.Metadata = homePageSection2.Metadata;
                homePageSection2ViewModel.MetaDescription = homePageSection2.MetaDescription;
                homePageSection2ViewModel.Keyword = homePageSection2.Keyword;
                homePageSection2ViewModel.TotalViews = homePageSection2.TotalViews;
                homePageSection2ViewModel.IsActive = homePageSection2.IsActive;
                homePageSection2ViewModel.Tenant_ID = Convert.ToInt64(homePageSection2.Tenant_ID);

            }
            /*some db operation*/
            // return Json("ajs");
            return homePageSection2ViewModel;
        }

        //GET: api/GetHomePageSection2ByTenantId? tenantId = 1
        // [EnableCors]
        [Route("api/HomePage/GetHomePageSection3AndFeaturesByTenantId/{tenantId}")]
        [HttpGet]
        public HomePageSection3ViewModel GetHomePageSection3AndFeaturesByTenantId(string tenantId)
        {
            // string tenantId = "1";
            var homePageSection3ViewModel = new HomePageSection3ViewModel();
            var homePageSection3 = UnitOfWork.HomePageSection3Repository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.IsActive == true).OrderBy(x => x.DisplayIndex).FirstOrDefault();
            if (homePageSection3.IsNotNull())
            {

                homePageSection3ViewModel.BannerImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, homePageSection3.Tenant_ID) + "/" + homePageSection3.BannerImagePath;
                homePageSection3ViewModel.Heading1 = homePageSection3.Heading1;
                homePageSection3ViewModel.Heading2 = homePageSection3.Heading2;
                homePageSection3ViewModel.Heading3 = homePageSection3.Heading3;
                homePageSection3ViewModel.Heading4 = homePageSection3.Heading4;
                homePageSection3ViewModel.DisplayOnHome = homePageSection3.DisplayOnHome;
                homePageSection3ViewModel.DisplayIndex = homePageSection3.DisplayIndex;
                homePageSection3ViewModel.Url = homePageSection3.Url;
                homePageSection3ViewModel.Metadata = homePageSection3.Metadata;
                homePageSection3ViewModel.MetaDescription = homePageSection3.MetaDescription;
                homePageSection3ViewModel.Keyword = homePageSection3.Keyword;
                homePageSection3ViewModel.TotalViews = homePageSection3.TotalViews;
                homePageSection3ViewModel.IsActive = homePageSection3.IsActive;
                homePageSection3ViewModel.Tenant_ID = Convert.ToInt64(homePageSection3.Tenant_ID);

                var lstHomePageSection3FeaturesViewModel = new List<HomePageSection3FeaturesViewModel>();
                var homePageSection3Features = UnitOfWork.HomePageSection3FeaturesRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.HomePageSection3_Id==homePageSection3.ID && x.IsActive == true).OrderBy(x => x.DisplayIndex);
                foreach (var temphomePageSection3Features in homePageSection3Features)
                {
                    var homePageSection3FeaturesViewModel = new HomePageSection3FeaturesViewModel();
                    homePageSection3FeaturesViewModel.ShortDescription = temphomePageSection3Features.ShortDescription;
                    homePageSection3FeaturesViewModel.LongDescription = temphomePageSection3Features.LongDescription;
                    homePageSection3FeaturesViewModel.AncharTagTitle = temphomePageSection3Features.AncharTagTitle;
                    homePageSection3FeaturesViewModel.AncharTagUrl = temphomePageSection3Features.AncharTagUrl;
                    homePageSection3FeaturesViewModel.DisplayIndex = temphomePageSection3Features.DisplayIndex;
                    homePageSection3FeaturesViewModel.Url = temphomePageSection3Features.Url;
                    homePageSection3FeaturesViewModel.Metadata = temphomePageSection3Features.Metadata;
                    homePageSection3FeaturesViewModel.MetaDescription = temphomePageSection3Features.MetaDescription;
                    homePageSection3FeaturesViewModel.Keyword = temphomePageSection3Features.Keyword;
                    homePageSection3FeaturesViewModel.TotalViews = temphomePageSection3Features.TotalViews;
                    homePageSection3FeaturesViewModel.IsActive = temphomePageSection3Features.IsActive;
                    homePageSection3FeaturesViewModel.Tenant_ID = Convert.ToInt64(temphomePageSection3Features.Tenant_ID);
                    lstHomePageSection3FeaturesViewModel.Add(homePageSection3FeaturesViewModel);
                }
                homePageSection3ViewModel.HomePageSection3FeaturesViewModel = lstHomePageSection3FeaturesViewModel;
            }
            /*some db operation*/
            // return Json("ajs");
            return homePageSection3ViewModel;
        }

        //GET: api/GetHomePageSection4TestimonailsByTenantId? tenantId = 1
        // [EnableCors]
        [Route("api/HomePage/GetHomePageSection4TestimonailsByTenantId/{tenantId}")]
        [HttpGet]
        public List<HomePageSection4TestimonailsViewModel> GetHomePageSection4TestimonailsByTenantId(string tenantId)
        {
           
                var lstHomePageSection4TestimonailsViewModel = new List<HomePageSection4TestimonailsViewModel>();
                var homePageSection4Testimonails = UnitOfWork.HomePageSection4TestimonailsRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
                foreach (var temphomePageSection4Testimonails in homePageSection4Testimonails)
                {
                    var homePageSection4TestimonailsViewModel = new HomePageSection4TestimonailsViewModel();
                    homePageSection4TestimonailsViewModel.Description = temphomePageSection4Testimonails.Description;
                    homePageSection4TestimonailsViewModel.Name = temphomePageSection4Testimonails.Name;
                    homePageSection4TestimonailsViewModel.Designation = temphomePageSection4Testimonails.Designation;
                    homePageSection4TestimonailsViewModel.DisplayIndex = temphomePageSection4Testimonails.DisplayIndex;
                    homePageSection4TestimonailsViewModel.Url = temphomePageSection4Testimonails.Url;
                    homePageSection4TestimonailsViewModel.Metadata = temphomePageSection4Testimonails.Metadata;
                    homePageSection4TestimonailsViewModel.MetaDescription = temphomePageSection4Testimonails.MetaDescription;
                    homePageSection4TestimonailsViewModel.Keyword = temphomePageSection4Testimonails.Keyword;
                    homePageSection4TestimonailsViewModel.TotalViews = temphomePageSection4Testimonails.TotalViews;
                    homePageSection4TestimonailsViewModel.IsActive = temphomePageSection4Testimonails.IsActive;
                    homePageSection4TestimonailsViewModel.Tenant_ID = Convert.ToInt64(temphomePageSection4Testimonails.Tenant_ID);
                    lstHomePageSection4TestimonailsViewModel.Add(homePageSection4TestimonailsViewModel);
                }
              
            /*some db operation*/
            // return Json("ajs");
            return lstHomePageSection4TestimonailsViewModel;
        }

        //GET: api/GetHomePageSection4AndSection5ByTenantId? tenantId = 1
        // [EnableCors]
        [Route("api/HomePage/GetHomePageSection4AndSection5ByTenantId/{tenantId}")]
        [HttpGet]
        public HomePageSection4ViewModel GetHomePageSection4AndSection5ByTenantId(string tenantId)
        {
            // string tenantId = "1";
            var homePageSection4ViewModel = new HomePageSection4ViewModel();
            var homePageSection4 = UnitOfWork.HomePageSection4Repository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.IsActive == true).OrderBy(x => x.DisplayIndex).FirstOrDefault();
            if (homePageSection4.IsNotNull())
            {

                homePageSection4ViewModel.BannerImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, homePageSection4.Tenant_ID) + "/" + homePageSection4.BannerImagePath;
                homePageSection4ViewModel.Heading1 = homePageSection4.Heading1;
                homePageSection4ViewModel.Heading2 = homePageSection4.Heading2;
                homePageSection4ViewModel.DisplayIndex = homePageSection4.DisplayIndex;
                homePageSection4ViewModel.Url = homePageSection4.Url;
                homePageSection4ViewModel.Metadata = homePageSection4.Metadata;
                homePageSection4ViewModel.MetaDescription = homePageSection4.MetaDescription;
                homePageSection4ViewModel.Keyword = homePageSection4.Keyword;
                homePageSection4ViewModel.TotalViews = homePageSection4.TotalViews;
                homePageSection4ViewModel.IsActive = homePageSection4.IsActive;
                homePageSection4ViewModel.Tenant_ID = Convert.ToInt64(homePageSection4.Tenant_ID);

                var lstHomePageSection5ViewModel = new List<HomePageSection5ViewModel>();
                var homePageSection5 = UnitOfWork.HomePageSection5Repository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
                foreach (var temphomePageSection5 in homePageSection5)
                {
                    var homePageSection5ViewModel = new HomePageSection5ViewModel();
                    homePageSection5ViewModel.ImageFilePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, temphomePageSection5.Tenant_ID) + "/" + temphomePageSection5.ImageFilePath;
                    homePageSection5ViewModel.ShortDescription = temphomePageSection5.ShortDescription;
                    homePageSection5ViewModel.LongDescription = temphomePageSection5.LongDescription;
                    homePageSection5ViewModel.AncharTagTitle = temphomePageSection5.AncharTagTitle;
                    homePageSection5ViewModel.AncharTagUrl = temphomePageSection5.AncharTagUrl;
                    homePageSection5ViewModel.DisplayIndex = temphomePageSection5.DisplayIndex;
                    homePageSection5ViewModel.Url = temphomePageSection5.Url;
                    homePageSection5ViewModel.Metadata = temphomePageSection5.Metadata;
                    homePageSection5ViewModel.MetaDescription = temphomePageSection5.MetaDescription;
                    homePageSection5ViewModel.Keyword = temphomePageSection5.Keyword;
                    homePageSection5ViewModel.TotalViews = temphomePageSection5.TotalViews;
                    homePageSection5ViewModel.IsActive = temphomePageSection5.IsActive;
                    homePageSection5ViewModel.Tenant_ID = Convert.ToInt64(temphomePageSection5.Tenant_ID);
                    lstHomePageSection5ViewModel.Add(homePageSection5ViewModel);
                }
                homePageSection4ViewModel.HomePageSection5ViewModel = lstHomePageSection5ViewModel;
            }
            /*some db operation*/
            // return Json("ajs");
            return homePageSection4ViewModel;
        }
        #endregion
    }

}