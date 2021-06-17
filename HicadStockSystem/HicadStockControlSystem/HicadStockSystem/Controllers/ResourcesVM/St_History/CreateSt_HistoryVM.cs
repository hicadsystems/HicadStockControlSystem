using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_History
{
    public class CreateSt_HistoryVM
    {
        [StringLength(20)]
        public string ItemCode { get; set; }
        [StringLength(12)]
        public string DocNo { get; set; }
        [StringLength(3)]
        public string DocType { get; set; }
        public DateTime? DocDate { get; set; }
        [StringLength(6)]
        public string Period { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        [StringLength(15)]
        public string Supplier { get; set; }
        [StringLength(4)]
        public string Location { get; set; }
        [StringLength(20)]
        public string UserId { get; set; }
        public DateTime? DateCreated { get; set; }
        //public DateTime? UpdatedOn { get; set; }
    }
}
