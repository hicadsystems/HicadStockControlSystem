using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.Ac_BusinessLine
{
    public class UpdateAc_BusinessLineVM
    {
        [Required]
        [StringLength(2)]
        public string BusinessLine { get; set; }
        [StringLength(40)]
        public string BusinessDesc { get; set; }
        [StringLength(6)]
        public string Status { get; set; }
        [StringLength(4)]
        public string Business_Year { get; set; }
        [StringLength(2)]
        public string Business_Month { get; set; }
        [StringLength(15)]
        public string Cashier_Ac { get; set; }
        //public DateTime? DateCreated { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
