using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Core.Utilities.Report;
using HicadStockSystem.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class BuyersGuideRepo : IBuyersGuide
    {
        private readonly StockControlDBContext _context;

        public BuyersGuideRepo(StockControlDBContext context)
        {
            _context = context;
        }
        public IEnumerable<BuyersGuide> GetAllItems()
        {
            var item =  _context.St_ItemMasters.Where(x => x.IsDeleted == false)
                .Select(y => new BuyersGuide
                {
                    ItemCode = y.ItemCode,
                    ItemDesc = y.ItemDesc
                }).ToList();

            return item;
        }

        public BuyersGuide GetSupplierByItemCode(string itemCode)
        {
            //var suppliers = GetSupplier(itemCode);
            var result = new BuyersGuide
            {
                ItemCode = itemCode,
                ItemDesc = GetItemDesc(itemCode),
                Suppliers = GetSupplier(itemCode)
            };

            //var result =  _context.St_ItemMasters.Where(x => x.IsDeleted == false && x.ItemCode == itemCode)
            //    .Select(y => new BuyersGuide
            //    {
            //        Suppliers = GetSupplier(itemCode),
            //        ItemCode = y.ItemCode,
            //        ItemDesc = y.ItemDesc,
            //    }).FirstOrDefault();
            return result;
        }

        public  IEnumerable<SelectListItem> GetItems()
        {
            return GetAllItems().Select(item => new SelectListItem
            {
                Value = item.ItemCode,
                Text = item.ItemDesc
            });
        }


        //public List<SuppliersByCode> GetSupplier(string itemCode)
        public SuppliersByCode GetSupplier(string itemCode)
        {
            
            var supplierCodes = GetSuppliersByItemCode(itemCode);

            var supplier = supplierCodes.Select(y => new SuppliersByCode
            {
                Supplier1 = GetItemSuppliers(y.SuppliersCode1),
                Supplier2 = GetItemSuppliers(y.SuppliersCode2),
                Supplier3 = GetItemSuppliers(y.SuppliersCode3),
                Supplier4 = GetItemSuppliers(y.SuppliersCode4),
                Supplier5 = GetItemSuppliers(y.SuppliersCode5),
            }).FirstOrDefault();

           

            return supplier;
        }

        public List<Suppliers> GetSuppliersByItemCode(string itemCode)
        {
            var result = _context.St_ItemMasters.Where(x => x.IsDeleted == false && x.ItemCode == itemCode)
                .Select(y => new Suppliers
                {
                    SuppliersCode1 = y.Supplier1,
                    SuppliersCode2 = y.Supplier2,
                    SuppliersCode3 = y.Supplier3,
                    SuppliersCode4 = y.Supplier4,
                    SuppliersCode5 = y.Supplier5
                }).ToList();
            return result;
        }
        public St_Supplier GetItemSuppliers(string supplierCode)
        {
            var supplier = _context.St_Suppliers.Where(y => y.IsDeleted == false && y.SupplierCode == supplierCode).FirstOrDefault();
            return supplier;
        }

        public string GetItemCode(string itemCode)
        {
            var supplier = _context.St_ItemMasters.Where(y => y.IsDeleted == false && y.ItemCode == itemCode).Select(y => y.ItemCode).FirstOrDefault();
            return supplier;
        }
        public string GetItemDesc(string itemCode)
        {
            var supplier = _context.St_ItemMasters.Where(y => y.IsDeleted == false && y.ItemCode == itemCode).Select(y => y.ItemDesc).FirstOrDefault();
            return supplier;
        }
        //public  string GetSupplierName(string supplierCode)
        //{
        //    var supplierName = _context.St_Suppliers.Where(x => x.IsDeleted == false && x.SupplierCode == supplierCode)
        //        .Select(y => y.SupplierCode).FirstOrDefault();
        //    return supplierName;
        //}

        //public string GetSupplierContact(string supplierCode)
        //{
        //    var contact = _context.St_Suppliers.Where(x => x.IsDeleted == false && x.SupplierCode == supplierCode)
        //        .Select(y => y.Contact).FirstOrDefault();
        //    return contact;
        //}

        //public string GetSupplierPhone(string supplierCode)
        //{
        //    var phone = _context.St_Suppliers.Where(x => x.IsDeleted == false && x.SupplierCode == supplierCode)
        //        .Select(y => y.Phone).FirstOrDefault();
        //    return phone;
        //}
    }
}
