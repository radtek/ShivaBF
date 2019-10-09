
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHF.Helper;

namespace SHF.ViewModel
{
    public sealed class AspNetRoleIndexViewModel : BaseViewModel
    {
        public System.String Name { get; set; }
        public System.String DisplayName { get; set; }
        public System.Boolean IsActive { get; set; }
        public System.Int32 UpdateSeq { get; set; }
        public System.Int64? Tenant_ID { get; set; }
        public System.String TenantName { get; set; }
    }

    public sealed class AspNetRoleCreateOrEditViewModel : BaseViewModel
    {
        public System.String Name { get; set; }

        [Required(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String DisplayName { get; set; }
        public System.Boolean IsActive { get; set; }
        public System.Int32 UpdateSeq { get; set; }
        public System.Int64? Tenant_ID { get; set; }
    }

    public sealed class AspNetRoleDropDownListViewModel : BaseViewModel
    {
        public System.String Name { get; set; }
    }

}
