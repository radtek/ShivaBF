
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
        public CommonController(SHF.DataAccess.Implementations.UnitOfWork unitOfWork,Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
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
             var statemaster = UnitOfWork.StateMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) || x.Tenant_ID==null && x.IsActive == true);
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

        #endregion
    }

}