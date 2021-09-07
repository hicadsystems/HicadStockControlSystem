using AutoMapper;
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
    [Route("api/supplier")]
    public class St_SupplierController : ControllerBase
    {
        private readonly ISt_Supplier _supplier;
        private readonly IMapper _mapper;

        public St_SupplierController(ISt_Supplier supplier, IMapper mapper)
        {
            _supplier = supplier;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _supplier.GetAll();
            return Ok(suppliers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecordTable([FromBody]CreateSt_SupplierVM supplierVM)
        {
            if (ModelState.IsValid)
            {
                var newSupplier = _mapper.Map<CreateSt_SupplierVM, St_Supplier>(supplierVM);

                newSupplier.DateCreated = DateTime.Now.Date;

                await _supplier.CreateAsync(newSupplier);

                return Ok(new { Response="Create Successfully"});
            }

            return BadRequest();
        }

        [HttpGet("{code}")]
        public IActionResult GetSupplierByCode(string code)
        {
            var supplierInDb = _supplier.GetByCode(code);
            if (supplierInDb == null)
                return NotFound();

            return Ok(supplierInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSt_SupplierVM supplierVM)
        {
            var supplierInDb = _supplier.GetByCode(supplierVM.SupplierCode);
            if (supplierInDb == null)
                return NotFound();

            _mapper.Map(supplierVM, supplierInDb);
            supplierInDb.UpdatedOn = DateTime.Now;
            await _supplier.UpdateAsync(supplierInDb);

            return Ok(supplierInDb);
        }

        [HttpPatch("{code}")]
        public async Task<IActionResult> DeleteSupplier(string code)
        {
            var supplierInDb = _supplier.GetByCode(code);
            if (supplierInDb == null)
                return NotFound();

            await _supplier.DeleteAsync(code);

            return Ok(supplierInDb);
        }
    }
}
