using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_StkJournal;
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
    [Route("api/journal")]
    public class St_StkJournalController : ControllerBase
    {
        private readonly ISt_StkJournal _journal;
        private readonly IMapper _mapper;

        public St_StkJournalController(ISt_StkJournal journal, IMapper mapper)
        {
            _journal = journal;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllJournal()
        {
            var journal = _journal.GetAll();

            return Ok(journal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJournal([FromBody] CreateSt_StkJournalVM journalVM)
        {
            if (ModelState.IsValid)
            {
                var newJournal = _mapper.Map<CreateSt_StkJournalVM, St_StkJournal>(journalVM);

                newJournal.CreatedOn = DateTime.Now;

                await _journal.CreateAsync(newJournal);

                return Ok(newJournal);
            }

            return BadRequest("Something went wrong please, try again");
        }

        [HttpGet("{coy}")]
        public IActionResult GetJournalByCompany(string coy)
        {
            var journalInDb = _journal.GetByCompany(coy);
            if (journalInDb == null)
                return NotFound();

            return Ok(journalInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJournal([FromBody] UpdateSt_StkJournalVM journalVM)
        {
            var journalInDb = _journal.GetByCompany(journalVM.Stk_Company);
            if (journalInDb == null)
                return NotFound();

            _mapper.Map(journalVM, journalInDb);

            journalInDb.UpdatedOn = DateTime.Now;
            await _journal.UpdateAsync(journalInDb);

            return Ok(journalInDb);
        }

        [HttpDelete("{coy}")]
        public async Task<IActionResult> DeleteJournal(string coy)
        {
            var journalInDb = _journal.GetByCompany(coy);
            if (journalInDb == null)
                return NotFound();

            await _journal.DeleteAsync(coy);
            return Ok(journalInDb);
        }
    }
}
