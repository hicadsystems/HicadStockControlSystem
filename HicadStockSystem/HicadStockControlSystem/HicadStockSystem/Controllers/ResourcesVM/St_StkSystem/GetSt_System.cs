using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_StkSystem
{
    public class GetSt_System
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //public byte StateListId { get; set; }
        public string State { get; set; }
        public string Town_City { get; set; }
        //public string InstallDate { get; set; }
        public DateTime? InstallDate { get; set; }
        public string SerialNumber { get; set; }
        public string GLCode { get; set; }
        public int? ProcessYear { get; set; }
        public int? ProcessMonth { get; set; }
        public string ExpenseCode { get; set; }
        public string WriteoffLoc { get; set; }
        public string CreditorsCode { get; set; }
        public string BusLine { get; set; }
        public string HoldDays { get; set; }
        public string ApprovedDay { get; set; }
    }
}
