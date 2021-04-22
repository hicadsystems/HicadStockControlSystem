using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("  ac_costcentre")]
    public class Ac_CostCentre
    {
        [Key]
        [StringLength(6)]
        public string UnitCode { get; set; }
        [StringLength(80)]
        public string UnitDesc { get; set; }
        [StringLength(4)]
        public string UnitDiv { get; set; }
        [StringLength(80)]
        public string UnitDivDesc { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
