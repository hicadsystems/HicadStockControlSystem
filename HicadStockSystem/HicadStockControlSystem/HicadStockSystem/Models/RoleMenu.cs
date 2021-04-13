using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HicadStockSystem.Models
{
    public class RoleMenu
    {
        public int Id { get; set; }
        public Menu  Menu { get; set; }
        public int MenuId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
