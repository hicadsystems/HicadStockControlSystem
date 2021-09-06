using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Core.Utilities.Report;
using HicadStockSystem.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class BuyersGuideRepo : IBuyersGuide
    {
        private readonly StockControlDBContext _context;
        private readonly string connectionString;

        public BuyersGuideRepo(StockControlDBContext context, IConfiguration configuration)
        {
            _context = context;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
       
        public IEnumerable<BuyersGuide> BuyersGuides()
        {
            var guide = new List<BuyersGuide>();

            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_buyersguide", sqlcon))
                {
                    cmd.CommandTimeout = 1200;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlcon.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            guide.Add(new BuyersGuide
                            {
                                ItemCode = sdr["ItemCode"].ToString(),
                                ItemDesc = sdr["ItemDesc"].ToString(),
                                SupplierCode = sdr["SupplierCode"].ToString(),
                                SupplierName = sdr["SupplierName"].ToString(),
                            });
                        }
                    }
                }
            }

            return guide;
        }
        

        public IEnumerable<BuyersGuide> GroupByItemCode()
        {
            var guide = new List<BuyersGuide>();
            var group = BuyersGuides().GroupBy(x => x.ItemCode).ToList();

            foreach (var g in group)
            {
                foreach (var item in g)
                {
                    guide.Add(new BuyersGuide
                    {
                        ItemCode = item.ItemCode,
                        ItemDesc = item.ItemDesc,
                        SupplierCode = item.SupplierCode,
                        SupplierName = item.SupplierName
                    });
                }
            }

            return guide;
        }
        public IEnumerable<BuyersGuide> GroupByDistinctItemCode()
        {
            var guide = new List<BuyersGuide>();
            var group = BuyersGuides().DistinctBy(x => x.ItemCode).ToList();

            foreach (var g in group)
            {
                guide.Add(new BuyersGuide
                {
                    ItemCode = g.ItemCode,
                    ItemDesc = g.ItemDesc,
                    SupplierCode = g.SupplierCode,
                    SupplierName = g.SupplierName
                });
            }

            return guide;
        }
    }
}
