using HicadStockSystem.Core.Utilities.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository.IReport
{
    public interface IReorderList
    {
        IEnumerable<ReorderList> GetReorderLists(); 
    }
}
