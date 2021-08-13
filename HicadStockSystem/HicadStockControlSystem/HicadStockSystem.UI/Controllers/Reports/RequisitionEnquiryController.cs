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
    public class RequisitionEnquiryController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IRequisitionEnquiry _enquiry;
        private readonly IGeneratePdf _generatePdf;

        public RequisitionEnquiryController(ISt_StkSystem system, IRequisitionEnquiry enquiry, IGeneratePdf generatePdf)
        {
            _system = system;
            _enquiry = enquiry;
            _generatePdf = generatePdf;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("RequisitionEnquiry/PrintEquiryReport/{reqNo}")]
        public async Task<IActionResult> PrintEquiryReport(string reqNo)
        {
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                RequisitionEnquiry = _enquiry.GetRequisitionEnquiry(reqNo)
            };
            return await _generatePdf.GetPdf("Views/RequisitionEnquiry/PrintEquiryReport.cshtml", model);
            //return View("Views/BuyersGuide/GetGuide.cshtml", model);
        }
    }
}
