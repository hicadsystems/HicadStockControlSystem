using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Utilities.Report;
using HicadStockSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class RequisitionEnquiryRepo : IRequisitionEnquiry
    {
        private readonly StockControlDBContext _context;

        public RequisitionEnquiryRepo(StockControlDBContext context)
        {
            _context = context;
        }
        public RequisitionEnquiryVM GetRequisitionEnquiry(string reqNo)
        {
            var result = _context.St_Requisitions.Where(x => x.IsDeleted == false && x.RequisitionNo == reqNo)
                .Select(y => new RequisitionEnquiryVM
                {
                    RequisitionNo = y.RequisitionNo,
                    RequestedBy = y.UserId,
                    AprrovedBy = y.ApprovedBy,
                    SuppliedBy = y.SupplyBy,
                    RequestDate = string.Format("{0:MM/dd/yyyy h:mm tt}", y.RequisitionDate),
                    ApprovedDate = string.Format("{0:MM/dd/yyyy h:mm tt}", y.UpdatedOn),
                    SupplyDate = string.Format("{0:MM/dd/yyyy h:mm tt}", y.SupplyDate),
                    Items = GetRequestedItemsSorted(reqNo)
                }).FirstOrDefault();

            return result;
        }

        public List<RequestedItems> GetRequestedItems(string reqNo)
        {
           
            var items = _context.St_Requisitions.Where(x => x.IsDeleted == false && x.RequisitionNo == reqNo)
                .Select(y => new RequestedItems
                {
                    ItemCode = y.ItemCode,
                    ItemDesc = y.Description,
                    ApprovedQty =  y.SupplyQty,
                    Quantity =  y.Quantity,
                    Price = y.Price,
                    Value = (decimal?)y.Quantity * y.Price
                }).ToList();

            return items;
        }

        public List<RequestedItems> GetRequestedItemsSorted(string reqNo)
        {
            decimal? supplyQty;
            float? quantity;

            var newItems = new List<RequestedItems>();
            var sortItems = GetRequestedItems(reqNo).ToList();

            foreach (var item in sortItems)
            {
                newItems.Add(new RequestedItems
                {
                    ItemCode = item.ItemCode,
                    ItemDesc = item.ItemDesc,
                    ApprovedQty = supplyQty = item.ApprovedQty.Equals(null) ? (decimal?)item.Quantity : item.ApprovedQty,
                    Quantity = (float?)(quantity = item.ApprovedQty.Equals(null) ? null : item.Quantity),
                    Price = item.Price,
                    Value = (decimal?)item.Quantity * item.Price
                });
            }

            return newItems;
        }
    }
}
