using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_history")]
    public class St_History
    {
        //composite key
        [StringLength(40)]
        public string ItemCode { get; set; }
        [StringLength(24)]
        public string DocNo { get; set; }
        [StringLength(4)]
        public string DocType { get; set; }
        public DateTime? DocDate { get; set; }
        public string Period { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        [StringLength(10)]
        public string Supplier { get; set; }
        [StringLength(8)]
        public string Location { get; set; }
        [StringLength(40)]
        public string UserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
