using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface ISt_BusinessLine
    {
        Task CreateAsync(St_BusinessLine busLine);
        St_BusinessLine GetByBusLine(string busLine);
        Task UpdateAsync(St_BusinessLine busLine);
        Task UpdateAsync(string busLine);
        Task Delete(string busLine);
        IEnumerable<St_BusinessLine> GetAll();
    }
}
