
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

using SHF.ViewModel.FrontEnd;
using SHF.Web.Filters;

namespace SHF.Controllers.Front
{
   
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
        
        //GET: api/GetAllActiveMenusByTenantId? tenantId = 1
       // [EnableCors]
        [Route("api/Menus/GetAllActiveMenusByTenantId/{tenantId}")]
        [HttpGet]
        public MenusMasterIndexViewModel GetAllActiveMenusByTenantId(string tenantId)
        {
          // string tenantId = "1";
            var MenusMasterIndexViewModel = new MenusMasterIndexViewModel();
            var lstMenusMasterCategoryIndexViewModel = new List<MenusMasterCategoryIndexViewModel>();
            var categories = UnitOfWork.CategoriesMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.DisplayOnHome == true && x.IsActive == true).OrderBy(a => a.DisplayIndex);
            foreach (var tempcat in categories)
            {
                var MenusMasterCategoryIndexViewModel = new MenusMasterCategoryIndexViewModel();
                MenusMasterCategoryIndexViewModel.ID = tempcat.ID;
                MenusMasterCategoryIndexViewModel.Cat_Id = tempcat.ID;
                MenusMasterCategoryIndexViewModel.CategoryName = tempcat.CategoryName;
                MenusMasterCategoryIndexViewModel.DisplayIndex = tempcat.DisplayIndex;
                MenusMasterCategoryIndexViewModel.Tenant_ID = Convert.ToInt64(tempcat.Tenant_ID);
                var lstMenusMasterSubCategoryIndexViewModel = new List<MenusMasterSubCategoryIndexViewModel>();
                var subcategories = UnitOfWork.SubCategoriesMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.DisplayOnHome == true && x.IsActive == true && x.Cat_Id == Convert.ToInt64(tempcat.ID)).OrderBy(a => a.DisplayIndex);
                foreach (var tempsubcat in subcategories)
                {
                    var MenusMasterSubCategoryIndexViewModel = new MenusMasterSubCategoryIndexViewModel();
                    MenusMasterSubCategoryIndexViewModel.ID = tempsubcat.ID;
                    MenusMasterSubCategoryIndexViewModel.SubCategory_ID = tempsubcat.ID;
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
                        MenusMasterSubSubCategoryIndexViewModel.SubSubCategory_ID = tempsubsubcat.ID;
                        MenusMasterSubSubCategoryIndexViewModel.SubSubCategoryName = tempsubsubcat.SubSubCategoryName;
                        MenusMasterSubSubCategoryIndexViewModel.DisplayIndex = tempsubsubcat.DisplayIndex;
                        MenusMasterSubSubCategoryIndexViewModel.ServiceTypeValue = tempsubsubcat.ServiceTypeValue;
                        MenusMasterSubSubCategoryIndexViewModel.url = tempsubsubcat.ServiceTypeValue;
                        MenusMasterSubSubCategoryIndexViewModel.Category_ID = Convert.ToInt64(tempsubsubcat.Cat_Id);
                        MenusMasterSubSubCategoryIndexViewModel.SubCategory_ID = Convert.ToInt64(tempsubsubcat.SubCat_Id);
                        MenusMasterSubSubCategoryIndexViewModel.Tenant_ID = Convert.ToInt64(tempsubsubcat.Tenant_ID);
                        lstMenusMasterSubSubCategoryIndexViewModel.Add(MenusMasterSubSubCategoryIndexViewModel);
                        GetUrlBySubSubCatId(tempsubsubcat, MenusMasterSubSubCategoryIndexViewModel);
                    }
                    MenusMasterSubCategoryIndexViewModel.MenusMasterSubSubCategoryViewModel = lstMenusMasterSubSubCategoryIndexViewModel;
                    lstMenusMasterSubCategoryIndexViewModel.Add(MenusMasterSubCategoryIndexViewModel);
                }
                MenusMasterCategoryIndexViewModel.MenusMasterSubCategoryViewModel = lstMenusMasterSubCategoryIndexViewModel;
                lstMenusMasterCategoryIndexViewModel.Add(MenusMasterCategoryIndexViewModel);

            }
            MenusMasterIndexViewModel.MenusMasterCategoryIndexViewModel = lstMenusMasterCategoryIndexViewModel;
            /*some db operation*/
            // return Json("ajs");
            return MenusMasterIndexViewModel;
        }

        private void GetUrlBySubSubCatId(EntityModel.SubSubCategoriesMaster tempsubsubcat, MenusMasterSubSubCategoryIndexViewModel MenusMasterSubSubCategoryIndexViewModel)
        {
            switch (tempsubsubcat.ServiceTypeValue)
            {
                case "SER1":
                    var service1 = UnitOfWork.Services1MasterRepository.Get().Where(x => x.SubSubCat_Id == tempsubsubcat.ID && x.IsActive == true).FirstOrDefault();
                    if(service1!=null)
                    MenusMasterSubSubCategoryIndexViewModel.url = service1.Url;
                    else
                        MenusMasterSubSubCategoryIndexViewModel.url = "#";
                    break;
                case "SER2":
                    var service2 = UnitOfWork.Services2MasterRepository.Get().Where(x => x.SubSubCat_Id == tempsubsubcat.ID && x.IsActive == true).FirstOrDefault();
                    if (service2 != null)
                        MenusMasterSubSubCategoryIndexViewModel.url = service2.Url;
                    else
                        MenusMasterSubSubCategoryIndexViewModel.url = "#";
                    break;
                case "SER3":
                    var service3 = UnitOfWork.Services3MasterRepository.Get().Where(x => x.SubSubCat_Id == tempsubsubcat.ID && x.IsActive == true).FirstOrDefault();
                    if (service3 != null)
                        MenusMasterSubSubCategoryIndexViewModel.url = service3.Url;
                    else
                        MenusMasterSubSubCategoryIndexViewModel.url = "#";
                    break;
                case "SER4":
                    var service4 = UnitOfWork.Services4MasterRepository.Get().Where(x => x.SubSubCat_Id == tempsubsubcat.ID && x.IsActive == true).FirstOrDefault();
                    if (service4 != null)
                        MenusMasterSubSubCategoryIndexViewModel.url = service4.Url;
                    else
                        MenusMasterSubSubCategoryIndexViewModel.url = "#";
                    break;
                case "SER5":
                    var service5 = UnitOfWork.Services5MasterRepository.Get().Where(x => x.SubSubCat_Id == tempsubsubcat.ID && x.IsActive == true).FirstOrDefault();
                    if (service5 != null)
                        MenusMasterSubSubCategoryIndexViewModel.url = service5.Url;
                    else
                        MenusMasterSubSubCategoryIndexViewModel.url = "#";
                    break;
                case "SER6":
                    var service6 = UnitOfWork.Services6MasterRepository.Get().Where(x => x.SubSubCat_Id == tempsubsubcat.ID && x.IsActive == true).FirstOrDefault();
                    if (service6 != null)
                        MenusMasterSubSubCategoryIndexViewModel.url = service6.Url;
                    else
                        MenusMasterSubSubCategoryIndexViewModel.url = "#";
                    break;
                case "SER7":
                    var service7 = UnitOfWork.Services7MasterRepository.Get().Where(x => x.SubSubCat_Id == tempsubsubcat.ID && x.IsActive == true).FirstOrDefault();
                    if (service7 != null)
                        MenusMasterSubSubCategoryIndexViewModel.url = service7.Url;
                    else
                        MenusMasterSubSubCategoryIndexViewModel.url = "#";
                    break;
                case "SER8":
                    var service8 = UnitOfWork.Services8MasterRepository.Get().Where(x => x.SubSubCat_Id == tempsubsubcat.ID && x.IsActive == true).FirstOrDefault();
                    if (service8 != null)
                        MenusMasterSubSubCategoryIndexViewModel.url = service8.Url;
                    else
                        MenusMasterSubSubCategoryIndexViewModel.url = "#";
                    break;
            }
        }
        #endregion
    }

}