using HicadStockSystem.Core.Utilities.MonthEndProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository.IMonthEndProcessing
{
    public interface IOverwriteStockBook
    {
        void OverwriteStockBook();
        IEnumerable<MonthEndBookClosureVM> OverwriteStock();
    }
}
