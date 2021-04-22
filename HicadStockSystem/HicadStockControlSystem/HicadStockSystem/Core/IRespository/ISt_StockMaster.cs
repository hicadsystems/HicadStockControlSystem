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
        St_StockMaster GetStockByItemCode(string itemCode);
        Task UpdateAsync(St_StockMaster stockMaster);
        Task Delete(string stockMaster);
        IEnumerable<St_StockMaster> GetAllStockMaster();

    }
}
