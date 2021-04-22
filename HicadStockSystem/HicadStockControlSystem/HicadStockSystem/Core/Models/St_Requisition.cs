using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_requisition")]
    public class St_Requisition
    {
        //key
        [StringLength(24)]
        public string RequisitionNo { get; set; }
        //key
        [StringLength(24)]
        public string Itemcode { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(10)]
        public string LocationCode { get; set; }
        public float? Quantity { get; set; }
        public DateTime? RequisitionDate { get; set; }
        public DateTime? SupplyDate { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }
        [StringLength(40)]
        public string UserId { get; set; }
        public decimal? SupplyQty { get; set; }
        [StringLength(40)]
        public string SupplyBy { get; set; }
        [StringLength(40)]
        public string ApprovedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
