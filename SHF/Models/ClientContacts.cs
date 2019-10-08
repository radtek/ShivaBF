﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class ClientContacts
    {
        [Key]
        public int ClientContactsId { get; set; }
        public int ClientId { get; set; }
        public string Address { get; set; } 
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}