using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
  
    [Table("  st_businessline")]
    public class St_BusinessLine
    {
        [Key]
        [StringLength(4)]
        public string BusinessLine { get; set; }
        [StringLength(80)]
        public string BusinessDesc { get; set; }
        [StringLength(12)]
        public string Status { get; set; }
        [StringLength(8)]
        public string Business_Year { get; set; }
        [StringLength(2)]
        public string Business_Month { get; set; }
        [StringLength(30)]
        public string Cashier_Ac { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
