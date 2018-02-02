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
    public class ReporteEppsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReporteEppsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReporteEpps
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Epps.Include(r => r.Empleado);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReporteEpps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteEpp = await _context.Epps
                .Include(r => r.Empleado)
                .SingleOrDefaultAsync(m => m.ReporteEppId == id);
            if (reporteEpp == null)
            {
                return NotFound();
            }

            return View(reporteEpp);
        }

        // GET: ReporteEpps/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Nombre");
            return View();
        }

        // POST: ReporteEpps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReporteEppId,Epp,Comentarios,Fecha,EmpleadoId")] ReporteEpp reporteEpp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporteEpp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Nombre", reporteEpp.EmpleadoId);
            return View(reporteEpp);
        }

        // GET: ReporteEpps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteEpp = await _context.Epps.SingleOrDefaultAsync(m => m.ReporteEppId == id);
            if (reporteEpp == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Nombre", reporteEpp.EmpleadoId);
            return View(reporteEpp);
        }

        // POST: ReporteEpps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReporteEppId,Epp,Comentarios,Fecha,EmpleadoId")] ReporteEpp reporteEpp)
        {
            if (id != reporteEpp.ReporteEppId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporteEpp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteEppExists(reporteEpp.ReporteEppId))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Nombre", reporteEpp.EmpleadoId);
            return View(reporteEpp);
        }

        // GET: ReporteEpps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteEpp = await _context.Epps
                .Include(r => r.Empleado)
                .SingleOrDefaultAsync(m => m.ReporteEppId == id);
            if (reporteEpp == null)
            {
                return NotFound();
            }

            return View(reporteEpp);
        }

        // POST: ReporteEpps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reporteEpp = await _context.Epps.SingleOrDefaultAsync(m => m.ReporteEppId == id);
            _context.Epps.Remove(reporteEpp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteEppExists(int id)
        {
            return _context.Epps.Any(e => e.ReporteEppId == id);
        }
    }
}
