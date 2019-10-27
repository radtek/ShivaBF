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


namespace SHF.API.Controllers
{
    public class MenusController : ApiController
    {
        #region [Field & Contructor]

        private readonly Business.Interface.IMessage businessMessage;
        private readonly Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private readonly Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private readonly Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        //public MenusController()
        //{ 

        //}
        public MenusController(Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
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
            var categories1 = businessCategoriesMaster.GetAll();
            var categories = businessCategoriesMaster.GetAll().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.DisplayOnHome == true && x.IsActive == true).OrderBy(a => a.DisplayIndex);
            foreach (var tempcat in categories)
            {
                var MenusMasterCategoryIndexViewModel = new MenusMasterCategoryIndexViewModel();
                MenusMasterCategoryIndexViewModel.ID = tempcat.ID;
                MenusMasterCategoryIndexViewModel.CategoryName = tempcat.CategoryName;
                MenusMasterCategoryIndexViewModel.DisplayIndex = tempcat.DisplayIndex;
                MenusMasterCategoryIndexViewModel.Tenant_ID = Convert.ToInt64(tempcat.Tenant_ID);
                MenusMasterIndexViewModel.MenusMasterCategoryIndexViewModel.Add(MenusMasterCategoryIndexViewModel);
                var subcategories = this.businessSubCategoriesMaster.GetAll().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.DisplayOnHome == true && x.IsActive == true && x.Cat_Id == Convert.ToInt64(tempcat.ID)).OrderBy(a => a.DisplayIndex);
                foreach (var tempsubcat in subcategories)
                {
                    var MenusMasterSubCategoryIndexViewModel = new MenusMasterSubCategoryIndexViewModel();
                    MenusMasterSubCategoryIndexViewModel.ID = tempsubcat.ID;
                    MenusMasterSubCategoryIndexViewModel.SubCategoryName = tempsubcat.SubCategoryName;
                    MenusMasterSubCategoryIndexViewModel.DisplayIndex = tempsubcat.DisplayIndex;
                    MenusMasterSubCategoryIndexViewModel.Category_ID = Convert.ToInt64(tempsubcat.Cat_Id);
                    MenusMasterSubCategoryIndexViewModel.Tenant_ID = Convert.ToInt64(tempsubcat.Tenant_ID);
                    MenusMasterCategoryIndexViewModel.MenusMasterSubCategoryViewModel.Add(MenusMasterSubCategoryIndexViewModel);
                    var subsubcategories = this.businessSubSubCategoriesMaster.GetAll().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.DisplayOnHome == true && x.IsActive == true && x.SubCat_Id == Convert.ToInt64(tempsubcat.ID)).OrderBy(a => a.DisplayIndex);
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
                        MenusMasterSubCategoryIndexViewModel.MenusMasterSubSubCategoryViewModel.Add(MenusMasterSubSubCategoryIndexViewModel);

                    }
                }

            }
            /*some db operation*/
            return Json(MenusMasterIndexViewModel);
        }
        #endregion
    }

}