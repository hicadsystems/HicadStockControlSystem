using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_stkjournal")]
    public class St_StkJournal
    {
        //remember to input stringLength at ViewModel api resource
        //key
        [StringLength(10)]
        public string Stk_Company { get; set; }
        //key
        [StringLength(4)]
        public string Stk_Branch { get; set; }
        //key
        [StringLength(4)]
        public string Stk_Year { get; set; }
        //key
        [StringLength(2)]
        public string Stk_Month { get; set; }
        //key
        [StringLength(10)]
        public string Stk_Location { get; set; }
        //key
        [StringLength(6)]
        public string Stk_Type { get; set; }
        //key
        [StringLength(30)]
        public string Stk_Account { get; set; }
        
        public decimal? Stk_Debit { get; set; }
        public decimal? Stk_Credit { get; set; }
        [StringLength(60)]
        public string Stk_Rem { get; set; }
        [StringLength(12)]
        public string Stk_Update { get; set; }
        [StringLength(20)]
        public string Stk_Period { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
