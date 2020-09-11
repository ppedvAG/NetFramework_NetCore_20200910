using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeoDB.SharedLibrary.Models;
using GeoDBWebAPI.Data;

namespace GeoDBWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentController : ControllerBase
    {
        private readonly GeoDBContext _context;

        public ContinentController(GeoDBContext context)
        {
            _context = context;
        }

        // GET: api/Continent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Continents>>> GetContinents()
        {
            return await _context.Continents.ToListAsync();
        }

        // GET: api/Continent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Continents>> GetContinents(Guid id)
        {
            var continents = await _context.Continents.FindAsync(id);

            if (continents == null)
            {
                return NotFound();
            }

            return continents;
        }

        // PUT: api/Continent/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContinents(Guid id, Continents continents)
        {
            if (id != continents.Id)
            {
                return BadRequest();
            }

            _context.Entry(continents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContinentsExists(id))
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

        // POST: api/Continent
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Continents>> PostContinents(Continents continents)
        {
            _context.Continents.Add(continents);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContinentsExists(continents.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContinents", new { id = continents.Id }, continents);
        }

        // DELETE: api/Continent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Continents>> DeleteContinents(Guid id)
        {
            var continents = await _context.Continents.FindAsync(id);
            if (continents == null)
            {
                return NotFound();
            }

            _context.Continents.Remove(continents);
            await _context.SaveChangesAsync();

            return continents;
        }

        private bool ContinentsExists(Guid id)
        {
            return _context.Continents.Any(e => e.Id == id);
        }
    }
}
