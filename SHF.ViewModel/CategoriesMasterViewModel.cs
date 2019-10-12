using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
    public sealed class CategoriesMasterIndexViewModel : BaseViewModel
    {
        public System.Int64 Id { get; set; }
        public System.String CategoryName { get; set; }

        public System.Int32 DisplayIndex { get; set; }

        public System.Boolean? DisplayOnHome { get; set; }

        public System.Boolean? IsActive { get; set; }

        public System.Int32 TotalViews { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class CategoriesMasterCreateOrEditViewModel : BaseViewModel
    {
        public System.Int64 Id { get; set; }
        public System.String CategoryName { get; set; }

        public System.Int32 DisplayIndex { get; set; }

        public System.Boolean? DisplayOnHome { get; set; }

        public System.Boolean? IsActive { get; set; }

        public System.Int32 TotalViews { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class CategoriesMasterViewModel : BaseViewModel
    {
        public System.String CategoryName { get; set; }
        
        public System.Int32 DisplayIndex { get; set; }
       
        public System.Boolean? DisplayOnHome { get; set; }
       
        public System.Boolean? IsActive { get; set; }
       
        public System.Int32 TotalViews { get; set; }
        
    }
}
