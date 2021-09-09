using HicadStockSystem.Controllers.ResourcesVM.St_StkSystem;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using HicadStockSystem.Models;
using HicadStockSystem.Persistence.Repository;
using HicadStockSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence
{
    public class St_StkSystemRepo :  ISt_StkSystem
    {
        private readonly StockControlDBContext _dbContext;
        private  readonly string connectionString;

        public St_StkSystemRepo(StockControlDBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task CreateAsync(St_StkSystem stkSystem)
        {
            await _dbContext.St_StkSystems.AddAsync(stkSystem);
        }

        public async Task<IEnumerable<St_StkSystem>> GetAll()
        {
            return await _dbContext.St_StkSystems.Where(stk=>stk.IsDeleted==false).ToListAsync();

        }
        public  GetSt_System GetSystem()
        {
            var system = new GetSt_System();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("st_getsystem", sqlcon))
                {
                    cmd.CommandTimeout = 1200;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlcon.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            system.CompanyCode = sdr["CompanyCode"].ToString();
                            system.CompanyName = sdr["CompanyName"].ToString();
                            system.CompanyAddress = sdr["CompanyAddress"].ToString();
                            system.Email = sdr["Email"].ToString();
                            system.Phone = sdr["Phone"].ToString();
                            system.Town_City = sdr["Town_City"].ToString();
                            system.SerialNumber = sdr["SerialNumber"].ToString();
                            if (sdr["ProcessMonth"] != DBNull.Value)
                            {
                                system.ProcessMonth = Convert.ToInt32(sdr["ProcessMonth"]);
                            }
                            if (sdr["ProcessYear"] != DBNull.Value)
                            {
                                system.ProcessYear = Convert.ToInt32(sdr["ProcessYear"]);
                            }
                            if (sdr["InstallDate"] != DBNull.Value)
                            {
                                system.InstallDate = Convert.ToDateTime(sdr["InstallDate"]);
                            }
                            system.State = sdr["State"].ToString();
                            system.ApprovedDay = sdr["ApprovedDay"].ToString();
                            system.HoldDays = sdr["HoldDays"].ToString();
                            system.GLCode = sdr["GLCode"].ToString();
                            system.ExpenseCode = sdr["ExpenseCode"].ToString();
                            system.CreditorsCode = sdr["CreditorsCode"].ToString();
                            system.WriteoffLoc = sdr["WriteoffLoc"].ToString();
                            system.BusLine = sdr["BusLine"].ToString();
                            
                        }
                    }
                }
            }

            return system;
            

        }

        public St_StkSystem GetByCompanyCode(string compcode)
        {
            return _dbContext.St_StkSystems.Where(stk => stk.CompanyCode == compcode && stk.IsDeleted==false).FirstOrDefault();
        }
        public St_StkSystem GetSingle()
        {
            return _dbContext.St_StkSystems.Where(stk => stk.IsDeleted==false).FirstOrDefault();
        }

        public async Task UpdateAsync(St_StkSystem stkSystem)
        {
            _dbContext.Update(stkSystem);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(string compcode)
        {
            var stksystem = GetByCompanyCode(compcode);
            _dbContext.Update(stksystem);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(string compcode)
        {
            //using the GetByCompanyCode instead of repeating code 
            var stkSystem = GetByCompanyCode(compcode);
            stkSystem.IsDeleted=true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<StateList>> GetAllState()
        {
            return await _dbContext.StateLists.ToListAsync();
        }

        public async Task<IEnumerable<Ac_CostCentre>> GetCostCenter()
        {
            return await (from location in _dbContext.Ac_CostCentres select 
                          new Ac_CostCentre {
                              UnitCode = location.UnitCode,
                              UnitDesc = location.UnitDesc
                          }).ToListAsync();
        }

        public async Task<IEnumerable<Ac_BusinessLine>> GetBusLine()
        {
            return await (from busline in _dbContext.Ac_BusinessLines select
                          new Ac_BusinessLine { 
                              BusinessLine = busline.BusinessLine,
                              BusinessDesc = busline.BusinessDesc
                          }).ToListAsync();
        }

        public async Task<IEnumerable<AccChart>> GetAccChart()
        {
            return await (from accchart in _dbContext.AccCharts select
                          new AccChart {
                              AcctNumber = accchart.AcctNumber,
                              Description = accchart.Description
                          }).OrderBy(s=>s.Description).ToListAsync();
        }

        public async Task<IEnumerable<AccChart>> GetCreditorCode()
        {
            return await(from accchart in _dbContext.AccCharts
                         select
            new AccChart
            {
            AcctNumber = accchart.AcctNumber,
            Description = accchart.Description
            }).ToListAsync();
        }

        public async Task<IEnumerable<AccChart>> GetGLCode()
        {
            return await(from accchart in _dbContext.AccCharts
                         select
            new AccChart
            {
            AcctNumber = accchart.AcctNumber,
            Description = accchart.Description
            }).ToListAsync();
        }

        public async Task<IEnumerable<AccChart>> GetExpenseCode()
        {
             return await (from accchart in _dbContext.AccCharts select
                          new AccChart {
                              AcctNumber = accchart.AcctNumber,
                              Description = accchart.Description
                          }).ToListAsync();
        }
    }
}
