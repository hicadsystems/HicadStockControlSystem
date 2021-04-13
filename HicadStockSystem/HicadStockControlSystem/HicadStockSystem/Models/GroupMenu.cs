using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HicadStockSystem.Models
{
    public class GroupMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public List<Menu> Menus { get; set; }
    }
}
