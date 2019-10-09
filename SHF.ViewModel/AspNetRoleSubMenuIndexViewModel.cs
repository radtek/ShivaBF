using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
    public class AspNetRoleSubMenuIndexViewModel : BaseViewModel
    {
        public System.Int64 SubMenu_ID { get; set; }
        public virtual System.String SubMenuName { get; set; }
       
        public System.Int64 AspNetRole_ID { get; set; }
        public System.String AspNetRoleDisplayName { get; set; }

        public System.Int64? Tenant_ID { get; set; }
        public System.String TenantName { get; set; }

        public System.Boolean HasAccess { get; set; }
               
        public System.Boolean? IsActive { get; set; }        
        public System.Int32 UpdateSeq { get; set; }
    }

    public class AspNetRoleSubMenuCreateOrEditViewModel : BaseViewModel
    {        
        public System.Int64 SubMenu_ID { get; set; }                
        public System.Int64 AspNetRole_ID { get; set; }
        public System.Int64? Tenant_ID { get; set; }
        public System.Boolean HasAccess { get; set; }               
        public System.Boolean IsActive { get; set; }                
        public System.Int32 UpdateSeq { get; set; }
    }
}
