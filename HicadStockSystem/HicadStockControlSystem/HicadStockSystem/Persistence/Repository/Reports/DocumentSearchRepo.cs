using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Utilities.Report;
using HicadStockSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class DocumentSearchRepo : IDocumentSearch
    {
        private readonly StockControlDBContext _context;

        public DocumentSearchRepo(StockControlDBContext context)
        {
            _context = context;
        }
        public DocumentSearchVM DocumentSearch(string docNo)
        {
            var result = _context.St_Histories.Where(x => x.IsDeleted == false && x.DocNo == docNo).Select(y => new DocumentSearchVM
            {
                DocumentNo = y.DocNo,
                DocumentType = GetDocumentType(docNo),
                DocumentDate = string.Format("{0:MM/dd/yyyy h:mm tt}", y.DateCreated),
                ListOfItems = GetItems(docNo),
                Supplier = GetSupplierDetails(docNo),
                UserId = y.UserId,
                Location = GetLocation(docNo)
            }).FirstOrDefault();

            return result;
        }

        public string GetDocumentType(string docNo)
        {
            var doctype = _context.St_Histories.Where(x => x.DocNo == docNo && x.IsDeleted == false).Select(y => y.DocType).FirstOrDefault();

            if (doctype=="GR")
            {
                doctype = "Receipt";
                //return ;
            }
            else if (doctype.Equals("IS"))
            {
                doctype = "Requisition";
            }
            else if (doctype.Equals("RT"))
            {
                doctype = "Return";
            }

            return doctype;
        }

        public List<ListOfItems> GetItems(string docNo)
        {
            var items = _context.St_Histories.Where(x => x.IsDeleted == false && x.DocNo == docNo)
                .Join(_context.St_ItemMasters, history => history.ItemCode, item => item.ItemCode, (history, item) => new { history, item })
                .Select(y => new ListOfItems
                {
                    ItemCode = y.item.ItemCode,
                    ItemDesc = y.item.ItemDesc,
                    Quantity = y.history.Quantity,
                    Price = y.history.Price,
                    Value = y.history.Quantity * y.history.Price,
                }).ToList();

            return items;

        }

        public Supplier GetSupplierDetails(string docNo)
        {
            var supplier = _context.St_Histories.Where(x => x.IsDeleted == false && x.DocNo == docNo)
                .Join(_context.St_Suppliers, hist => hist.Supplier, supplier => supplier.SupplierCode, (hist, supplier) => new { hist, supplier })
                .Select(y => new Supplier
                {
                    SupplierCode = y.supplier.SupplierCode,
                    Name = y.supplier.Name,
                    Contact = y.supplier.Contact,
                    Phone = y.supplier.Phone
                }).FirstOrDefault();

            return supplier;
        }

        public Location GetLocation(string docNo)
        {
            var location = _context.St_Histories.Where(x => x.IsDeleted == false && x.DocNo == docNo)
                .Join(_context.Ac_CostCentres, hist => hist.Location, centre => centre.UnitCode, (hist, centre) => new { hist, centre })
                .Select(y => new Location
                {
                    LocationCode = y.hist.Location,
                    LocationName = y.centre.UnitDesc
                }).FirstOrDefault();
            return location;
        }
    }
}
