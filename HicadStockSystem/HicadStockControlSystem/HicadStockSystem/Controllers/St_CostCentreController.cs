using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM;
using HicadStockSystem.Controllers.ResourcesVM.St_CostCentre;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [Route("api/costcentre")]
    [ApiController()]
    public class St_CostCentreController : ControllerBase
    {
        private readonly ISt_CostCentre _costCentre;
        private readonly IMapper _mapper;

        public St_CostCentreController(ISt_CostCentre costCentre, IMapper mapper)
        {
            _costCentre = costCentre;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCostCenter()
        {
            var costCenter = await _costCentre.GetAll();
            return Ok(costCenter);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCostCenter([FromBody]CreateSt_CostCentreVM costCentreVM)
        {
            if (ModelState.IsValid)
            {
                var newCostCenter = _mapper.Map<CreateSt_CostCentreVM, St_CostCentre>(costCentreVM);
                newCostCenter.DateCreated = DateTime.Now;
                await _costCentre.CreateAsync(newCostCenter);
                return Ok(newCostCenter);
            }

            return BadRequest();
        }

        [HttpGet("{unitCode}")]
        public IActionResult GetCostCenterByCode(string unitCode)
        {
            var costCenterInDb = _costCentre.GetByItemCode(unitCode);
            if (costCenterInDb == null)
                return NotFound();
            return Ok(costCenterInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCostCenter([FromBody]UpdateSt_CostCentreVM costCentreVM)
        {
            var costCenterInDb = _costCentre.GetByItemCode(costCentreVM.UnitCode);

            if (costCenterInDb == null)
                return NotFound();

            _mapper.Map(costCentreVM, costCenterInDb);
            costCenterInDb.UpdatedOn = DateTime.Now;
            await _costCentre.UpdateAsync(costCenterInDb);

            return Ok(costCenterInDb);
        }

        [HttpPatch("{unitCode}")]
        public async Task<IActionResult> DeleteCostCenter(string unitCode)
        {
            var costCenterInDb = _costCentre.GetByItemCode(unitCode);

            if (costCenterInDb == null)
                return NotFound();

            await _costCentre.DeleteAsync(unitCode);
            return Ok(costCenterInDb);
        }

    }
}
