using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_itemmaster")]
    public class St_ItemMaster
    {
        //[Key]
        [StringLength(15)]
        //uniquely identify items in store
        public string ItemCode { get; set; }
        [StringLength(40)]
        //further decribe item code
        public string ItemDesc { get; set; }
        [StringLength(15)]
        //session where items are located in the store
        public string StoreLoc { get; set; }
        [StringLength(5)]
        //racks in a session that holds the items
        public string Storerack { get; set; }
        [StringLength(5)]
        //bin in a session that holds the item
        public string Storebin { get; set; }
        //min reached qty before new order is placed 
        public int? ReOrderLevel { get; set; }
        //qty to be consumed before new order arrives
        public int? ReOrderQty { get; set; }
        [StringLength(10)]
        //e.g pieces, cartons
        public string Units { get; set; }
        [StringLength(15)]
        //cross reference
        public string XRef { get; set; }
        [StringLength(15)]
        public string Supplier1 { get; set; }
        [StringLength(15)]
        public string Supplier2 { get; set; }
        [StringLength(15)]
        public string Supplier3 { get; set; }
        [StringLength(15)]
        public string Supplier4 { get; set; }
        [StringLength(15)]
        public string Supplier5 { get; set; }
        [StringLength(15)]
        public string Supplier6 { get; set; }
        [StringLength(30)]
        //class description
        public string Class { get; set; }
        [StringLength(2)]
        public string BusLine { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        [StringLength(30)]
        public string PartNo { get; set; }
    }
}
