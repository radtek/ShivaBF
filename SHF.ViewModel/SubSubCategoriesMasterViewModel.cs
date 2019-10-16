using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
  
    public sealed class SubSubCategoriesMasterIndexViewModel : BaseViewModel
    {

        public System.String SubSubCategoryName { get; set; }
        public System.Int64 Cat_Id { get; set; }
        public System.String CategoryName { get; set; }
        public System.Int64 SubCat_Id { get; set; }
        public System.String SubCategoryName { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? DisplayOnHome { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.String ServiceType { get; set; }
        public System.Int32 TotalViews { get; set; }

        public string Url { get; set; }


        public string Metadata { get; set; }


        public string Keyword { get; set; }


        public string MetaDescription { get; set; }

        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class SubSubCategoriesMasterCreateOrEditViewModel : BaseViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 SubCategory_ID { get; set; }
        public System.String SubCategoryName { get; set; }
        public System.Int64 Category_ID { get; set; }
        public System.String CategoryName { get; set; }

        public System.Int32 DisplayIndex { get; set; }

        public System.Boolean? DisplayOnHome { get; set; }

        public System.Boolean? IsActive { get; set; }

        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }


        public string Metadata { get; set; }


        public string Keyword { get; set; }


        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
  
    public class SubSubCategoriesDropdownListViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 ID { get; set; }

    }
}

