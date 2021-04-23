﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_supplier")]
    public class St_Supplier
    {
        [Key]
        [StringLength(6)]
        public string SupplierCode { get; set; }
        [StringLength(10)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(40)]
        public string Contact { get; set; }
        [StringLength(60)]
        public string Phone { get; set; }
        public int? Sup_Last_Num { get; set; }
        public DateTime? Sup_Start_Date { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}