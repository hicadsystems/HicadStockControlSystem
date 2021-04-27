using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_ItemMaster;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [Route("api/itemmaster")]
    [ApiController()]
    public class St_ItemMasterController : ControllerBase
    {
        private readonly ISt_ItemMaster _itemMaster;
        private readonly IMapper _mapper;
        public St_ItemMasterController(ISt_ItemMaster itemMaster, IMapper mapper)
        {
            _itemMaster = itemMaster;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllItemMaster()
        {
            var itemMaster = _itemMaster.GetAll();
            return Ok(itemMaster);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItemMaster([FromBody] CreateSt_ItemMasterVM itemMasterVM)
        {
            if (ModelState.IsValid)
            {
                var newitemMaster = _mapper.Map<CreateSt_ItemMasterVM, St_ItemMaster>(itemMasterVM);

                newitemMaster.CreatedOn = DateTime.Now;

                await _itemMaster.CreateAsync(newitemMaster);

                return Ok(newitemMaster);
            }

            return BadRequest();
        }

        [HttpGet("{itemcode}")]
        public IActionResult GetItemMasterByCode(string itemcode)
        {
            var itemMasterInDb = _itemMaster.GetByCode(itemcode);
            if (itemMasterInDb == null)
                return NotFound();

            return Ok(itemMasterInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemMaster([FromBody] UpdateSt_ItemMasterVM itemMasterVM)
        {
            var itemMasterInDb = _itemMaster.GetByCode(itemMasterVM.ItemCode);
            if (itemMasterInDb == null)
                return NotFound();

            _mapper.Map(itemMasterVM, itemMasterInDb);
            itemMasterInDb.UpdatedOn = DateTime.Now;
            await _itemMaster.UpdateAsync(itemMasterInDb);

            return Ok(itemMasterInDb);
        }

        [HttpDelete("{itemcode}")]
        public async Task<IActionResult> DeleteItemMaster(string itemcode)
        {
            var itemMasterInDb = _itemMaster.GetByCode(itemcode);
            if (itemMasterInDb == null)
                return NotFound();

            await _itemMaster.DeleteAsync(itemcode);

            return Ok(itemMasterInDb);
        }

    }
}
