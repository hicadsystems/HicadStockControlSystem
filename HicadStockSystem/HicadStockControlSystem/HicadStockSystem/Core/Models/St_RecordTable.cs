using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_recordtable")]
    public class St_RecordTable
    {
        [Key]
        [StringLength(5)]
        public string Code { get; set; }

        public int ReturnsNo { get; set; }
        public int RequsitionNo { get; set; }
        public int ReceiptNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
