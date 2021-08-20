using HicadStockSystem.Core.Utilities.MonthEndProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository.IMonthEndProcessing
{
    public interface IPhysicalCountSheet
    {
        List<PhysicalCountSheetVM> GetCountSheet();
        List<PhysicalCountSheetVM> GetPhysicalCount();
    }
}
