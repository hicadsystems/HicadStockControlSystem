using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    public interface ISt_StockClass
    {
        Task CreateAsync(St_StockClass stockClass);
        St_StockClass GetClassById(string classId);
        //Task UpdateAsync(St_StockClass stockClass);
        Task Delete(string stockClass);
        IEnumerable<St_StockClass> GetAllStkClass();

    }
}
