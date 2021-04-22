using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM
{
    public class CreateStockClassVM
    {
        [Key]
        [StringLength(15)]
        public string SktClass { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
