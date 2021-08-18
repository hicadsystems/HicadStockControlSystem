using Microsoft.Extensions.Configuration;
using HicadStockSystem.Core.IRespository.IMonthEndProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using HicadStockSystem.Core.Utilities.MonthEndProcessing;
using HicadStockSystem.Data;

namespace HicadStockSystem.Persistence.Repository.MonthEndProcess
{
   
    public class MonthEndBookClosureRepo : IMonthEndBookClosure
    {
        private readonly string  connectionString;
        private readonly StockControlDBContext _context;

        public MonthEndBookClosureRepo(IConfiguration configuration, StockControlDBContext context)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            _context = context;
        }

        public void BookClosure()
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_bookclosure", sqlcon))
                {
                    cmd.CommandTimeout = 1200;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcon.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<MonthEndBookClosureVM> GetBookClosure()
        {
            var bookclosure = _context.St_StockMasters.Where(x => x.IsDeleted == false)
                .Select(y => new MonthEndBookClosureVM
                {
                    ItemCode = y.ItemCode,
                    ItemDesc = y.Description,
                    CurrentQty = y.OpenBalance,
                    Price = y.StockPrice,
                    Value = (decimal?)y.OpenBalance * y.StockPrice
                }).ToList();

            return bookclosure;
        }

    }
}
