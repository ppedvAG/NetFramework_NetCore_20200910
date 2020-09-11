using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoDB.SharedLibrary.Models;
using GeoDBWebAPI.Data;

namespace GeoWebMVC.Controllers
{
    public class ContinentController : Controller
    {
        private readonly GeoDBContext _context;

        public ContinentController(GeoDBContext context)
        {
            _context = context;
        }

        // GET: Continent
        public async Task<IActionResult> Index()
        {
            return View(await _context.Continents.ToListAsync());
        }

        // GET: Continent/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var continents = await _context.Continents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (continents == null)
            {
                return NotFound();
            }

            return View(continents);
        }

        // GET: Continent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Continent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Continents continents)
        {
            if (ModelState.IsValid)
            {
                continents.Id = Guid.NewGuid();
                _context.Add(continents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(continents);
        }

        // GET: Continent/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var continents = await _context.Continents.FindAsync(id);
            if (continents == null)
            {
                return NotFound();
            }
            return View(continents);
        }

        // POST: Continent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Continents continents)
        {
            if (id != continents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(continents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContinentsExists(continents.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(continents);
        }

        // GET: Continent/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var continents = await _context.Continents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (continents == null)
            {
                return NotFound();
            }

            return View(continents);
        }

        // POST: Continent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var continents = await _context.Continents.FindAsync(id);
            _context.Continents.Remove(continents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContinentsExists(Guid id)
        {
            return _context.Continents.Any(e => e.Id == id);
        }
    }
}
