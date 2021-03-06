using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_issuereq")]
    public class St_IssueRequisition
    {
        //[Key]
        //[StringLength(12)]
        public int Id { get; set; }

        [StringLength(15)]
        public string ItemCode { get; set; }
        [StringLength(25)]
        public string Description { get; set; }
        [StringLength(12)]
        public string DocNo { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? SupplyQty { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
