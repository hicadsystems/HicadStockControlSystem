using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_StockClass
{
    public class UpdateStockClassVM
    {
        [Key]
        [StringLength(30)]
        public string SktClass { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
