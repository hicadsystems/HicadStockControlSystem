using HicadStockSystem.Core.IRespository.IMonthEndProcessing;
using HicadStockSystem.Core.Utilities.MonthEndProcessing;
using HicadStockSystem.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.MonthEndProcess
{
    public class OverwriteStockBookRepo : IOverwriteStockBook
    {
        private readonly StockControlDBContext _context;
        private readonly string connectionString;

        public OverwriteStockBookRepo(StockControlDBContext context, IConfiguration configuration)
        {
            _context = context;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IEnumerable<MonthEndBookClosureVM> OverwriteStock()
        {
            var overwrite = _context.St_StockMasters.Where(x => x.IsDeleted == false)
                .Select(y => new MonthEndBookClosureVM
                {
                    ItemCode = y.ItemCode,
                    ItemDesc = y.Description,
                    CurrentQty = y.OpenBalance,
                    Price = y.StockPrice,
                    Value = (decimal?)y.OpenBalance * y.StockPrice
                }).ToList();
            return overwrite;
        }

        public void OverwriteStockBook()
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_overwritestockbook", sqlcon))
                {
                    cmd.CommandTimeout = 1200;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcon.Open();
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
