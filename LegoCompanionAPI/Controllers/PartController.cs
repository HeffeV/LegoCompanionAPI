using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LegoCompanionAPI.Models;

namespace LegoCompanionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly LegoContext _context;

        public PartController(LegoContext context)
        {
            _context = context;
        }

        // GET: api/Part
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Part>>> GetParts()
        {
            return await _context.Parts.ToListAsync();
        }

        // GET: api/Part/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Part>> GetPart(long id)
        {
            Part part = await _context.Parts
                .Include(e => e.Images)
                .Include(e => e.SetParts).ThenInclude(e => e.Set).ThenInclude(e => e.Images)
                .Include(e => e.SetParts).ThenInclude(e => e.Set).ThenInclude(e => e.Dimensions).FirstOrDefaultAsync(e=>e.PartID==id);

            if (part == null)
            {
                return NotFound();
            }

            return part;
        }

        [HttpGet]
        [Route("PartsWithSets")]
        public async Task<ActionResult<IEnumerable<Part>>> GetPartsWithSets()
        {
            return await _context.Parts
                .Include(e => e.Images)
                .Include(e => e.SetParts).ThenInclude(e => e.Set).ThenInclude(e => e.Images)
                .Include(e => e.SetParts).ThenInclude(e => e.Set).ThenInclude(e => e.Dimensions)
                .ToListAsync();
        }

        // PUT: api/Part/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPart(long id, Part part)
        {
            if (id != part.PartID)
            {
                return BadRequest();
            }

            _context.Entry(part).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(id))
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

        // POST: api/Part
        [HttpPost]
        public async Task<ActionResult<Part>> PostPart(Part part)
        {
            _context.Parts.Add(part);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPart", new { id = part.PartID }, part);
        }

        // DELETE: api/Part/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Part>> DeletePart(long id)
        {
            var part = await _context.Parts.FindAsync(id);
            if (part == null)
            {
                return NotFound();
            }

            _context.Parts.Remove(part);
            await _context.SaveChangesAsync();

            return part;
        }

        private bool PartExists(long id)
        {
            return _context.Parts.Any(e => e.PartID == id);
        }
    }
}
