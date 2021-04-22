using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Models
{
    [Table("st_stksystems")]
    public class St_StkSystem
    {
        [Key]
        [StringLength(20)]
        public string CompanyCode { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(120)]
        public string CompanyAddress { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(60)]
        public string Email { get; set; }
        public StateList StateList { get; set; }
        public byte StateListId { get; set; }
        [StringLength(80)]
        public string Town_City { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime InstallDate { get; set; }
        [StringLength(60)]
        public string SerialNumber { get; set; }
        [StringLength(30)]
        public string GLCode { get; set; }
        
        public int ProcessYear { get; set; }
        public int ProcessMonth { get; set; }
        [StringLength(30)]
        public string ExpenseCode { get; set; }
        [StringLength(30)]
        public string WriteoffLoc { get; set; }
        [StringLength(30)]
        public string CreditorsCode { get; set; }
        [StringLength(2)]
        public string BusLine { get; set; }
        [StringLength(3)]
        public string HoldDays { get; set; }
        [StringLength(3)]
        public string ApprovedDay { get; set; }
        public DateTime? CreatedOn { get; set; } 
        public DateTime? UpdatedOn { get; set; }
        


    }
}
