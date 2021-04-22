using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_buyerguide")]
    public class St_BuyerGuide
    {
        [Key]
        [StringLength(24)]
        public string ItemCode { get; set; }
        [StringLength(80)]
        public string ItemDesc { get; set; }
        [StringLength(100)]
        public string Supplier1 { get; set; }
        [StringLength(100)]
        public string Supplier2 { get; set; }
        [StringLength(100)]
        public string Supplier3 { get; set; }
        [StringLength(100)]
        public string Supplier4 { get; set; }
        [StringLength(100)]
        public string Supplier5 { get; set; }
        [StringLength(20)]
        public string Code1 { get; set; }
        [StringLength(20)]
        public string Code2 { get; set; }
        [StringLength(20)]
        public string Code3 { get; set; }
        [StringLength(20)]
        public string Code4 { get; set; }
        [StringLength(20)]
        public string Code5 { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
