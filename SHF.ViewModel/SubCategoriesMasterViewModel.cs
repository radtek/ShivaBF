using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
    public sealed class SubCategoriesMasterIndexViewModel : BaseViewModel
    {
        public System.Int64 Id { get; set; }
        public System.String SubCategoryName { get; set; }
        public System.String CategoryName { get; set; }

        public System.Int32 DisplayIndex { get; set; }

        public System.Boolean? DisplayOnHome { get; set; }

        public System.Boolean? IsActive { get; set; }

        public System.Int32 TotalViews { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class SubCategoriesMasterCreateOrEditViewModel : BaseViewModel
    {
        public System.Int64 Id { get; set; }
        public System.String SubCategoryName { get; set; }
        public System.String CategoryName { get; set; }

        public System.Int32 DisplayIndex { get; set; }

        public System.Boolean? DisplayOnHome { get; set; }

        public System.Boolean? IsActive { get; set; }

        public System.Int32 TotalViews { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class SubCategoriesMasterViewModel : BaseViewModel
    {
        public System.String SubCategoryName { get; set; }
        public System.Int64 Cat_Id { get; set; }
        public System.String CategoryName { get; set; }
        public System.Int32 DisplayIndex { get; set; }
       
        public System.Boolean? DisplayOnHome { get; set; }
       
        public System.Boolean? IsActive { get; set; }
       
        public System.Int32 TotalViews { get; set; }
        
    }
}
