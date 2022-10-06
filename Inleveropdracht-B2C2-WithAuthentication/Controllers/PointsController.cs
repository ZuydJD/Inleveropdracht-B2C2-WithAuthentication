using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inleveropdracht_B2C2_WithAuthentication.Data;
using Inleveropdracht_B2C2_WithAuthentication.Models;

namespace Inleveropdracht_B2C2_WithAuthentication.Controllers
{
    public class PointsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PointsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Points
        public async Task<IActionResult> Index()
        {
              return View(await _context.Points.ToListAsync());
        }

        // GET: Points/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Points == null)
            {
                return NotFound();
            }

            var punten = await _context.Points
                .FirstOrDefaultAsync(m => m.Id == id);
            if (punten == null)
            {
                return NotFound();
            }

            return View(punten);
        }

        // GET: Points/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Points/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rang,Naam,Points")] Punten punten)
        {
            if (ModelState.IsValid)
            {
                _context.Add(punten);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(punten);
        }

        // GET: Points/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Points == null)
            {
                return NotFound();
            }

            var punten = await _context.Points.FindAsync(id);
            if (punten == null)
            {
                return NotFound();
            }
            return View(punten);
        }

        // POST: Points/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rang,Naam,Points")] Punten punten)
        {
            if (id != punten.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(punten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuntenExists(punten.Id))
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
            return View(punten);
        }

        // GET: Points/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Points == null)
            {
                return NotFound();
            }

            var punten = await _context.Points
                .FirstOrDefaultAsync(m => m.Id == id);
            if (punten == null)
            {
                return NotFound();
            }

            return View(punten);
        }

        // POST: Points/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Points == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Puntens'  is null.");
            }
            var punten = await _context.Points.FindAsync(id);
            if (punten != null)
            {
                _context.Points.Remove(punten);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuntenExists(int id)
        {
          return _context.Points.Any(e => e.Id == id);
        }
    }
}
