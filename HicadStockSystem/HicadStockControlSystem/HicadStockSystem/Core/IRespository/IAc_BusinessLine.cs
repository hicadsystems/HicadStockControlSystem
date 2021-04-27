using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface IAc_BusinessLine
    {
        Task CreateAsync(Ac_BusinessLine businessLine);
        Ac_BusinessLine GetByBusLine(string busLine);
        Task UpdateAsync(Ac_BusinessLine businessLine);
        Task UpdateAsync(string code);
        Task<IEnumerable<Ac_BusinessLine>> GetAll();
        Task DeleteAsync(string busLine);
    }
}
