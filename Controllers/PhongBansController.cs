using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using btEntityFramework.Models;

namespace btEntityFramework.Controllers
{
    public class PhongBansController : Controller
    {
        private readonly QuanLyCongTyContext _context;

        public PhongBansController(QuanLyCongTyContext context)
        {
            _context = context;
        }

        // GET: PhongBans
        public async Task<IActionResult> Index()
        {
            var quanLyCongTyContext = _context.PhongBans.Include(p => p.IdCongTyNavigation);
            return View(await quanLyCongTyContext.ToListAsync());
        }

        // GET: PhongBans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongBan = await _context.PhongBans
                .Include(p => p.IdCongTyNavigation)
                .FirstOrDefaultAsync(m => m.Mapb == id);
            if (phongBan == null)
            {
                return NotFound();
            }

            return View(phongBan);
        }

        // GET: PhongBans/Create
        public IActionResult Create()
        {
            ViewData["IdCongTy"] = new SelectList(_context.Congties, "IdCongTy", "IdCongTy");
            return View();
        }

        // POST: PhongBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mapb,Tenpb,IdCongTy")] PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongBan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCongTy"] = new SelectList(_context.Congties, "IdCongTy", "IdCongTy", phongBan.IdCongTy);
            return View(phongBan);
        }

        // GET: PhongBans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongBan = await _context.PhongBans.FindAsync(id);
            if (phongBan == null)
            {
                return NotFound();
            }
            ViewData["IdCongTy"] = new SelectList(_context.Congties, "IdCongTy", "IdCongTy", phongBan.IdCongTy);
            return View(phongBan);
        }

        // POST: PhongBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mapb,Tenpb,IdCongTy")] PhongBan phongBan)
        {
            if (id != phongBan.Mapb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phongBan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongBanExists(phongBan.Mapb))
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
            ViewData["IdCongTy"] = new SelectList(_context.Congties, "IdCongTy", "IdCongTy", phongBan.IdCongTy);
            return View(phongBan);
        }

        // GET: PhongBans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongBan = await _context.PhongBans
                .Include(p => p.IdCongTyNavigation)
                .FirstOrDefaultAsync(m => m.Mapb == id);
            if (phongBan == null)
            {
                return NotFound();
            }

            return View(phongBan);
        }

        // POST: PhongBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phongBan = await _context.PhongBans.FindAsync(id);
            if (phongBan != null)
            {
                _context.PhongBans.Remove(phongBan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongBanExists(int id)
        {
            return _context.PhongBans.Any(e => e.Mapb == id);
        }
    }
}
