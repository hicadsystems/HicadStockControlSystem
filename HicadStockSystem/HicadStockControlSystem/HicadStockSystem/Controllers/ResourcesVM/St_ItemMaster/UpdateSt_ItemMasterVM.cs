using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_ItemMaster
{
    public class UpdateSt_ItemMasterVM
    {
        [Required]
        public string ItemCode { get; set; }
        [StringLength(40)]
        public string ItemDesc { get; set; }
        [StringLength(5)]
        public string StoreLoc { get; set; }
        [StringLength(5)]
        public string Storerack { get; set; }
        [StringLength(5)]
        public string Storebin { get; set; }

        public int ReOrderLevel { get; set; }
        public int ReOrderQty { get; set; }
        [StringLength(10)]
        public string Units { get; set; }
        [StringLength(12)]
        //cross reference
        public string XRef { get; set; }
        [StringLength(5)]
        public string Supplier1 { get; set; }
        [StringLength(5)]
        public string Supplier2 { get; set; }
        [StringLength(5)]
        public string Supplier3 { get; set; }
        [StringLength(5)]
        public string Supplier4 { get; set; }
        [StringLength(5)]
        public string Supplier5 { get; set; }
        [StringLength(5)]
        public string Supplier6 { get; set; }
        [StringLength(15)]
        //class description
        public string Class { get; set; }
        [StringLength(2)]
        public string BusLine { get; set; }
        //public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
