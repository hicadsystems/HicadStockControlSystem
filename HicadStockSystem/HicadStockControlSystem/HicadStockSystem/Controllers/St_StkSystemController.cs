using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_StkSystem;
using HicadStockSystem.Core;
using HicadStockSystem.Data;
using HicadStockSystem.Models;
using HicadStockSystem.Persistence;
using HicadStockSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public  IActionResult GetStkSystem()
        {
            _systemRepo.GetAllState();
            var stkSystem = _systemRepo.GetAll();
            return Ok(stkSystem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSktSystem([FromBody] CreateSt_StkSystemVM stkSystemVM)
        {
            if (ModelState.IsValid)
            {
                var st_stkSytem = _mapper.Map<CreateSt_StkSystemVM, St_StkSystem>(stkSystemVM);
                st_stkSytem.CreatedOn = DateTime.UtcNow;
                st_stkSytem.InstallDate = DateTime.UtcNow;
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
            stkSystemVM.UpdatedOn = DateTime.UtcNow;
            //validSktSystem.CompanyName = stkSystem.CompanyName;
            //validSktSystem.CompanyAddress = stkSystem.CompanyAddress;
            //validSktSystem.Town_City = stkSystem.Town_City;
            //validSktSystem.State = stkSystem.State;
            //validSktSystem.Phone = stkSystem.Phone;
            //validSktSystem.Email = stkSystem.Email;
            //validSktSystem.SerialNumber = stkSystem.SerialNumber;
            //validSktSystem.GLCode = stkSystem.GLCode;
            //validSktSystem.UpdatedOn = stkSystem.UpdatedOn = DateTime.Now;

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
        public IActionResult GetStates()
        {
            var states = _systemRepo.GetAllState();
            return Ok(states);
        }
    }
}
