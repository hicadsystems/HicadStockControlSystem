using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_StkSystem
{
    public class UpdateSt_StkSystemVM
    {
       [Required]
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Town_City { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime InstallDate { get; }
        public string SerialNumber { get; }
        public string GLCode { get; }
        public int ProcessYear { get; }
        public int ProcessMonth { get; }
        public string ExpenseCode { get; }
        public string WriteoffLoc { get; }
        public string CreditorsCode { get; }
        public string BusLine { get; }
        public string HoldDays { get; set; }
        public string ApprovedDay { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
