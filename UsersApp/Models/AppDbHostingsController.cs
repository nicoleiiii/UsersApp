using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UsersApp.Data;

namespace UsersApp.Models
{
    public class AppDbHostingsController : Controller
    {
        private readonly AppDbContext _context;

        public AppDbHostingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AppDbHostings
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppDbHosting.ToListAsync());
        }

        // GET: AppDbHostings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appDbHosting = await _context.AppDbHosting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appDbHosting == null)
            {
                return NotFound();
            }

            return View(appDbHosting);
        }

        // GET: AppDbHostings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppDbHostings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,Password")] AppDbHosting appDbHosting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appDbHosting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appDbHosting);
        }

        // GET: AppDbHostings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appDbHosting = await _context.AppDbHosting.FindAsync(id);
            if (appDbHosting == null)
            {
                return NotFound();
            }
            return View(appDbHosting);
        }

        // POST: AppDbHostings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,Password")] AppDbHosting appDbHosting)
        {
            if (id != appDbHosting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appDbHosting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppDbHostingExists(appDbHosting.Id))
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
            return View(appDbHosting);
        }

        // GET: AppDbHostings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appDbHosting = await _context.AppDbHosting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appDbHosting == null)
            {
                return NotFound();
            }

            return View(appDbHosting);
        }

        // POST: AppDbHostings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appDbHosting = await _context.AppDbHosting.FindAsync(id);
            if (appDbHosting != null)
            {
                _context.AppDbHosting.Remove(appDbHosting);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppDbHostingExists(int id)
        {
            return _context.AppDbHosting.Any(e => e.Id == id);
        }
    }
}
