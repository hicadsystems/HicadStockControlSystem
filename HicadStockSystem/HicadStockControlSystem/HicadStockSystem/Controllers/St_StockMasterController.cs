using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_StockMaster;
using HicadStockSystem.Core;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities.MonthEndProcessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [ApiController()]
    [Route("api/stockmaster")]
    public class St_StockMasterController : ControllerBase
    {
        private readonly ISt_StockMaster _stockMaster;
        private readonly IMapper _mapper;
        private readonly string connectionString;

        public St_StockMasterController(ISt_StockMaster stockMaster, IMapper mapper, IConfiguration configuration)
        {
            _stockMaster = stockMaster;
            _mapper = mapper;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllStockMaster()
        
        {

            var stockMaster = await _stockMaster.GetAll();
            return Ok(stockMaster);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStockMaster([FromBody]CreateStockMasterVM stockMaster)
        {
            if (ModelState.IsValid)
            {
                var newStockMaster = _mapper.Map<CreateStockMasterVM, St_StockMaster>(stockMaster);
                newStockMaster.CreatedOn = DateTime.Now;
                await _stockMaster.CreateAsync(newStockMaster);

                return CreatedAtAction("GetAllStockMaster", new { newStockMaster.ItemCode}, newStockMaster);
            }

            return BadRequest("Something went wrong please try again");
        }

        [HttpGet("{itemCode}")]
        public IActionResult GetByItemCode(string itemCode)
        {
            var stockMasterInDb = _stockMaster.GetByItemCode(itemCode);

            if (stockMasterInDb==null)
                return NotFound("Item does not exist");

            return Ok(stockMasterInDb);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateStockMaster([FromBody]UpdateStockMasterVM stockMaster)
        {
            var stockMasterInDb = _stockMaster.GetByItemCode(stockMaster.ItemCode);

            if (stockMasterInDb == null)
                return NotFound("Item does not exist");

            _mapper.Map(stockMaster, stockMasterInDb);

            stockMasterInDb.UpdatedOn = DateTime.Now;

            await _stockMaster.UpdateAsync(stockMasterInDb);

            return Ok(stockMasterInDb);
        }

        [HttpPatch("{itemCode}")]
        public async Task<IActionResult> DeleteStockMaster(string itemCode)
        {
            var stockMasterInDb = _stockMaster.GetByItemCode(itemCode);

            if (stockMasterInDb == null)
                return NotFound("Item does not exist");

            await _stockMaster.Delete(itemCode);

            return Ok(stockMasterInDb);
        }

        [Route("physicalcount")]
        [HttpGet]
        public async Task<IActionResult> GetCountSheet()
        {
            var stkposition = await _stockMaster.PhysicalCounts();
            return Ok(stkposition);
        }

        [Route("UpdatePhysicalCount")]
        [HttpPut]
        public IActionResult UpdatePhysicalCount([FromBody] PhysicalCountVM physicalCount)
        {
            foreach (var item in physicalCount.PhysicalCountSheet)
            {

                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_updatephysicalcount", sqlcon))
                    {
                        cmd.CommandTimeout = 1200;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@itemcode", item.ItemCode));
                        cmd.Parameters.Add(new SqlParameter("@quantity", item.Quantity));

                        sqlcon.Open();
                        cmd.ExecuteNonQuery();
                    }
                } 
            }

            return Ok(/*stockMasterInDb*/);
        }

        //excel upload
        [Route("updatephysicalcountexcel")]
        [HttpPost]
        public async Task<IActionResult> UpdatePhysicalCount(IFormFile file, CancellationToken cancellationToken)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("No File Uploaded");
            }

            if (!Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("File not an Excel Format");
            }

            var listapplication = new List<PhysicalCountSheetVM>();
            var listapplicationofrecordnotavailable = new List<PhysicalCountSheetVM>();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream, cancellationToken);

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
                        string quantity = String.IsNullOrEmpty(worksheet.Cells[row, 3].Value.ToString()) ? "" : worksheet.Cells[row, 3].Value.ToString().Trim();
                        //float quantity = String.IsNullOrEmpty(worksheet.Cells[row, 3].Value.ToString()) ? float.Parse("0") : (float)worksheet.Cells[row, 3].Value;
                       

                        if (String.IsNullOrEmpty(worksheet.Cells[row, 1].Value.ToString()) && 
                            String.IsNullOrEmpty(worksheet.Cells[row, 3].Value.ToString()))
                        {
                            listapplicationofrecordnotavailable.Add(new PhysicalCountSheetVM
                            {
                                ItemCode = itemcode,
                                ItemDesc = itemDesc,
                                Quantity = float.Parse(quantity),
                                
                            });

                        }
                        else
                        {
                            //check if already in the list -- a possibility
                            listapplication.Add(new PhysicalCountSheetVM
                            {
                                ItemCode = itemcode,
                                ItemDesc = itemDesc,
                                Quantity = float.Parse(quantity),
                            });
                        }

                    }

                    await _stockMaster.UpdateWithExcelFile(listapplication);

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

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
            return Ok();
        }
    }
}
