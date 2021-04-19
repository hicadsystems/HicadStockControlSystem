using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HicadStockSystem.Models
{
    public class Role:IdentityRole<int>
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<RoleMenu> RoleMenus { get; set; }
        [JsonIgnore]
        public ICollection<UserRole> userRoles { get; set; }
    }
}
