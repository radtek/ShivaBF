using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHF.ViewModel.FrontEnd
{

    public sealed class MenusMasterIndexViewModel : BaseViewModel
    {


        public List<ViewModel.FrontEnd.MenusMasterCategoryIndexViewModel> MenusMasterCategoryIndexViewModel { get; set; }
    }
    public sealed class MenusMasterCategoryIndexViewModel : BaseViewModel
    {

      
        public System.Int64 Cat_Id { get; set; }
        public System.String CategoryName { get; set; }
         public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? DisplayOnHome { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
        public List<ViewModel.FrontEnd.MenusMasterSubCategoryIndexViewModel> MenusMasterSubCategoryViewModel { get; set; }
    }
    public sealed class MenusMasterSubCategoryIndexViewModel : BaseViewModel
    {
        public System.Int64 SubCategory_ID { get; set; }
        public System.String SubCategoryName { get; set; }
        public System.Int64 Category_ID { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Int64 Tenant_ID { get; set; }
        public List<ViewModel.FrontEnd.MenusMasterSubSubCategoryIndexViewModel> MenusMasterSubSubCategoryViewModel { get; set; }
    }

    public sealed class MenusMasterSubSubCategoryIndexViewModel : BaseViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 SubSubCategory_ID { get; set; }
        public System.Int64 SubCategory_ID { get; set; }
        public System.Int64 Category_ID { get; set; }
        public System.String ServiceTypeValue { get; set; }
        public System.String url { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
}

