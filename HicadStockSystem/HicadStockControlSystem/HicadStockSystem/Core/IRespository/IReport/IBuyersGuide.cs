using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Core.Utilities.Report;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository.IReport
{
    public interface IBuyersGuide
    {
      
        IEnumerable<BuyersGuide> BuyersGuides();
        IEnumerable<BuyersGuide> GroupByItemCode();
        IEnumerable<BuyersGuide> GroupByDistinctItemCode();

    }
}
