using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core
{
    public interface ISt_StockMaster 
    {
        Task CreateAsync(St_StockMaster stockMaster);
        St_StockMaster GetByItemCode(string itemCode);
        Task UpdateAsync(St_StockMaster stockMaster);
        Task UpdateAsync(string itemCode);
        Task Delete(string itemCode);
        Task<IEnumerable<St_StockMaster>> GetAll();
    }
}
