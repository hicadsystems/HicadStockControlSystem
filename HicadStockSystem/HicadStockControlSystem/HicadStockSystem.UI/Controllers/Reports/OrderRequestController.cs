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
    public class OrderRequestController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IOrderRequest _orderRequest;
        private readonly IGeneratePdf _generatePdf;

        public OrderRequestController(ISt_StkSystem system, IOrderRequest orderRequest, IGeneratePdf generatePdf)
        {
            _system = system;
            _orderRequest = orderRequest;
            _generatePdf = generatePdf;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("OrderRequest/PrintReport")]
        public async Task<IActionResult> PrintReport()
        {
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                OrderRequests = _orderRequest.OrderByDate()
            };
            return await _generatePdf.GetPdf("Views/OrderRequest/PrintReport.cshtml", model);
            //return View("Views/BuyersGuide/GetGuide.cshtml", model);
        }
    }
}
