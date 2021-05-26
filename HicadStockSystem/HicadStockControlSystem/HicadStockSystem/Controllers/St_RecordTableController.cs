using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_RecordTable;
using HicadStockSystem.Controllers.ResourcesVM.St_Supplier;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [ApiController()]
    [Route("api/recordtable")]
    public class St_RecordTableController : ControllerBase
    {
        private readonly ISt_RecordTable _recordTable;
        private readonly IMapper _mapper;

        public St_RecordTableController(ISt_RecordTable recordTable, IMapper mapper)
        {
            _recordTable = recordTable;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecordTable()
        {
            var recordTable = await _recordTable.GetAll();
            return Ok(recordTable);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecordTable([FromBody] CreateSt_RecordTableVM recordVM)
        {
            if (ModelState.IsValid)
            {
                var newRecordTable = _mapper.Map<CreateSt_RecordTableVM, St_RecordTable>(recordVM);

                newRecordTable.CreatedOn = DateTime.Now;

                await _recordTable.CreateAsync(newRecordTable);

                return Ok(newRecordTable);
            }

            return BadRequest();
        }

        [HttpGet("{code}")]
        public IActionResult GetRecordTableByCode(string code)
        {
            var recordTableInDb = _recordTable.GetByCode(code);
            if (recordTableInDb == null)
                return NotFound();

            return Ok(recordTableInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecordTable([FromBody] UpdateSt_RecordTableVM recordVM)
        {
            var recordTableInDb = _recordTable.GetByCode(recordVM.Code);
            if (recordTableInDb == null)
                return NotFound();

            _mapper.Map(recordVM, recordTableInDb);
            recordTableInDb.UpdatedOn = DateTime.Now;
            await _recordTable.UpdateAsync(recordTableInDb);

            return Ok(recordTableInDb);
        }

        [HttpPatch("{code}")]
        public async Task<IActionResult> DeleteRecordTable(string code)
        {
            var recordTableInDb = _recordTable.GetByCode(code);
            if (recordTableInDb == null)
                return NotFound();

            await _recordTable.DeleteAsync(code);

            return Ok(recordTableInDb);
        }
    }
}
