using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using RotativaCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace HicadStockSystem.UI.Controllers.Reports
{
    public class StockLedgerController : Controller
    {

        private readonly ISt_StkSystem _system;
        private readonly IStockLedger _ledger;
        private readonly IGeneratePdf _generatePdf;

        public StockLedgerController(ISt_StkSystem system, IStockLedger ledger, IGeneratePdf generatePdf)
        {

            _system = system;
            _ledger = ledger;
            _generatePdf = generatePdf;
        }
        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var ledger = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                StockLedgers = _ledger.GroupByItemCode(startDate, endDate).ToList(),
                StockLedgers2 = _ledger.GroupByLastItemCode(startDate, endDate).ToList()
              
            };
            return View(ledger);
        }

        [Route("StockLedger/StockLedgerPdf/{startDate}/{endDate}")]
        public async Task<IActionResult> StockLedgerPdf(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null && endDate == null)
                return BadRequest("Date is Required");
            var ledger = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                StockLedgers = _ledger.GroupByItemCode(startDate, endDate).ToList(),
                StockLedgers2 = _ledger.GroupByLastItemCode(startDate, endDate).ToList()
            };
            return await _generatePdf.GetPdf("Views/StockLedger/StockLedgerPdf.cshtml", ledger);
        }

        public IActionResult GetByDate(DateTime? startDate, DateTime? endDate)
        {
            var ledger = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                StockLedgers = _ledger.GroupByItemCode(startDate, endDate).ToList(),
                StockLedgers2 = _ledger.GroupByLastItemCode(startDate, endDate).ToList()
            };
            return View("Index", ledger);
        }
    }
}
