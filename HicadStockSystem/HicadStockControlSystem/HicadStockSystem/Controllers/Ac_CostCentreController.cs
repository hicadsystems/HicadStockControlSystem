using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.Ac_CostCentre;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [Route("api/ac_costcenter")]
    [ApiController()]
    public class Ac_CostCentreController : ControllerBase
    {
        private readonly IAc_CostCentre _costCentre;
        private readonly IMapper _mapper;

        public Ac_CostCentreController(IAc_CostCentre costCentre, IMapper mapper)
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
        public async Task<IActionResult> CreateAC_CostCenter([FromBody]CreateAc_CostCentreVM costCentreVM)
        {
            if (ModelState.IsValid)
            {
                var newCostCenter = _mapper.Map<CreateAc_CostCentreVM, Ac_CostCentre>(costCentreVM);
                newCostCenter.DateCreated = DateTime.Now;
                await _costCentre.CreateAsync(newCostCenter);

                return Ok(newCostCenter);
            }

            return BadRequest();

        }

        [HttpGet("{code}")]
        public IActionResult GetCostCenterByCode(string code)
        {
            var costCenterInDb = _costCentre.GetByCode(code);

            if (costCenterInDb == null)
                return NotFound();

            return Ok(costCenterInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCostCenter([FromBody] UpdateAc_CostCentreVM costCentreVM)
        {
            var costCenterInDb = _costCentre.GetByCode(costCentreVM.UnitCode);

            if (costCenterInDb == null)
                return NotFound();

            _mapper.Map(costCentreVM, costCenterInDb);
            costCenterInDb.UpdatedOn = DateTime.Now;
            await _costCentre.UpdateAsync(costCenterInDb);

            return Ok(costCenterInDb);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteCostCenter(string code)
        {
            var costCenterInDb = _costCentre.GetByCode(code);

            if (costCenterInDb == null)
                return NotFound();

            await _costCentre.DeleteAsync(code);
            return Ok(costCenterInDb);
        }
    }
}
