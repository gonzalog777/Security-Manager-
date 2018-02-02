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
    public class ReporteAccidentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReporteAccidentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReporteAccidentes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Accidentes.Include(r => r.Empleado);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReporteAccidentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteAccidente = await _context.Accidentes
                .Include(r => r.Empleado)
                .SingleOrDefaultAsync(m => m.ReporteAccidenteId == id);
            if (reporteAccidente == null)
            {
                return NotFound();
            }

            return View(reporteAccidente);
        }

        // GET: ReporteAccidentes/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Nombre");
            return View();
        }

        // POST: ReporteAccidentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReporteAccidenteId,Accidente,Comentarios,Fecha,EmpleadoId")] ReporteAccidente reporteAccidente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporteAccidente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Nombre", reporteAccidente.EmpleadoId);
            return View(reporteAccidente);
        }

        // GET: ReporteAccidentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteAccidente = await _context.Accidentes.SingleOrDefaultAsync(m => m.ReporteAccidenteId == id);
            if (reporteAccidente == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Nombre", reporteAccidente.EmpleadoId);
            return View(reporteAccidente);
        }

        // POST: ReporteAccidentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReporteAccidenteId,Accidente,Comentarios,Fecha,EmpleadoId")] ReporteAccidente reporteAccidente)
        {
            if (id != reporteAccidente.ReporteAccidenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporteAccidente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteAccidenteExists(reporteAccidente.ReporteAccidenteId))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Nombre", reporteAccidente.EmpleadoId);
            return View(reporteAccidente);
        }

        // GET: ReporteAccidentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteAccidente = await _context.Accidentes
                .Include(r => r.Empleado)
                .SingleOrDefaultAsync(m => m.ReporteAccidenteId == id);
            if (reporteAccidente == null)
            {
                return NotFound();
            }

            return View(reporteAccidente);
        }

        // POST: ReporteAccidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reporteAccidente = await _context.Accidentes.SingleOrDefaultAsync(m => m.ReporteAccidenteId == id);
            _context.Accidentes.Remove(reporteAccidente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteAccidenteExists(int id)
        {
            return _context.Accidentes.Any(e => e.ReporteAccidenteId == id);
        }
    }
}
