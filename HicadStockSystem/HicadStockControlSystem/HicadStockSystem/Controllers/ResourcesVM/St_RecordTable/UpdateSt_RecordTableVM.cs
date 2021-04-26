using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_RecordTable
{
    public class UpdateSt_RecordTableVM
    {
        [Required]
        [StringLength(5)]
        public string Code { get; set; }
        public int RequsitionNo { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
