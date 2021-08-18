using HicadStockSystem.Core.IRespository.IMonthEndProcessing;
using HicadStockSystem.Core.Utilities.MonthEndProcessing;
using HicadStockSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.MonthEndProcess
{
    public class PhysicalCountSheetRepo : IPhysicalCountSheet
    {
        private readonly StockControlDBContext _context;

        public PhysicalCountSheetRepo(StockControlDBContext context)
        {
            _context = context;
        }

        public List<PhysicalCountSheetVM> GetCountSheet()
        {
            var sheet = _context.St_ItemMasters.Where(x => x.IsDeleted == false)
                .Select(y => new PhysicalCountSheetVM
                {
                    ItemCode = y.ItemCode,
                    ItemDesc = y.ItemDesc,
                    Location = y.StoreLoc + "-" + y.Storerack + "-" + y.Storebin
                }).ToList();
            return sheet;
        }
        
        public List<PhysicalCountSheetVM> GetPhysicalCount()
        {
            var sheet = _context.St_StockMasters.Where(x => x.IsDeleted == false)
                .Select(y => new PhysicalCountSheetVM
                {
                    ItemCode = y.ItemCode,
                    ItemDesc = y.Description,
                    //Location = y.StoreLoc + "-" + y.Storerack + "-" + y.Storebin,
                    Quantity = y.Physical
                    
                }).ToList();
            return sheet;
        }
    }
}
