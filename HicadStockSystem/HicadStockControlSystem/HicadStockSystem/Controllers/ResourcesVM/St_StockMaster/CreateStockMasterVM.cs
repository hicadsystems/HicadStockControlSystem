using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_StockMaster
{
    public class CreateStockMasterVM
    {
        [Key]
        //remember to input stringLength at ViewModel api resource
        [StringLength(24)]
        public string ItemCode { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        public float? OpenBalance { get; set; }
        public float? Receipts { get; set; }
        public float? Issues { get; set; }
        public decimal? StockPrice { get; set; }
        public float? Physical { get; set; }
        public DateTime? LastIssueDate { get; set; }
        public DateTime? LastReceiptDay { get; set; }
        public DateTime? LastPhysicalDate { get; set; }
        public float? QtyInTransaction { get; set; }
        public DateTime? CreatedOn { get; set; }
        

    }
}
