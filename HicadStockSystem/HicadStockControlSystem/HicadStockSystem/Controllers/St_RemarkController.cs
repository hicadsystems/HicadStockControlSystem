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
    [Route("api/remarks")]
    public class St_RemarkController : ControllerBase
    {
        private readonly ISt_Remark _remark;

        public St_RemarkController(ISt_Remark remark)
        {
            _remark = remark;
        }

        [HttpGet]
        public IActionResult GetAllRemarks()
        {
            var remarks = _remark.GetAll();
            return Ok(remarks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRemark([FromBody]St_Remark st_remark)
        {
            if (ModelState.IsValid)
            {
                st_remark.CreatedOn = DateTime.Now;
                await _remark.CreateAsync(st_remark);
                return Ok(st_remark);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var st_remarkInDb = _remark.GetById(id);
            return Ok(st_remarkInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRemark([FromBody]St_Remark st_remark)
        {
            var remarkInDb = _remark.GetById(st_remark.Id);
            if (remarkInDb == null)
                return NotFound();

            remarkInDb.UpdatedOn = DateTime.Now;
            await _remark.UpdateAsync(remarkInDb);

            return Ok(remarkInDb);
        }

        [HttpPatch("{id}")]
        public IActionResult DeleteRemark(int id)
        {
            var remarkInDb = _remark.GetById(id);
            if (remarkInDb == null)
                return NotFound();

            return Ok(remarkInDb);
        }
    }
}
