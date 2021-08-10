using HicadStockSystem.Core.Utilities.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository.IReport
{
    public interface IOrderRequest
    {
        IEnumerable<OrderRequestVM> OrderRequests();

        IEnumerable<OrderRequestVM> OrderByDate();
    }
}
