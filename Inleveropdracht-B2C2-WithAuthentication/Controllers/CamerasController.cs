using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inleveropdracht_B2C2_WithAuthentication.Data;
using Inleveropdracht_B2C2_WithAuthentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace Inleveropdracht_B2C2_WithAuthentication.Controllers
{
    public class CamerasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        AppUser? _currentAppUser;

        public CamerasController(ApplicationDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Cameras
        [Authorize]
        public async Task<IActionResult> Index()
        {
            _currentAppUser = await _userManager.GetUserAsync(User);
            var applicationDbContext = _context.Cameras.Where(c => c.AppUser == _currentAppUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cameras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cameras == null)
            {
                return NotFound();
            }

            var camera = await _context.Cameras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camera == null)
            {
                return NotFound();
            }

            return View(camera);
        }

        // GET: Cameras/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cameras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Naam,Soort,Plaats,Omschrijving,CameraImage")] Camera camera)
        {
            _currentAppUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                if (camera.CameraImage != null)
                {
                    string folder = "camera\\";
                    folder += Guid.NewGuid().ToString() + "_" + camera.CameraImage.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await camera.CameraImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    camera.CameraImageUrl = "/" + folder;
                }
                camera.AppUserId = _currentAppUser.Id;
                camera.AppUser = _currentAppUser;
                _currentAppUser.Punten += 100;
                _context.Add(camera);
                _context.Update(_currentAppUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(camera);
        }

        // GET: Cameras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cameras == null)
            {
                return NotFound();
            }

            var camera = await _context.Cameras.FindAsync(id);
            if (camera == null)
            {
                return NotFound();
            }
            return View(camera);
        }

        // POST: Cameras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Soort,Plaats,Omschrijving")] Camera camera)
        {
            if (id != camera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CameraExists(camera.Id))
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
            return View(camera);
        }

        // GET: Cameras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cameras == null)
            {
                return NotFound();
            }

            var camera = await _context.Cameras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camera == null)
            {
                return NotFound();
            }

            return View(camera);
        }

        // POST: Cameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cameras == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Camera'  is null.");
            }
            var camera = await _context.Cameras.FindAsync(id);
            if (camera != null)
            {
                _context.Cameras.Remove(camera);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CameraExists(int id)
        {
          return _context.Cameras.Any(e => e.Id == id);
        }
    }
}
