using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WithYou.Web.Data;
using WithYou.Web.Data.Entities;

namespace WithYou.Web.Controllers
{
    public class ProyectTypesController : Controller
    {
        private readonly DataContext _context;

        public ProyectTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: ProyectTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProyectTypes.ToListAsync());
        }

        // GET: ProyectTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyectType = await _context.ProyectTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyectType == null)
            {
                return NotFound();
            }

            return View(proyectType);
        }

        // GET: ProyectTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProyectTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ProyectType proyectType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proyectType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proyectType);
        }

        // GET: ProyectTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyectType = await _context.ProyectTypes.FindAsync(id);
            if (proyectType == null)
            {
                return NotFound();
            }
            return View(proyectType);
        }

        // POST: ProyectTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProyectType proyectType)
        {
            if (id != proyectType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proyectType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProyectTypeExists(proyectType.Id))
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
            return View(proyectType);
        }

        // GET: ProyectTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyectType = await _context.ProyectTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyectType == null)
            {
                return NotFound();
            }

            return View(proyectType);
        }

        // POST: ProyectTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proyectType = await _context.ProyectTypes.FindAsync(id);
            _context.ProyectTypes.Remove(proyectType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyectTypeExists(int id)
        {
            return _context.ProyectTypes.Any(e => e.Id == id);
        }
    }
}
