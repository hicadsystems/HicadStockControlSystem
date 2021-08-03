using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Data;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class IssueToDepartmentRepo : IIssueToDepartment
    {
        private readonly StockControlDBContext _context;

        public IssueToDepartmentRepo(StockControlDBContext context)
        {
            _context = context;
        }
        public IEnumerable<IssuesToDepartment> Issues(DateTime? startDate, DateTime? endDate)
        {
            var result = (from history in _context.St_Histories
                          join costcenter in _context.Ac_CostCentres on history.Location equals costcenter.UnitCode
                          join itemmaster in _context.St_ItemMasters on history.ItemCode equals itemmaster.ItemCode
                          where history.DocType == "IS" && history.IsDeleted == false && history.DocDate >= startDate && history.DocDate <= endDate
                          select new IssuesToDepartment
                          {
                              DepartmentCode = costcenter.UnitCode,
                              DepartmentName = costcenter.UnitDesc,
                              DocNo = history.DocNo,
                              DocDate = string.Format("{0:MM/dd/yyyy}", history.DocDate),
                              ItemDescription = itemmaster.ItemDesc,
                              Quantity = history.Quantity,
                              Price = history.Price,
                              Amount = history.Quantity * history.Price
                          }).ToList();

            return result;
        }
       
        public IEnumerable<IssuesToDepartment> GroupIssuesDepartment(DateTime? startDate, DateTime? endDate)
        {
            var issues = new List<IssuesToDepartment>();
            var group = Issues(startDate, endDate).OrderBy(x => x.DocDate).GroupBy(x => x.DepartmentCode).ToList();
            foreach (var g in group)
            {
                foreach (var issue in g)
                {
                    issues.Add(new IssuesToDepartment
                    {
                        DepartmentCode = issue.DepartmentCode,
                        DepartmentName = issue.DepartmentName,
                        DocNo = issue.DocNo,
                        DocDate = issue.DocDate,
                        ItemDescription = issue.ItemDescription,
                        Price = issue.Price,
                        Quantity = issue.Quantity,
                        Amount = issue.Amount
                    });
                }
                //issues.Add(g.Select(x => new IssuesToDepartment
                //{
                //    DepartmentCode = x.DepartmentCode,
                //    DepartmentName = x.DepartmentName,
                //    DocNo = x.DocNo,
                //    DocDate = x.DocDate,
                //    ItemDescription = x.ItemDescription,
                //    Price = x.Price,
                //    Quantity = x.Quantity,
                //    Amount = x.Amount
                //}).FirstOrDefault());
            }

            return issues;
        }

        public IEnumerable<IssuesToDepartment> GroupIssuesBySum(DateTime? startDate, DateTime? endDate)
        {
            var issues = new List<IssuesToDepartment>();
            var group = Issues(startDate, endDate).OrderBy(x => x.DocDate).DistinctBy(x => x.DepartmentCode);
            foreach (var issue in group)
            {
                issues.Add(new IssuesToDepartment
                {
                    DepartmentCode = issue.DepartmentCode,
                    DepartmentName = issue.DepartmentName,
                    DocNo = issue.DocNo,
                    DocDate = issue.DocDate,
                    ItemDescription = issue.ItemDescription,
                    Price = issue.Price,
                    Quantity = issue.Quantity,
                    Amount = issue.Amount
                });
            }
            return issues;
        }
    }
}
