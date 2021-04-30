using HicadStockSystem.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    public interface ISt_StockClass : IRespositoryMaster<St_StockClass, string>
    {
        //Task CreateAsync(St_StockClass stockClass);
        //Task<IEnumerable<St_StockClass>> GetAll();
        St_StockClass GetById(string classId);
        //Task DeleteAsync(string classId);

    }
}
