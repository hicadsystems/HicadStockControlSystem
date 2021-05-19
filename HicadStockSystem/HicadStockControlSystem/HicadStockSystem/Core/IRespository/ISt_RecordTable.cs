using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface ISt_RecordTable 
    {
        Task CreateAsync(St_RecordTable recordTable);
        St_RecordTable GetByCode(string code);
        Task UpdateAsync(St_RecordTable recordTable);
        Task UpdateAsync(string code);
        Task<IEnumerable<St_RecordTable>> GetAll();
        Task DeleteAsync(string code);
        //St_RecordTable GetByDocCode(string code);
    }
}
