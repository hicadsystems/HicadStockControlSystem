using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Utilities.Report;
using HicadStockSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class OrderRequestRepo : IOrderRequest
    {
        private readonly StockControlDBContext _context;

        public OrderRequestRepo(StockControlDBContext context)
        {
            _context = context;
        }
        public IEnumerable<OrderRequestVM> OrderRequests()
        {
            var value = _context.St_Requisitions.Where(x => x.IsDeleted == false && x.IsSupplied == false)
                 .Select(y => new OrderRequestVM
                 {
                     RequisitionNo = y.RequisitionNo,
                     Date = string.Format("{0:MM/dd/yyyy}", y.RequisitionDate),
                     ItemDesc = y.Description,
                     Quantity = y.Quantity,
                     RequestedBy = y.UserId,
                     ApprovedBy = y.ApprovedBy
                 }).ToList();
            return value;
        }

        public IEnumerable<OrderRequestVM> OrderByDate()
        {
            var requisition = OrderRequests().OrderBy(x => x.Date).ToList();
            return requisition;
        }
    }
}
