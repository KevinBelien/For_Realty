using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using For_Realty.Data;
using For_Realty.Models;
using For_Realty.Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace For_Realty.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public AgencyController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Agency
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agency>>> GetAgencies()
        {
            return await _uow.AgencyRepository.GetAll().ToListAsync();
        }

        // GET: api/Agency/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agency>> GetAgency(int id)
        {
            var agency = await _uow.AgencyRepository.GetById(id);

            if (agency == null)
            {
                return NotFound();
            }

            return agency;
        }

        // GET: api/Agency/list
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Agency>>> GetAgencyList()
        {
            return await _uow.AgencyRepository.GetAll()
                .Include(a => a.RealEstates)
                .ToListAsync();
        }

        // PUT: api/Agency/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgency(int id, Agency agency)
        {
            if (id != agency.AgencyID)
            {
                return BadRequest();
            }

            _uow.AgencyRepository.Create(agency);
            await _uow.Save();

            return NoContent();
        }

        // POST: api/Agency
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Agency>> PostAgency(Agency agency)
        {
            _uow.AgencyRepository.Create(agency);
            await _uow.Save();

            return CreatedAtAction("GetAgency", new { id = agency.AgencyID }, agency);
        }

        // DELETE: api/Agency/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Agency>> DeleteAgency(int id)
        {
            var agency = await _uow.AgencyRepository.GetById(id);

            if (agency == null)
            {
                return NotFound();
            }

            _uow.AgencyRepository.Delete(agency);
            await _uow.Save();

            return NoContent();
        }
    }
}
