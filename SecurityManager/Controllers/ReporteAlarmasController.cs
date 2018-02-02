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
    public class ReporteAlarmasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReporteAlarmasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReporteAlarmas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alarmas.ToListAsync());
        }

        // GET: ReporteAlarmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteAlarma = await _context.Alarmas
                .SingleOrDefaultAsync(m => m.ReporteAlarmaId == id);
            if (reporteAlarma == null)
            {
                return NotFound();
            }

            return View(reporteAlarma);
        }

        // GET: ReporteAlarmas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReporteAlarmas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReporteAlarmaId,Alarma,Funciona,Comentarios")] ReporteAlarma reporteAlarma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporteAlarma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reporteAlarma);
        }

        // GET: ReporteAlarmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteAlarma = await _context.Alarmas.SingleOrDefaultAsync(m => m.ReporteAlarmaId == id);
            if (reporteAlarma == null)
            {
                return NotFound();
            }
            return View(reporteAlarma);
        }

        // POST: ReporteAlarmas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReporteAlarmaId,Alarma,Funciona,Comentarios")] ReporteAlarma reporteAlarma)
        {
            if (id != reporteAlarma.ReporteAlarmaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporteAlarma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteAlarmaExists(reporteAlarma.ReporteAlarmaId))
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
            return View(reporteAlarma);
        }

        // GET: ReporteAlarmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteAlarma = await _context.Alarmas
                .SingleOrDefaultAsync(m => m.ReporteAlarmaId == id);
            if (reporteAlarma == null)
            {
                return NotFound();
            }

            return View(reporteAlarma);
        }

        // POST: ReporteAlarmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reporteAlarma = await _context.Alarmas.SingleOrDefaultAsync(m => m.ReporteAlarmaId == id);
            _context.Alarmas.Remove(reporteAlarma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteAlarmaExists(int id)
        {
            return _context.Alarmas.Any(e => e.ReporteAlarmaId == id);
        }
    }
}
