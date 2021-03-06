using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.Ac_CostCentre
{
    public class CreateAc_CostCentreVM
    {
        [Required]
        [StringLength(3)]
        public string UnitCode { get; set; }
        [StringLength(40)]
        public string UnitDesc { get; set; }
        [StringLength(2)]
        public string UnitDiv { get; set; }
        [StringLength(40)]
        public string UnitDivDesc { get; set; }
        public DateTime? DateCreated { get; set; }
        //public DateTime? UpdatedOn { get; set; }
    }
}
