using HicadStockSystem.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository.IReport
{
    public interface IStockLedger
    {
        IEnumerable<StockLedgerVM> StockLedger(DateTime? startDate, DateTime? endDate);
        IEnumerable<StockLedgerVM> GroupByItemCode(DateTime? startDate, DateTime? endDate);
        IEnumerable<StockLedgerVM> GroupByLastItemCode(DateTime? startDate, DateTime? endDate);
    }
}
