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
        IEnumerable<BuyersGuide> GetAllItems();
        //IEnumerable<BuyersGuide> GetSupplierByItemCode(string itemCode);
        BuyersGuide GetSupplierByItemCode(string itemCode);
        IEnumerable<SelectListItem> GetItems();
        //List<St_Supplier> GetItemSuppliers(string supplierCode, string supplier1, string supplier2);
        //List<SuppliersByCode> GetSupplier(string itemCode);
        SuppliersByCode GetSupplier(string itemCode);
        List<Suppliers> GetSuppliersByItemCode(string itemCode);

    }
}
