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
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyAddress { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public byte StateListId { get; set; }
        public string Town_City { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime InstallDate { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public string GLCode { get; set; }
        [Required]
        public int ProcessYear { get; set; }
        [Required]
        public int ProcessMonth { get; set; }
        [Required]
        public string ExpenseCode { get; set; }
        [Required]
        public string WriteoffLoc { get; set; }
        [Required]
        public string CreditorsCode { get; set; }
        public string BusLine { get; set; }
        public string HoldDays { get; set; }
        public string ApprovedDay { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
