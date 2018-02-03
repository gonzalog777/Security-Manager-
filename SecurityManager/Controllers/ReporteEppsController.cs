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
            var applicationDbContext = _context.ReporteEpps.Include(r => r.Empleado).Include(r => r.Epp);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReporteEpps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteEpp = await _context.ReporteEpps
                .Include(r => r.Empleado)
                .Include(r => r.Epp)
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId");
            ViewData["EppId"] = new SelectList(_context.Epps, "EppId", "EppId");
            return View();
        }

        // POST: ReporteEpps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReporteEppId,Comentarios,Fecha,EppId,EmpleadoId")] ReporteEpp reporteEpp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporteEpp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId", reporteEpp.EmpleadoId);
            ViewData["EppId"] = new SelectList(_context.Epps, "EppId", "EppId", reporteEpp.EppId);
            return View(reporteEpp);
        }

        // GET: ReporteEpps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteEpp = await _context.ReporteEpps.SingleOrDefaultAsync(m => m.ReporteEppId == id);
            if (reporteEpp == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId", reporteEpp.EmpleadoId);
            ViewData["EppId"] = new SelectList(_context.Epps, "EppId", "EppId", reporteEpp.EppId);
            return View(reporteEpp);
        }

        // POST: ReporteEpps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReporteEppId,Comentarios,Fecha,EppId,EmpleadoId")] ReporteEpp reporteEpp)
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId", reporteEpp.EmpleadoId);
            ViewData["EppId"] = new SelectList(_context.Epps, "EppId", "EppId", reporteEpp.EppId);
            return View(reporteEpp);
        }

        // GET: ReporteEpps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteEpp = await _context.ReporteEpps
                .Include(r => r.Empleado)
                .Include(r => r.Epp)
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
            var reporteEpp = await _context.ReporteEpps.SingleOrDefaultAsync(m => m.ReporteEppId == id);
            _context.ReporteEpps.Remove(reporteEpp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteEppExists(int id)
        {
            return _context.ReporteEpps.Any(e => e.ReporteEppId == id);
        }
    }
}
