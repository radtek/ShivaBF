using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Reflection;
using System.ComponentModel;
using System.Web.Http.Results;
using SHF.ViewModel.FrontEnd;

namespace SHF.Controllers.Front
{
    [AllowAnonymous]
    public class MenusController : ApiController
    {

        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        public MenusController()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
        }
        public MenusController(SHF.DataAccess.Implementations.UnitOfWork unitOfWork,Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
            this.UnitOfWork = unitOfWork;
            this.businessMessage = Imessage;
            this.businessCategoriesMaster = ICategoriesMaster;
            this.businessSubCategoriesMaster = ISubCategoriesMaster;
            this.businessSubSubCategoriesMaster = ISubSubCategoriesMaster;

        }
        // GET: api/GetAllActiveMenusByTenantId?tenantId=1
        [HttpGet]
        [Route("api/GetAllActiveMenusByTenantId")]
        public JsonResult<MenusMasterIndexViewModel> GetAllActiveMenusByTenantId(string tenantId)
        {
           
            var MenusMasterIndexViewModel = new MenusMasterIndexViewModel();
            var lstMenusMasterCategoryIndexViewModel = new List<MenusMasterCategoryIndexViewModel>();
            var categories = UnitOfWork.CategoriesMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.DisplayOnHome == true && x.IsActive == true).OrderBy(a => a.DisplayIndex);
            foreach (var tempcat in categories)
            {
                var MenusMasterCategoryIndexViewModel = new MenusMasterCategoryIndexViewModel();
                MenusMasterCategoryIndexViewModel.ID = tempcat.ID;
                MenusMasterCategoryIndexViewModel.CategoryName = tempcat.CategoryName;
                MenusMasterCategoryIndexViewModel.DisplayIndex = tempcat.DisplayIndex;
                MenusMasterCategoryIndexViewModel.Tenant_ID = Convert.ToInt64(tempcat.Tenant_ID);
                var lstMenusMasterSubCategoryIndexViewModel = new List<MenusMasterSubCategoryIndexViewModel>();
                var subcategories = UnitOfWork.SubCategoriesMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.DisplayOnHome == true && x.IsActive == true && x.Cat_Id == Convert.ToInt64(tempcat.ID)).OrderBy(a => a.DisplayIndex);
                foreach (var tempsubcat in subcategories)
                {
                    var MenusMasterSubCategoryIndexViewModel = new MenusMasterSubCategoryIndexViewModel();
                    MenusMasterSubCategoryIndexViewModel.ID = tempsubcat.ID;
                    MenusMasterSubCategoryIndexViewModel.SubCategoryName = tempsubcat.SubCategoryName;
                    MenusMasterSubCategoryIndexViewModel.DisplayIndex = tempsubcat.DisplayIndex;
                    MenusMasterSubCategoryIndexViewModel.Category_ID = Convert.ToInt64(tempsubcat.Cat_Id);
                    MenusMasterSubCategoryIndexViewModel.Tenant_ID = Convert.ToInt64(tempsubcat.Tenant_ID);
                    //MenusMasterCategoryIndexViewModel.MenusMasterSubCategoryViewModel.Add(MenusMasterSubCategoryIndexViewModel);
                    var subsubcategories = UnitOfWork.SubSubCategoriesMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.DisplayOnHome == true && x.IsActive == true && x.SubCat_Id == Convert.ToInt64(tempsubcat.ID)).OrderBy(a => a.DisplayIndex);
                    var lstMenusMasterSubSubCategoryIndexViewModel = new List<MenusMasterSubSubCategoryIndexViewModel>();
                    foreach (var tempsubsubcat in subsubcategories)
                    {
                        var MenusMasterSubSubCategoryIndexViewModel = new MenusMasterSubSubCategoryIndexViewModel();
                        MenusMasterSubSubCategoryIndexViewModel.ID = tempsubsubcat.ID;
                        MenusMasterSubSubCategoryIndexViewModel.SubSubCategoryName = tempsubsubcat.SubSubCategoryName;
                        MenusMasterSubSubCategoryIndexViewModel.DisplayIndex = tempsubsubcat.DisplayIndex;
                        MenusMasterSubSubCategoryIndexViewModel.ServiceTypeValue = tempsubsubcat.ServiceTypeValue;
                        MenusMasterSubSubCategoryIndexViewModel.Category_ID = Convert.ToInt64(tempsubsubcat.Cat_Id);
                        MenusMasterSubSubCategoryIndexViewModel.SubCategory_ID = Convert.ToInt64(tempsubsubcat.SubCat_Id);
                        MenusMasterSubSubCategoryIndexViewModel.Tenant_ID = Convert.ToInt64(tempsubsubcat.Tenant_ID);
                        lstMenusMasterSubSubCategoryIndexViewModel.Add(MenusMasterSubSubCategoryIndexViewModel);

                    }
                    MenusMasterSubCategoryIndexViewModel.MenusMasterSubSubCategoryViewModel = lstMenusMasterSubSubCategoryIndexViewModel;
                    lstMenusMasterSubCategoryIndexViewModel.Add(MenusMasterSubCategoryIndexViewModel);
                }
                MenusMasterCategoryIndexViewModel.MenusMasterSubCategoryViewModel = lstMenusMasterSubCategoryIndexViewModel;
                lstMenusMasterCategoryIndexViewModel.Add(MenusMasterCategoryIndexViewModel);

            }
            MenusMasterIndexViewModel.MenusMasterCategoryIndexViewModel = lstMenusMasterCategoryIndexViewModel;
            /*some db operation*/
            return Json(MenusMasterIndexViewModel);
        }
        #endregion
    }

}