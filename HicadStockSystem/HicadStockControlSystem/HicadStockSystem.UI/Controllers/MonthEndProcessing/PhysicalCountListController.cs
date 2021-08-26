using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository.IMonthEndProcessing;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Core.Utilities.MonthEndProcessing;
using HicadStockSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace HicadStockSystem.UI.Controllers.MonthEndProcessing
{
    public class PhysicalCountListController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IPhysicalCountSheet _countSheet;
        private readonly IGeneratePdf _generatePdf;
        private readonly ISt_StockMaster _stockMaster;

        public PhysicalCountListController(ISt_StkSystem system, IPhysicalCountSheet countSheet, IGeneratePdf generatePdf, ISt_StockMaster stockMaster)
        {
            _system = system;
            _countSheet = countSheet;
            _generatePdf = generatePdf;
            _stockMaster = stockMaster;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("PhysicalCountList/GetPhysicalCount")]
        public async Task<IActionResult> GetPhysicalCount()
        {
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                PhysicalCountSheets = _countSheet.GetPhysicalCount()
            };
            //return RedirectToAction("Index");
            return await _generatePdf.GetPdf("Views/PhysicalCountList/GetPhysicalCount.cshtml", model);
        }

        //[Route("updatephysicalcountexcel")]
        [HttpPost]
        public async Task<IActionResult> UpdatePhysicalCount(IFormFile formFile, CancellationToken cancellationToken)
        {
            if (formFile == null || formFile.Length <= 0)
            {
                //TempData["message"] = "No File Uploaded";
                //return BadRequest("File not an Excel Format");
                //return View();
                return BadRequest("No File Uploaded");
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                //TempData["message"] = "File not an Excel Format";
                return BadRequest("File not an Excel Format");
                //return View();
            }

            var listapplication = new List<PhysicalCountSheetVM>();
            var listapplicationofrecordnotavailable = new List<PhysicalCountSheetVM>();

            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                    var rowCount = worksheet.Dimension.Rows;
                    string ITEM_CODE = String.IsNullOrEmpty(worksheet.Cells[1, 1].ToString()) ? "" : worksheet.Cells[1, 1].Value.ToString().Trim();
                    string ITEM_DESC = String.IsNullOrEmpty(worksheet.Cells[1, 2].ToString()) ? "" : worksheet.Cells[1, 2].Value.ToString().Trim();
                    string Quantity = String.IsNullOrEmpty(worksheet.Cells[1, 3].ToString()) ? "" : worksheet.Cells[1, 3].Value.ToString().Trim();

                    if (ITEM_CODE != "ITEM CODE" || ITEM_DESC != "ITEM DESC" || Quantity != "QUANTITY")
                    {
                        return BadRequest("File not in the Right format");
                    }
                    for (int row = 2; row <= rowCount; row++)
                    {
                        if (worksheet.Cells[1, 1].Value == null)
                            worksheet.Cells[1, 1].Value = "";

                        if (worksheet.Cells[1, 2].Value == null)
                            worksheet.Cells[1, 2].Value = "";

                        if (worksheet.Cells[1, 3].Value == null)
                            worksheet.Cells[1, 3].Value = "";



                        if (worksheet.Cells[row, 1].Value == null)
                            worksheet.Cells[row, 1].Value = "";

                        if (worksheet.Cells[row, 2].Value == null)
                            worksheet.Cells[row, 2].Value = "";

                        if (worksheet.Cells[row, 3].Value == null)
                            worksheet.Cells[row, 3].Value = "";


                        string itemcode = String.IsNullOrEmpty(worksheet.Cells[row, 1].Value.ToString()) ? "" : worksheet.Cells[row, 1].Value.ToString().Trim();
                        string itemDesc = String.IsNullOrEmpty(worksheet.Cells[row, 2].Value.ToString()) ? "" : worksheet.Cells[row, 2].Value.ToString().Trim();
                        int quantity = ((int)worksheet.Cells[row, 3].Value).Equals(null) ? 0 : (int)worksheet.Cells[row, 3].Value;


                        if (String.IsNullOrEmpty(worksheet.Cells[row, 1].Value.ToString()) ||
                            String.IsNullOrEmpty(worksheet.Cells[row, 3].Value.ToString()))
                        {
                            listapplicationofrecordnotavailable.Add(new PhysicalCountSheetVM
                            {
                                ItemCode = itemcode,
                                ItemDesc = itemDesc,
                                Quantity = quantity,

                            });

                        }
                        else
                        {
                            //check if already in the list -- a possibility
                            listapplication.Add(new PhysicalCountSheetVM
                            {
                                ItemCode = itemcode,
                                ItemDesc = itemDesc,
                                Quantity = quantity,
                            });
                        }

                    }

                    await _stockMaster.UpdateWithExcelFile(listapplication);
                    //string userp = User.Identity.Name;

                    //ProcesUpload procesUpload2 = new ProcesUpload(listapplication, unitOfWorks, userp);
                    //await procesUpload2.processUploadInThread();
                    //TempData["message"] = "Uploaded Successfully";


                }

            }
            if (listapplicationofrecordnotavailable.Count > 0)
            {

                var stream = new MemoryStream();

                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet2");
                    workSheet.Cells.LoadFromCollection(listapplicationofrecordnotavailable, true);
                    package.Save();
                }
                stream.Position = 0;
                string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

                //return File(stream, "application/octet-stream", excelName);  
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
            return Ok();
        }
    }
}
