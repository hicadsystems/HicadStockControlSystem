using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace HicadStockSystem.UI.Controllers
{
    public class St_RequisitionUIController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly ISt_Requisition _requisition;
        private readonly IGeneratePdf _generatePdf;

        public St_RequisitionUIController(ISt_StkSystem system, ISt_Requisition requisition, IGeneratePdf generatePdf)
        {
            _system = system;
            _requisition = requisition;
            _generatePdf = generatePdf;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllStockRequest()
        {
            return View();
        }
        public IActionResult GetAllRequisitionForApproval()
        {
            return View();
        }

        public IActionResult ApprovedRequisitions()
        {
            return View();
        }

        public IActionResult GetByCode()
        {
            return View();
        }

        public IActionResult PurgeItem()
        {
            return View();
        }

        [Route("St_RequisitionUI/StockRequisition/{reqno}")]
        public async Task<IActionResult> StockRequisition(string reqno)
        {
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                Requesition = _requisition.RequesitionsVM(reqno)
            };
            //return RedirectToAction("Index");
            return await _generatePdf.GetPdf("Views/St_RequisitionUI/StockRequisition.cshtml", model);
        }
    }
}
