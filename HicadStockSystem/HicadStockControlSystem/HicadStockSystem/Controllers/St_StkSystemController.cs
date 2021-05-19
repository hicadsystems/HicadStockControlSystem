using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_StkSystem;
using HicadStockSystem.Core;
using HicadStockSystem.Models;
using HicadStockSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [Route("api/st_stksystem")] //api/st_stksystem
    [ApiController()]
    public class St_StkSystemController : ControllerBase
    {
        private readonly ISt_StkSystem _systemRepo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public St_StkSystemController(ISt_StkSystem systemRepo, IUnitOfWork uow, IMapper mapper)
        {
            _systemRepo = systemRepo;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStkSystem()
        {
            //_systemRepo.GetAllState();
            var stkSystem = await _systemRepo.GetAll();
            return Ok(stkSystem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSktSystem([FromBody] CreateSt_StkSystemVM stkSystemVM)
        {
            if (ModelState.IsValid)
            {
                var st_stkSytem = _mapper.Map<CreateSt_StkSystemVM, St_StkSystem>(stkSystemVM);
                st_stkSytem.CreatedOn = DateTime.Now;
                st_stkSytem.InstallDate = DateTime.Now;
                await _systemRepo.CreateAsync(st_stkSytem);
                await _uow.CompleteAsync();
                return CreatedAtAction("GetStkSystem", new { st_stkSytem.CompanyName, st_stkSytem.CompanyCode }, st_stkSytem);
            }

            return new JsonResult("Something went wrong. Please try again") { StatusCode = 500 };
        }

        [HttpGet("{coycode}")]
        public IActionResult GetSystem(string coycode)
        {
            var sktSystem = _systemRepo.GetByCompanyCode(coycode);
            if (sktSystem==null)
                return NotFound();
            return Ok(sktSystem);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSktSystem([FromBody] UpdateSt_StkSystemVM stkSystemVM)
        {
            var validSktSystem = _systemRepo.GetByCompanyCode(stkSystemVM.CompanyCode);

            if (validSktSystem == null)
                return NotFound();

            _mapper.Map<UpdateSt_StkSystemVM, St_StkSystem>(stkSystemVM, validSktSystem);
            validSktSystem.UpdatedOn = DateTime.Now;
           
            await _systemRepo.UpdateAsync(validSktSystem);
            return Ok(validSktSystem);
        }

       [HttpDelete("{coycode}")]
       public async Task<IActionResult> DeleteStkSystem(string coycode)
        {
            var validStkSystem = _systemRepo.GetByCompanyCode(coycode);

            if (validStkSystem == null)
                return NotFound();
            await _systemRepo.Delete(coycode);
            await _uow.CompleteAsync();

            return Ok(validStkSystem);
        }

        [HttpGet]
        [Route("getstates")]
        public async Task<IActionResult> GetStates()
        {
            var states = await _systemRepo.GetAllState();
            return Ok(states);
        }

        [HttpGet]
        [Route("GetWriteOffLoc")]
        public async Task<IActionResult> GetWriteOffLoc()
        {
            var costcenter = await _systemRepo.GetCostCenter();
            return Ok(costcenter);
        }

        [HttpGet]
        [Route("GetAccChart")]
        public async Task<IActionResult> GetAccChart()
        {
            var accChart = await _systemRepo.GetAccChart();
            return Ok(accChart);
        }


        [HttpGet]
        [Route("GetGLCode")]
        public async Task<IActionResult> GetGLCode()
        {
            var accChart = await _systemRepo.GetGLCode();
            return Ok(accChart);
        }


        [HttpGet]
        [Route("GetCreditorCode")]
        public async Task<IActionResult> GetCreditorCode()
        {
            var accChart = await _systemRepo.GetCreditorCode();
            return Ok(accChart);
        }


        [HttpGet]
        [Route("GetExpenseCode")]
        public async Task<IActionResult> GetExpenseCode()
        {
            var accChart = await _systemRepo.GetExpenseCode();
            return Ok(accChart);
        }

        [HttpGet]
        [Route("GetBusinessLine")]
        public async Task<IActionResult> GetBusinessLine()
        {
            var busLine = await _systemRepo.GetBusLine();
            return Ok(busLine);
        }
    }
}
