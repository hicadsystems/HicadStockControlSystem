using HicadStockSystem.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_Requisition
{
    public class UpdateSt_RequisitionVM
    {
        [Required]
        [StringLength(12)]
        public string RequisitionNo { get; set; }
        //key
        //[Required]
        //[StringLength(15)]
        //public string ItemCode { get; set; }
        //[StringLength(50)]
        //public string Description { get; set; }
        //[StringLength(5)]
        //public string LocationCode { get; set; }
        //public float? Quantity { get; set; }
        //public DateTime? RequisitionDate { get; set; }
        //public DateTime? SupplyDate { get; set; }
        //public string Unit { get; set; }
        //public decimal? Price { get; set; }
        //[StringLength(20)]
        //public string UserId { get; set; }
        //public decimal? SupplyQty { get; set; }
        //[StringLength(20)]
        //public string SupplyBy { get; set; }
        //[StringLength(20)]
        //public string ApprovedBy { get; set; }
        //public bool IsSupplied { get; set; }

        //public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public List<ItemListVM> ItemLists { get; set; }
        public List<UnApprovedItemVM> UnApprovedItems { get; set; }

    }

    public class UnApprovedItemVM
    {
        public string ItemCode { get; set; }
        //public float? Requested { get; set; }
        public string Unit { get; set; }
        public string ItemDescription { get; set; }
        public decimal? Quantity { get; set; }
    }
}
