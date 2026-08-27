using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmWebAPI.AppDatabase;
using FarmWebAPI.Domain.Farmer;

namespace FarmWebAPI.Controllers.Farmer
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerDocumentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FarmerDocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FarmerDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FarmerDocument>>> GetFarmerDocuments()
        {
            return await _context.FarmerDocuments.ToListAsync();
        }

        // GET: api/FarmerDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FarmerDocument>> GetFarmerDocument(int id)
        {
            var farmerDocument = await _context.FarmerDocuments.FindAsync(id);

            if (farmerDocument == null)
            {
                return NotFound();
            }

            return farmerDocument;
        }

        // PUT: api/FarmerDocuments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmerDocument(int id, FarmerDocument farmerDocument)
        {
            if (id != farmerDocument.Id)
            {
                return BadRequest();
            }

            _context.Entry(farmerDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerDocumentExists(id))
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

        // POST: api/FarmerDocuments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FarmerDocument>> PostFarmerDocument(FarmerDocument farmerDocument)
        {
            _context.FarmerDocuments.Add(farmerDocument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFarmerDocument", new { id = farmerDocument.Id }, farmerDocument);
        }

        // DELETE: api/FarmerDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmerDocument(int id)
        {
            var farmerDocument = await _context.FarmerDocuments.FindAsync(id);
            if (farmerDocument == null)
            {
                return NotFound();
            }

            _context.FarmerDocuments.Remove(farmerDocument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FarmerDocumentExists(int id)
        {
            return _context.FarmerDocuments.Any(e => e.Id == id);
        }
    }
}
