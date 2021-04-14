using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Models
{
    public class St_StkSystem
    {
        [Key]
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Town_City { get; set; }
        public DateTime InstallDate { get; set; } = DateTime.Now;
        public string SerialNumber { get; set; }
        public string GLCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        //public int ProcessYear { get; set; }
        //public int ProcessMonth { get; set; }
        //public string Expense_code { get; set; }
        //public string Writeoff_loc { get; set; }
        //public string Creditors_code { get; set; }
        //public string BusLine { get; set; }
        //public string HoldDays { get; set; }
        //public string ApprovedDay { get; set; }


    }
}
