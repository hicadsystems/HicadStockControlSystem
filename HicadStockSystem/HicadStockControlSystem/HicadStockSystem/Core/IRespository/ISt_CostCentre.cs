using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface ISt_CostCentre
    {
        Task CreateAsync(St_CostCentre costCentre);
        St_CostCentre GetByItemCode(string code);
        Task UpdateAsync(string code);
        Task UpdateAsync(St_CostCentre costCentre);
        IEnumerable<St_CostCentre> GetAll();
        Task DeleteAsync(string code);

    }
}
