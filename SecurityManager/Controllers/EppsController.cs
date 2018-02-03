using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecurityManager.Data;
using SecurityManager.Models.AppModels;

namespace SecurityManager.Controllers
{
    public class EppsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EppsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Epps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Epps.ToListAsync());
        }

        // GET: Epps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epp = await _context.Epps
                .SingleOrDefaultAsync(m => m.EppId == id);
            if (epp == null)
            {
                return NotFound();
            }

            return View(epp);
        }

        // GET: Epps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Epps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EppId,Nombre")] Epp epp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(epp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(epp);
        }

        // GET: Epps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epp = await _context.Epps.SingleOrDefaultAsync(m => m.EppId == id);
            if (epp == null)
            {
                return NotFound();
            }
            return View(epp);
        }

        // POST: Epps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EppId,Nombre")] Epp epp)
        {
            if (id != epp.EppId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(epp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EppExists(epp.EppId))
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
            return View(epp);
        }

        // GET: Epps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epp = await _context.Epps
                .SingleOrDefaultAsync(m => m.EppId == id);
            if (epp == null)
            {
                return NotFound();
            }

            return View(epp);
        }

        // POST: Epps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var epp = await _context.Epps.SingleOrDefaultAsync(m => m.EppId == id);
            _context.Epps.Remove(epp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EppExists(int id)
        {
            return _context.Epps.Any(e => e.EppId == id);
        }
    }
}
