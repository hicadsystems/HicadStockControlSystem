using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_stockmaster")]
    public class St_StockMaster
    {
        [Key]
        //remember to input stringLength at ViewModel api resource
        [StringLength(6)]
        public string ItemCode { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        //items periodic starting qty
        public float? OpenBalance { get; set; }
        //qty of items received to store
        public float? Receipts { get; set; }
        //qty of items issued out from the store
        public float? Issues { get; set; }
        public decimal? StockPrice { get; set; }
        //stock physical count
        public float? Physical { get; set; }
        public DateTime? LastIssueDate { get; set; }
        public DateTime? LastReceiptDay { get; set; }
        public DateTime? LastPhysicalDate { get; set; }
        //stock position(openBal+Receipt-Issues)
        public float? QtyInTransaction { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }


    }
}
