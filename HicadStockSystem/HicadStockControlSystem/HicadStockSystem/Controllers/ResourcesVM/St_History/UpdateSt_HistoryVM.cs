using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_IssueApprove
{
    public class UpdateSt_HistoryVM
    {
        //composite key
        //[Required]
        [StringLength(20)]
        public string ItemCode { get; set; }
        //[Required]
        [StringLength(12)]
        public string DocNo { get; set; }
        //[Required]
        [StringLength(2)]
        public string DocType { get; set; }
        public DateTime? DocDate { get; set; }
        [StringLength(6)]
        public string Period { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        [StringLength(15)]
        public string Supplier { get; set; }
        [StringLength(4)]
        public string Location { get; set; }
        [StringLength(20)]
        public string UserId { get; set; }
        //public DateTime? DateCreated { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Remark { get; set; }
        public List<LineItems> LineItems { get; set; }
    }

    public class LineItems
    {
        public string ItemCode { get; set; }
        public int Quantity { get; set; }
        public string Remark { get; set; }
    }
}
