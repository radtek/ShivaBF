
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

using SHF.ViewModel.FrontEnd;
using SHF.Web.Filters;

namespace SHF.Controllers.Front
{

    public class CommonController : ApiController
    {

        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        public CommonController()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
        }
        public CommonController(SHF.DataAccess.Implementations.UnitOfWork unitOfWork, Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
            this.UnitOfWork = unitOfWork;
            this.businessMessage = Imessage;
            this.businessCategoriesMaster = ICategoriesMaster;
            this.businessSubCategoriesMaster = ISubCategoriesMaster;
            this.businessSubSubCategoriesMaster = ISubSubCategoriesMaster;

        }

        //GET: api/GetAllActiveCommonByTenantId? tenantId = 1
        // [EnableCors]
        [Route("api/Common/GetAllActiveStatesByTenantId/{tenantId}")]
        [HttpGet]
        public List<StateMasterViewModel> GetAllActiveStatesByTenantId(string tenantId)
        {
            // string tenantId = "1";
            var lststateMasterViewModel = new List<StateMasterViewModel>();
            var statemaster = UnitOfWork.StateMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) || x.Tenant_ID == null && x.IsActive == true);
            foreach (var tempstate in statemaster)
            {
                var stateMasterViewModel = new StateMasterViewModel();
                stateMasterViewModel.ID = tempstate.ID;
                stateMasterViewModel.StateFullName = tempstate.StateFullName;
                stateMasterViewModel.StateShortName = tempstate.StateShortName;
                stateMasterViewModel.IsActive = tempstate.IsActive;
                stateMasterViewModel.Tenant_ID = Convert.ToInt64(tempstate.Tenant_ID);
                lststateMasterViewModel.Add(stateMasterViewModel);
            }

            /*some db operation*/
            // return Json("ajs");
            return lststateMasterViewModel;
        }

        [Route("api/Common/GetFooterDetailsByTenantId/{tenantId}")]
        [HttpGet]
        public List<FooterBlockMasterViewModel> GetFooterDetailsByTenantId(string tenantId)
        {
            // string tenantId = "1";
            var lstFooterBlockMasterViewModel = new List<FooterBlockMasterViewModel>();
            var footerBlockMaster = UnitOfWork.FooterBlockMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.IsActive == true).OrderBy(x => x.DisplayIndex);

            foreach (var tempfooterBlockMaster in footerBlockMaster)
            {
                var footerBlockMasterViewModel = new FooterBlockMasterViewModel();
                footerBlockMasterViewModel.ID = Convert.ToInt64(tempfooterBlockMaster.ID);
                footerBlockMasterViewModel.Heading = tempfooterBlockMaster.Heading;
                footerBlockMasterViewModel.DisplayIndex = tempfooterBlockMaster.DisplayIndex;
                footerBlockMasterViewModel.Url = tempfooterBlockMaster.Url;
                footerBlockMasterViewModel.Metadata = tempfooterBlockMaster.Metadata;
                footerBlockMasterViewModel.MetaDescription = tempfooterBlockMaster.MetaDescription;
                footerBlockMasterViewModel.Keyword = tempfooterBlockMaster.Keyword;
                footerBlockMasterViewModel.TotalViews = tempfooterBlockMaster.TotalViews;
                footerBlockMasterViewModel.IsActive = tempfooterBlockMaster.IsActive;
                footerBlockMasterViewModel.Tenant_ID = Convert.ToInt64(tempfooterBlockMaster.Tenant_ID);

                var objFooterLinks = UnitOfWork.FooterLinksRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.FooterBlockMaster_Id == Convert.ToInt64(tempfooterBlockMaster.ID) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
                var lstFooterLinksViewModel = new List<FooterLinksViewModel>();

                foreach (var tempFooterLinks in objFooterLinks)
                {
                    var footerLinksViewModel = new FooterLinksViewModel();
                    footerLinksViewModel.FooterBlockMaster_Id = tempFooterLinks.FooterBlockMaster_Id;
                    footerLinksViewModel.AncharTagTitle = tempFooterLinks.AncharTagTitle;
                    footerLinksViewModel.AncharTagUrl = tempFooterLinks.AncharTagUrl;
                    footerLinksViewModel.DisplayIndex = tempFooterLinks.DisplayIndex;
                    footerLinksViewModel.Url = tempFooterLinks.Url;
                    footerLinksViewModel.Metadata = tempFooterLinks.Metadata;
                    footerLinksViewModel.MetaDescription = tempFooterLinks.MetaDescription;
                    footerLinksViewModel.Keyword = tempFooterLinks.Keyword;
                    footerLinksViewModel.TotalViews = tempFooterLinks.TotalViews;
                    footerLinksViewModel.IsActive = tempFooterLinks.IsActive;
                    footerLinksViewModel.Tenant_ID = Convert.ToInt64(tempFooterLinks.Tenant_ID);

                    lstFooterLinksViewModel.Add(footerLinksViewModel);
                }
                footerBlockMasterViewModel.FooterLinksViewModel = lstFooterLinksViewModel;
                lstFooterBlockMasterViewModel.Add(footerBlockMasterViewModel);
            }

            /*some db operation*/
            // return Json("ajs");
            return lstFooterBlockMasterViewModel;
        }

        //GET: api/GetSEODataByTenantIdAndUrl? tenantId = 1
        // [EnableCors]
        [Route("api/Common/GetSEODataByTenantIdAndUrl/{tenantId}/{url}/{page_type}")]
        [HttpGet]
        public CommonSEOViewModel GetSEODataByTenantIdAndUrl(string tenantId, string url, string page_type)
        {
            // string tenantId = "1";
            var commonSEOViewModel = new CommonSEOViewModel();
            //  var dataset;
            switch (page_type)
            {

                case "page1":
                    var dataset1 = UnitOfWork.Services1MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                    if (dataset1 != null)
                    {
                        commonSEOViewModel.ID = dataset1.ID;
                        commonSEOViewModel.PageTitle = dataset1.PageTitle;
                        commonSEOViewModel.Url = dataset1.Url;
                        commonSEOViewModel.Metadata = dataset1.Metadata;
                        commonSEOViewModel.MetaDescription = dataset1.MetaDescription;
                        commonSEOViewModel.Keyword = dataset1.Keyword;

                    }
                    break;
                case "page2":
                    var dataset2 = UnitOfWork.Services2MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                    if (dataset2 != null)
                    {
                        commonSEOViewModel.ID = dataset2.ID;
                        commonSEOViewModel.PageTitle = dataset2.PageTitle;
                        commonSEOViewModel.Url = dataset2.Url;
                        commonSEOViewModel.Metadata = dataset2.Metadata;
                        commonSEOViewModel.MetaDescription = dataset2.MetaDescription;
                        commonSEOViewModel.Keyword = dataset2.Keyword;
                    }
                    break;
                case "page3":
                    var dataset3 = UnitOfWork.Services3MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                    if (dataset3 != null)
                    {
                        commonSEOViewModel.ID = dataset3.ID;
                        commonSEOViewModel.PageTitle = dataset3.PageTitle;
                        commonSEOViewModel.Url = dataset3.Url;
                        commonSEOViewModel.Metadata = dataset3.Metadata;
                        commonSEOViewModel.MetaDescription = dataset3.MetaDescription;
                        commonSEOViewModel.Keyword = dataset3.Keyword;
                    }
                    break;
                case "page4":
                    var dataset4 = UnitOfWork.Services4MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                    if (dataset4 != null)
                    {
                        commonSEOViewModel.ID = dataset4.ID;
                        commonSEOViewModel.PageTitle = dataset4.PageTitle;
                        commonSEOViewModel.Url = dataset4.Url;
                        commonSEOViewModel.Metadata = dataset4.Metadata;
                        commonSEOViewModel.MetaDescription = dataset4.MetaDescription;
                        commonSEOViewModel.Keyword = dataset4.Keyword;
                    }
                    break;
                case "page5":
                    var dataset5 = UnitOfWork.Services5MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                    if (dataset5 != null)
                    {
                        commonSEOViewModel.ID = dataset5.ID;
                        commonSEOViewModel.PageTitle = dataset5.PageTitle;
                        commonSEOViewModel.Url = dataset5.Url;
                        commonSEOViewModel.Metadata = dataset5.Metadata;
                        commonSEOViewModel.MetaDescription = dataset5.MetaDescription;
                        commonSEOViewModel.Keyword = dataset5.Keyword;
                    }
                    break;
                case "page6":
                    var dataset6 = UnitOfWork.Services6MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                    if (dataset6 != null)
                    {
                        commonSEOViewModel.ID = dataset6.ID;
                        commonSEOViewModel.PageTitle = dataset6.PageTitle;
                        commonSEOViewModel.Url = dataset6.Url;
                        commonSEOViewModel.Metadata = dataset6.Metadata;
                        commonSEOViewModel.MetaDescription = dataset6.MetaDescription;
                        commonSEOViewModel.Keyword = dataset6.Keyword;
                    }
                    break;
                case "page7":
                    var dataset7 = UnitOfWork.Services7MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                    if (dataset7 != null)
                    {
                        commonSEOViewModel.ID = dataset7.ID;
                        commonSEOViewModel.PageTitle = dataset7.PageTitle;
                        commonSEOViewModel.Url = dataset7.Url;
                        commonSEOViewModel.Metadata = dataset7.Metadata;
                        commonSEOViewModel.MetaDescription = dataset7.MetaDescription;
                        commonSEOViewModel.Keyword = dataset7.Keyword;
                    }
                    break;
                case "page8":
                    var dataset8 = UnitOfWork.Services8MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                    if (dataset8 != null)
                    {
                        commonSEOViewModel.ID = dataset8.ID;
                        commonSEOViewModel.PageTitle = dataset8.PageTitle;
                        commonSEOViewModel.Url = dataset8.Url;
                        commonSEOViewModel.Metadata = dataset8.Metadata;
                        commonSEOViewModel.MetaDescription = dataset8.MetaDescription;
                        commonSEOViewModel.Keyword = dataset8.Keyword;
                    }
                    break;
                case "blog":
                    var datasetBlog = UnitOfWork.BlogMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                    if (datasetBlog != null)
                    {
                        commonSEOViewModel.ID = datasetBlog.ID;
                        commonSEOViewModel.PageTitle = datasetBlog.PageTitle;
                        commonSEOViewModel.Url = datasetBlog.Url;
                        commonSEOViewModel.Metadata = datasetBlog.Metadata;
                        commonSEOViewModel.MetaDescription = datasetBlog.MetaDescription;
                        commonSEOViewModel.Keyword = datasetBlog.Keyword;
                    }
                    break;
                case "home":
                    var datasetHome = UnitOfWork.HomePageSection2Repository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.IsActive == true).FirstOrDefault();
                    if (datasetHome != null)
                    {
                        commonSEOViewModel.ID = datasetHome.ID;
                        commonSEOViewModel.PageTitle = datasetHome.PageTitle;
                        commonSEOViewModel.Url = datasetHome.Url;
                        commonSEOViewModel.Metadata = datasetHome.Metadata;
                        commonSEOViewModel.MetaDescription = datasetHome.MetaDescription;
                        commonSEOViewModel.Keyword = datasetHome.Keyword;
                    }
                    break;
            }


            /*some db operation*/

            return commonSEOViewModel;
        }




        #endregion
    }

}