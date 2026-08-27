using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmWebAPI.AppDatabase;
using FarmWebAPI.Domain.Common;

namespace FarmWebAPI.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BusinessUnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BusinessUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessUnit>>> GetBusinessUnits()
        {
            return await _context.BusinessUnits.ToListAsync();
        }

        // GET: api/BusinessUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessUnit>> GetBusinessUnit(int id)
        {
            var businessUnit = await _context.BusinessUnits.FindAsync(id);

            if (businessUnit == null)
            {
                return NotFound();
            }

            return businessUnit;
        }

        // PUT: api/BusinessUnits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessUnit(int id, BusinessUnit businessUnit)
        {
            if (id != businessUnit.Id)
            {
                return BadRequest();
            }

            _context.Entry(businessUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessUnitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BusinessUnits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusinessUnit>> PostBusinessUnit(BusinessUnit businessUnit)
        {
            _context.BusinessUnits.Add(businessUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessUnit", new { id = businessUnit.Id }, businessUnit);
        }

        // DELETE: api/BusinessUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessUnit(int id)
        {
            var businessUnit = await _context.BusinessUnits.FindAsync(id);
            if (businessUnit == null)
            {
                return NotFound();
            }

            _context.BusinessUnits.Remove(businessUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinessUnitExists(int id)
        {
            return _context.BusinessUnits.Any(e => e.Id == id);
        }
    }
}
