
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using SHF.ViewModel;
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
        #endregion
    }

}