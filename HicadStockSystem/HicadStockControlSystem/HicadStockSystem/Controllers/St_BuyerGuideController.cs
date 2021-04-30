using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_BuyerGuide;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [Route("api/buyerguide")]
    [ApiController()]
    public class St_BuyerGuideController : ControllerBase
    {
        private readonly ISt_BuyerGuide _buyerGuide;
        private readonly IMapper _mapper;

        public St_BuyerGuideController(ISt_BuyerGuide buyerGuide, IMapper mapper)
        {
            _buyerGuide = buyerGuide;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBuyerGuide()
        {
            var buyerGuide = await _buyerGuide.GetAll();
            return Ok(buyerGuide);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBuyerGuide([FromBody]CreateSt_BuyerGuideVM buyerGuideVM)
        {
            if (ModelState.IsValid)
            {
                var newBuyerGuide = _mapper.Map<CreateSt_BuyerGuideVM, St_BuyerGuide>(buyerGuideVM);
                newBuyerGuide.DateCreated = DateTime.Now;
                await _buyerGuide.CreateAsync(newBuyerGuide);

                return Ok(newBuyerGuide);
            }

            return BadRequest();
        }

        [HttpGet("{itemCode}")]
        public IActionResult GetBuyerGuideByCode(string itemCode)
        {
            var buyerGuideInDb = _buyerGuide.GetByItemCode(itemCode);

            if (buyerGuideInDb == null)
                return NotFound();

            return Ok(buyerGuideInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBuyerGuide([FromBody]CreateSt_BuyerGuideVM buyerGuideVM)
        {
            var buyerGuideInDb = _buyerGuide.GetByItemCode(buyerGuideVM.ItemCode);

            if (buyerGuideInDb == null)
                return NotFound();

            _mapper.Map(buyerGuideVM, buyerGuideInDb);
            buyerGuideInDb.UpdatedOn = DateTime.Now;
            await _buyerGuide.UpdateAsync(buyerGuideInDb);

            return Ok(buyerGuideInDb);
        }

        [HttpDelete("{itemCode}")]
        public async Task<IActionResult> DeleteBuyerGuide(string itemCode)
        {
            var buyerGuideInDb = _buyerGuide.GetByItemCode(itemCode);

            if (buyerGuideInDb == null)
                return NotFound();

            await _buyerGuide.DeleteAsync(itemCode);
            return Ok(buyerGuideInDb);
        }

    }
}
