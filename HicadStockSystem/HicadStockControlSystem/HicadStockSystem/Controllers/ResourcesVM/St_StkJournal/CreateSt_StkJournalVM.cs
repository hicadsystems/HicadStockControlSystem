using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_StkJournal
{
    public class CreateSt_StkJournalVM
    {
        [Required]
        [StringLength(5)]
        public string Stk_Company { get; set; }
        [Required]
        [StringLength(2)]
        public string Stk_Branch { get; set; }
        [Required]
        [StringLength(4)]
        public string Stk_Year { get; set; }
        [Required]
        [StringLength(2)]
        public string Stk_Month { get; set; }
        [Required]
        [StringLength(5)]
        public string Stk_Location { get; set; }
        [Required]
        [StringLength(3)]
        public string Stk_Type { get; set; }
        [Required]
        [StringLength(15)]
        public string Stk_Account { get; set; }

        public decimal? Stk_Debit { get; set; }
        public decimal? Stk_Credit { get; set; }
        [StringLength(30)]
        public string Stk_Rem { get; set; }
        [StringLength(6)]
        public string Stk_Update { get; set; }
        [StringLength(10)]
        public string Stk_Period { get; set; }
        public DateTime? CreatedOn { get; set; }
        //public DateTime? UpdatedOn { get; set; }
    }
}
