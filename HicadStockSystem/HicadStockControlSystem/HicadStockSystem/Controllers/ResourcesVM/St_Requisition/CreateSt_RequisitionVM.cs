using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_Requisition
{
    public class CreateSt_RequisitionVM
    {
        [Required]
        [StringLength(12)]
        public string RequisitionNo { get; set; }
        //key
        [Required]
        [StringLength(12)]
        public string Itemcode { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(5)]
        public string LocationCode { get; set; }
        public float? Quantity { get; set; }
        public DateTime? RequisitionDate { get; set; }
        public DateTime? SupplyDate { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }
        [StringLength(20)]
        public string UserId { get; set; }
        public decimal? SupplyQty { get; set; }
        [StringLength(20)]
        public string SupplyBy { get; set; }
        [StringLength(20)]
        public string ApprovedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
        //public DateTime? UpdatedOn { get; set; }
    }
}
