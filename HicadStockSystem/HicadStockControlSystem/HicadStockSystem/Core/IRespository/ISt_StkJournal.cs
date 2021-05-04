using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface ISt_StkJournal 
    {
        Task CreateAsync(St_StkJournal stkJournal);
        St_StkJournal GetByCompany(string coy);
        //St_StkJournal GetByBranch(string branch);
        //St_StkJournal GetByYear(string year);
        //St_StkJournal GetByMonth(string month);
        //St_StkJournal GetByType(string type);
        //St_StkJournal GetByAccount(string acct);
        Task UpdateAsync(St_StkJournal stkJournal);
        Task UpdateAsync(string comp);
        Task<IEnumerable<St_StkJournal>> GetAll();
        Task DeleteAsync(string coy);

    }
}
