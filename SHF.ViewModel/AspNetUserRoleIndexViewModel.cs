using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{

    public class AspNetUserRoleIndexViewModel : BaseViewModel
    {
        public System.Int64 AspNetUser_ID { get; set; }
        public System.String UserName { get; set; }
        public System.Int64 AspNetRole_ID { get; set; }
        public System.String RoleName { get; set; }
        public System.Int64? Tenant_ID { get; set; }
        public System.String TenantName { get; set; }
    }

    public class AspNetUserRoleCreateOrEditViewModel : BaseViewModel
    {
        public System.Int64 AspNetUser_ID { get; set; }
        public System.Int64 AspNetRole_ID { get; set; }
        public System.Int64? Tenant_ID { get; set; }
    }
}
