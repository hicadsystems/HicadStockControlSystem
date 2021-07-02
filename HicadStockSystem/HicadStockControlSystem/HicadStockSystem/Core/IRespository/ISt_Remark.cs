using HicadStockSystem.Core.Models;
using HicadStockSystem.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface ISt_Remark
    {
        Task CreateAsync(St_Remark remark);
        IEnumerable<St_Remark> GetAll();
        St_Remark GetById(int id);
        Task UpdateAsync(St_Remark recordTable);
        Task UpdateAsync(int id);
        Task DeleteAsync(int id);
    }
}
