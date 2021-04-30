using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface ISt_ItemMaster
    {
        Task CreateAsync(St_ItemMaster itemMaster);
        St_ItemMaster GetByCode(string itemCode);
        Task UpdateAsync(St_ItemMaster itemMaster);
        Task UpdateAsync(string code);
        Task<IEnumerable<St_ItemMaster>> GetAll();
        Task DeleteAsync(string itemCode);
        Task<IEnumerable<string>> GetStockClass();
       Task<IEnumerable<string>> GetBusinessLine();
    }
}
