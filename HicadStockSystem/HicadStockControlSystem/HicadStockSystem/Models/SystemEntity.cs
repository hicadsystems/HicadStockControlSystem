using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Models
{
    public class SystemEntity
    {
        [Key]
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string TelephoneNo { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string TownCity { get; set; }
        public DateTime InstallationDate { get; set; }
        public string SerialNumber { get; set; }
        public string StockGLCode { get; set; }
    }
}
