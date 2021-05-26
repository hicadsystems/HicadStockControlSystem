using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_Supplier
{
    public class UpdateSt_SupplierVM
    {
        [Required]
        [StringLength(3, ErrorMessage ="character length can not exceeded 3")]
        public string SupplierCode { get; set; }
        [StringLength(50, ErrorMessage = "character length can not exceeded 5")]
        public string Name { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(15)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Contact { get; set; }
        [StringLength(30)]
        public string Phone { get; set; }
        public int? Sup_Last_Num { get; set; }
        public DateTime? Sup_Start_Date { get; set; }
        public DateTime? DateCreated { get; set; }

    }
}
