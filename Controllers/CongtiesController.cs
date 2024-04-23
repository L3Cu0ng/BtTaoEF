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
    public class CongtiesController : Controller
    {
        private readonly QuanLyCongTyContext _context;

        public CongtiesController(QuanLyCongTyContext context)
        {
            _context = context;
        }

        // GET: Congties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Congties.ToListAsync());
        }

        // GET: Congties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congty = await _context.Congties
                .FirstOrDefaultAsync(m => m.IdCongTy == id);
            if (congty == null)
            {
                return NotFound();
            }

            return View(congty);
        }

        // GET: Congties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Congties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCongTy,TenCongTy,DiaChiCongTy,SoDienThoai")] Congty congty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(congty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(congty);
        }

        // GET: Congties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congty = await _context.Congties.FindAsync(id);
            if (congty == null)
            {
                return NotFound();
            }
            return View(congty);
        }

        // POST: Congties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCongTy,TenCongTy,DiaChiCongTy,SoDienThoai")] Congty congty)
        {
            if (id != congty.IdCongTy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(congty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongtyExists(congty.IdCongTy))
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
            return View(congty);
        }

        // GET: Congties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congty = await _context.Congties
                .FirstOrDefaultAsync(m => m.IdCongTy == id);
            if (congty == null)
            {
                return NotFound();
            }

            return View(congty);
        }

        // POST: Congties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var congty = await _context.Congties.FindAsync(id);
            if (congty != null)
            {
                _context.Congties.Remove(congty);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongtyExists(int id)
        {
            return _context.Congties.Any(e => e.IdCongTy == id);
        }
    }
}
