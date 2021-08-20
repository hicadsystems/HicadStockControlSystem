using HicadStockSystem.Core;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Core.Utilities.MonthEndProcessing;
using HicadStockSystem.Data;
using HicadStockSystem.Models;
using HicadStockSystem.Persistence.Repository;
using HicadStockSystem.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence
{
    public class St_StockMasterRepo :  ISt_StockMaster
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;
        private readonly string connectionString;

        public St_StockMasterRepo(StockControlDBContext dbContext, IUnitOfWork uow, IConfiguration configuration)
        {

            _dbContext = dbContext;
            _uow = uow;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CreateAsync(St_StockMaster stockMaster)
        {
            await _dbContext.St_StockMasters.AddAsync(stockMaster);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_StockMaster>> GetAll()
        {
            return await _dbContext.St_StockMasters.Where(sm=>sm.IsDeleted==false).ToListAsync();
        }

        public St_StockMaster GetByItemCode(string itemCode)
        {
            return _dbContext.St_StockMasters.Where(sm => sm.ItemCode == itemCode && sm.IsDeleted==false).FirstOrDefault();
        }

        public async Task UpdateAsync(St_StockMaster stockMaster)
        {
            _dbContext.Update(stockMaster);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(string itemCode)
        {
            var stockMasterInDb = GetByItemCode(itemCode);
            _dbContext.Update(stockMasterInDb);
            await _uow.CompleteAsync();
        }

        public async Task Delete(string itemCode)
        {
            var stockMasterInDb = GetByItemCode(itemCode);
            stockMasterInDb.IsDeleted=true;
            await _uow.CompleteAsync();
            
        }

        public async Task<IEnumerable<StockPositionVM>> StockPositions()
        {
            var values = await _dbContext.St_StockMasters.Where(x => x.IsDeleted == false)
                .Join(_dbContext.St_ItemMasters, stk => stk.ItemCode, item => item.ItemCode, (stk, item) => new { stk, item })
                .Select(y => new StockPositionVM
                {
                    ItemCode = y.stk.ItemCode,
                    ItemDesc = y.stk.Description,
                    PartNo = y.item.PartNo,
                    CurrentBalance = y.stk.OpenBalance + y.stk.Receipts - y.stk.Issues,
                    Price = y.stk.StockPrice,
                    Value = y.stk.StockPrice * (decimal)(y.stk.OpenBalance + y.stk.Receipts - y.stk.Issues)
                }).ToListAsync();

            return values;
        }

        private static decimal? Total(decimal? value)
        {
            decimal? subtotal = 0.0m;
            decimal? total = (subtotal += value);
            return total;
            
        }

        public async Task<IEnumerable<PhysicalCountSheetVM>> PhysicalCounts()
        {
            var sheet = await _dbContext.St_StockMasters.Where(x => x.IsDeleted == false)
                .Select(y => new PhysicalCountSheetVM
                {
                    ItemCode = y.ItemCode,
                    ItemDesc = y.Description
                }).ToListAsync();

            return sheet;
        }
        
        public async Task UpdateWithExcelFile(List<PhysicalCountSheetVM> physicalCount)
        {
            foreach (var item in physicalCount)
            {

                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_updatephysicalcount", sqlcon))
                    {
                        cmd.CommandTimeout = 1200;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@itemcode", item.ItemCode));
                        cmd.Parameters.Add(new SqlParameter("@quantity", item.Quantity));

                        sqlcon.Open();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
        }
    }
}
