using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface ISt_Supplier
    {
        Task CreateAsync(St_Supplier supplier);
        St_Supplier GetByCode(string code);
        Task UpdateAsync(St_Supplier supplier);
        Task UpdateAsync(string code);
        IEnumerable<St_Supplier> GetAll();
        Task DeleteAsync(string code);
    }
}
