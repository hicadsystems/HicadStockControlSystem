using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Utilities.Report;
using HicadStockSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class UndeliveredItemsRepo : IUndeliveredItems
    {
        private readonly StockControlDBContext _context;

        public UndeliveredItemsRepo(StockControlDBContext context)
        {
            _context = context;
        }
        public IEnumerable<UndeliveredItemsVM> GetUndeliveredItems()
        {
            var value = _context.St_Requisitions.Where(x => x.IsDeleted == false && x.IsSupplied == false)
               .Select(y => new UndeliveredItemsVM
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

        public IEnumerable<UndeliveredItemsVM> OrderByDate()
        {
            var requisition = GetUndeliveredItems().OrderBy(x => x.Date).ToList();
            return requisition;
        }
    }
}
