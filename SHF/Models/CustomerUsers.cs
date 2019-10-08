using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class CustomerUsers
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Designation { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }
        public int RoleId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}