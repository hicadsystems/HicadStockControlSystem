using HicadStockSystem.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository.IReport
{
    public interface IStockLedger
    {
        IEnumerable<StockLedgerVM> StockLedger();
        IEnumerable<StockLedgerVM> GroupByItemCode();
        IEnumerable<StockLedgerVM> GroupByLastItemCode();
    }
}
