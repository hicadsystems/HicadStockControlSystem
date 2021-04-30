using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    public interface ISt_StockClass
    {
        Task CreateAsync(St_StockClass stockClass);
        Task<IEnumerable<St_StockClass>> GetAll();
        St_StockClass GetById(string classId);
        Task DeleteAsync(string classId);

    }
}
