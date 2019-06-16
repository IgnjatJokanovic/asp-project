using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using EfDataAccess;

namespace Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ProjectContext _context;

        public CarsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Cars.Include(c => c.Engine).Include(c => c.Fuel).Include(c => c.Model).Include(c => c.Transmission);
            return View(await projectContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Engine)
                .Include(c => c.Fuel)
                .Include(c => c.Model)
                .Include(c => c.Transmission)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["EngineId"] = new SelectList(_context.Engines, "Id", "Name");
            ViewData["FuelId"] = new SelectList(_context.Fuels, "Id", "Type");
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name");
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "Id", "Type");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Src,Alt,EngineId,ModelId,FuelId,TransmissionId,Id,CreatedAt,UpdatedAt")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EngineId"] = new SelectList(_context.Engines, "Id", "Name", car.EngineId);
            ViewData["FuelId"] = new SelectList(_context.Fuels, "Id", "Type", car.FuelId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", car.ModelId);
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "Id", "Type", car.TransmissionId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["EngineId"] = new SelectList(_context.Engines, "Id", "Name", car.EngineId);
            ViewData["FuelId"] = new SelectList(_context.Fuels, "Id", "Type", car.FuelId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", car.ModelId);
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "Id", "Type", car.TransmissionId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price,Src,Alt,EngineId,ModelId,FuelId,TransmissionId,Id,CreatedAt,UpdatedAt")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            ViewData["EngineId"] = new SelectList(_context.Engines, "Id", "Name", car.EngineId);
            ViewData["FuelId"] = new SelectList(_context.Fuels, "Id", "Type", car.FuelId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", car.ModelId);
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "Id", "Type", car.TransmissionId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Engine)
                .Include(c => c.Fuel)
                .Include(c => c.Model)
                .Include(c => c.Transmission)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
