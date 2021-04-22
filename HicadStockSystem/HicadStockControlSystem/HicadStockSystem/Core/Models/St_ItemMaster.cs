using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_itemmaster")]
    public class St_ItemMaster
    {
        [Key]
        [StringLength(12)]
        public string ItemCode { get; set; }
        [StringLength(80)]
        public string ItemDesc { get; set; }
        [StringLength(10)]
        public string StoreLoc { get; set; }
        [StringLength(10)]
        public string Storerack { get; set; }
        [StringLength(10)]
        public string Storebin { get; set; }

        public int ReOrderLevel { get; set; }
        public int ReOrderQty { get; set; }
        [StringLength(20)]
        public string Units { get; set; }
        [StringLength(24)]
        public string XRef { get; set; }
        [StringLength(10)]
        public string Supplier1 { get; set; }
        [StringLength(10)]
        public string Supplier2 { get; set; }
        [StringLength(10)]
        public string Supplier3 { get; set; }
        [StringLength(10)]
        public string Supplier4 { get; set; }
        [StringLength(10)]
        public string Supplier5 { get; set; }
        [StringLength(10)]
        public string Supplier6 { get; set; }
        [StringLength(30)]
        public string Class { get; set; }
        [StringLength(2)]
        public string BusLine { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
