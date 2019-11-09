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
    public class SetController : ControllerBase
    {
        private readonly LegoContext _context;

        public SetController(LegoContext context)
        {
            _context = context;
        }

        // GET: api/Set
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Set>>> GetSets()
        {
            return await _context.Sets.ToListAsync();
        }

        // GET: api/SetWithParts
        [HttpGet]
        [Route("SetWithParts")]
        public async Task<ActionResult<IEnumerable<Set>>> GetSetsWithParts()
        {
            return await _context.Sets
                .Include(e => e.Images)
                .Include(e => e.Dimensions)
                .Include(e => e.SetParts).ThenInclude(e=>e.Part).ThenInclude(e=>e.Images)
                .ToListAsync();
        }

        // GET: api/Set/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Set>> GetSet(long id)
        {
            var @set = await _context.Sets.FindAsync(id);

            if (@set == null)
            {
                return NotFound();
            }

            return @set;
        }

        // PUT: api/Set/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSet(long id, Set @set)
        {
            if (id != @set.SetID)
            {
                return BadRequest();
            }

            _context.Entry(@set).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetExists(id))
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

        // POST: api/Set
        [HttpPost]
        public async Task<ActionResult<Set>> PostSet(Set @set)
        {
            _context.Sets.Add(@set);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSet", new { id = @set.SetID }, @set);
        }

        // DELETE: api/Set/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Set>> DeleteSet(long id)
        {
            var @set = await _context.Sets.FindAsync(id);
            if (@set == null)
            {
                return NotFound();
            }

            _context.Sets.Remove(@set);
            await _context.SaveChangesAsync();

            return @set;
        }

        private bool SetExists(long id)
        {
            return _context.Sets.Any(e => e.SetID == id);
        }
    }
}
