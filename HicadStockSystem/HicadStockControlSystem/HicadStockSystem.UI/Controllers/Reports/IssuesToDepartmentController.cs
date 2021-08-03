using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace HicadStockSystem.UI.Controllers.Reports
{
    public class IssuesToDepartmentController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IIssueToDepartment _issue;
        private readonly IGeneratePdf _generatePdf;

        public IssuesToDepartmentController(ISt_StkSystem system, IIssueToDepartment issue, IGeneratePdf generatePdf)
        {
            _system = system;
            _issue = issue;
            _generatePdf = generatePdf;
        }

        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            //for testing
            var issue = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                Issues = _issue.GroupIssuesDepartment(startDate, endDate),
                Issues2 = _issue.GroupIssuesBySum(startDate, endDate)
            };
            return View(issue);
        }

        public async Task<IActionResult> PrintIssue(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null && endDate == null)
                return BadRequest("Date is Required");
            var issue = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                Issues = _issue.GroupIssuesDepartment(startDate, endDate),
                Issues2 = _issue.GroupIssuesBySum(startDate, endDate)
            };

            return await _generatePdf.GetPdf("Views/IssuesToDepartment/PrintIssue.cshtml", issue);
        }
        public IActionResult GetByDate(DateTime? startDate, DateTime? endDate)
        {
            var issue = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                Issues = _issue.GroupIssuesDepartment(startDate, endDate),
                Issues2 = _issue.GroupIssuesBySum(startDate, endDate)
            };

            return View("Index", issue);
        }
    }
}
