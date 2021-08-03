using HicadStockSystem.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository.IReport
{
    public interface IIssueToDepartment
    {
        IEnumerable<IssuesToDepartment> Issues(DateTime? startDate, DateTime? endDate);
        IEnumerable<IssuesToDepartment> GroupIssuesBySum(DateTime? startDate, DateTime? endDate);
        IEnumerable<IssuesToDepartment> GroupIssuesDepartment(DateTime? startDate, DateTime? endDate);
    }
}
