using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_costcentre")] 
    public class St_CostCentre
    {
        [Key]
        [StringLength(3)]
        public string UnitCode { get; set; }
        [StringLength(40)]
        public string UnitDesc { get; set; }
        [StringLength(2)]
        public string UnitDiv { get; set; }
        [StringLength(40)]
        public string UnitDivDesc { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
