using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class AddToStockSerialNumberViewModel
    { 
        public List<AddToStockTransaction> AddToStockTransactions { get; set; }
        public List<InventoryMaster> InventoryMaster { get; set; }
    }
}