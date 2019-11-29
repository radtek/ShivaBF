using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_CustomerServiceOrder", Schema = "dbo")]
    public class CustomerServiceOrder : BaseEntity
    {
 
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [ForeignKey("CustomerMaster_ID")]
        public virtual CustomerMaster CustomerMaster { get; set; }
        public System.Int64 CustomerMaster_ID { get; set; }
        [Column("FirstName")]
        public System.String FirstName { get; set; }
        [Column("LastName")]
        public System.String LastName { get; set; }
        [Column("SreetAddress")]
        public System.String SreetAddress { get; set; }
        [Column("City")]
        public System.String City { get; set; }
        [Column("State")]
        public System.String State { get; set; }
        [Column("Country")]
        public System.String Country { get; set; }
        [Column("PostalCode")]
        public System.String PostalCode { get; set; }
        [Column("EmailID")]
        public System.String EmailID { get; set; }
        [Column("DefaultAddressID")]
        public System.Int32 DefaultAddressID { get; set; }
        [Column("Telephone")]
        public System.String Telephone { get; set; }
        [Column("Fax")]
        public System.String Fax { get; set; }
        public System.Int64? Service_Id { get; set; }
        public System.String ServiceName { get; set; }
        public System.Int64 Amount { get; set; }
        public System.String PaymentMethod { get; set; }
        [Column("DatePurchased")]
        public System.DateTime DatePurchased { get; set; }
        public System.String OrdersStatus { get; set; }
        [Column("OrdersDateFinished")]
        public System.DateTime OrdersDateFinished { get; set; }
        public System.String Comments { get; set; }
        
        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }
      
        [ForeignKey("Tenant_ID")]
        public virtual Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }

    }
}