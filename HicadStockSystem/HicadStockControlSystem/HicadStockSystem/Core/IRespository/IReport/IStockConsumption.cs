using HicadStockSystem.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface IStockConsumption
    {
        Task<IEnumerable<StockConsumption>> Consumptions();
    }
}
