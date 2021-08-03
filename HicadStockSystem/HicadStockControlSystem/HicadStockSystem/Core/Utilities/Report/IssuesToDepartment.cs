using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities
{
    public class IssuesToDepartment
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string DocNo { get; set; }
        public string DocDate { get; set; }
        public string ItemDescription { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


    }
}
