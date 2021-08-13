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
    public class ReorderListController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IReorderList _items;
        private readonly IGeneratePdf _generatePdf;

        public ReorderListController(ISt_StkSystem system, IReorderList items, IGeneratePdf generatePdf)
        {
            _system = system;
            _items = items;
            _generatePdf = generatePdf;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("ReorderList/PrintReorderList")]
        public async Task<IActionResult> PrintReorderList()
        {
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                ReorderLists = _items.GetReorderLists()
            };
            return await _generatePdf.GetPdf("Views/ReorderList/PrintReorderList.cshtml", model);
        }
    }
}
