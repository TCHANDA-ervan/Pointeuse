using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pointeuse.Models;

namespace Pointeuse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneesController : ControllerBase
    {
        private readonly ClasseContext _context;

        public JourneesController(ClasseContext context)
        {
            _context = context;
        }

        // GET: api/Journees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Journee>>> Getjournee()
        {
          if (_context.journee == null)
          {
              return NotFound();
          }
            return await _context.journee.ToListAsync();
        }

        // GET: api/Journees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Journee>> GetJournee(int id)
        {
          if (_context.journee == null)
          {
              return NotFound();
          }
            var journee = await _context.journee.FindAsync(id);

            if (journee == null)
            {
                return NotFound();
            }

            return journee;
        }

        // PUT: api/Journees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJournee(int id, Journee journee)
        {
            if (id != journee.Id)
            {
                return BadRequest();
            }

            _context.Entry(journee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JourneeExists(id))
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

        // POST: api/Journees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Journee>> PostJournee(Journee journee)
        {
          if (_context.journee == null)
          {
              return Problem("Entity set 'ClasseContext.journee'  is null.");
          }
            _context.journee.Add(journee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJournee", new { id = journee.Id }, journee);
        }

        // DELETE: api/Journees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJournee(int id)
        {
            if (_context.journee == null)
            {
                return NotFound();
            }
            var journee = await _context.journee.FindAsync(id);
            if (journee == null)
            {
                return NotFound();
            }

            _context.journee.Remove(journee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JourneeExists(int id)
        {
            return (_context.journee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
