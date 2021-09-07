using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HicadStockSystem.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public GroupMenu GroupMenu { get; set; }
        public int GroupMenuId { get; set; }
        [JsonIgnore]
        public List<RoleMenu> RoleMenus { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
