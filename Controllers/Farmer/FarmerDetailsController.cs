using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmWebAPI.AppDatabase;
using FarmWebAPI.Domain.Farmer;
using FarmWebAPI.Migrations;

namespace FarmWebAPI.Controllers.Farmer
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FarmerDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Farmers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FarmerDetail>>> GetFarmers()
        {
            return await _context.FarmerDetails.ToListAsync();
        }

        // GET: api/Farmers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FarmerDetail>> GetFarmer(int id)
        {
            var farmer = await _context.FarmerDetails.FindAsync(id);

            if (farmer == null)
            {
                return NotFound();
            }

            return farmer;
        }

        // PUT: api/Farmers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmer(int id, FarmerDetail farmer)
        {
            if (id != farmer.Id)
            {
                return BadRequest();
            }

            _context.Entry(farmer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerExists(id))
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

        // POST: api/Farmers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FarmerDetail>> PostFarmer(FarmerDetail farmer)
        {
            _context.FarmerDetails.Add(farmer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFarmer", new { id = farmer.Id }, farmer);
        }

        // DELETE: api/Farmers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmer(int id)
        {
            var farmer = await _context.FarmerDetails.FindAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }

            _context.FarmerDetails.Remove(farmer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FarmerExists(int id)
        {
            return _context.FarmerDetails.Any(e => e.Id == id);
        }
    }
}
