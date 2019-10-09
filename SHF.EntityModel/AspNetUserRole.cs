using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHF.Helper;

namespace SHF.EntityModel
{
    [Table("AspNetUserRoles", Schema = "dbo")]
    public class AspNetUserRole : BaseEntity
    {

        [ForeignKey("AspNetUser_ID")]
        public AspNetUser AspNetUser { get; set; }
                
        [Key]
        [Column(name: "UserId", Order = 1)]
        public System.Int64 AspNetUser_ID { get; set; }
        
        [ForeignKey("AspNetRole_ID")]
        public AspNetRole AspNetRole { get; set; }
        
        
        [Key]
        [Column(name: "RoleId", Order = 2)]
        public System.Int64 AspNetRole_ID { get; set; }


        [ForeignKey("Tenant_ID")]
        public virtual Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }


    }
}
