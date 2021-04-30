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
        [StringLength(20)]
        public string ItemCode { get; set; }
        [StringLength(12)]
        public string DocNo { get; set; }
        [StringLength(2)]
        public string DocType { get; set; }
        public DateTime? DocDate { get; set; }
        [StringLength(6)]
        public string Period { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        [StringLength(5)]
        public string Supplier { get; set; }
        [StringLength(4)]
        public string Location { get; set; }
        [StringLength(20)]
        public string UserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
