using HicadStockSystem.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface IReceiptAnalysis
    {
        IEnumerable<ReceiptAnalysisVM> ReceiptAnalysis(DateTime? StartDate, DateTime? EndDate);
        IEnumerable<ReceiptAnalysisVM> GroupReceiptbySum(DateTime? StartDate, DateTime? EndDate);
        IEnumerable<ReceiptAnalysisVM> GroupReceiptBySupplier(DateTime? StartDate, DateTime? EndDate);
    }
}
