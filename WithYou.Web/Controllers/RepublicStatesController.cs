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
    public class RepublicStatesController : Controller
    {
        private readonly DataContext _context;

        public RepublicStatesController(DataContext context)
        {
            _context = context;
        }

        // GET: RepublicStates
        public async Task<IActionResult> Index()
        {
            return View(await _context.RepublicStates.ToListAsync());
        }

        // GET: RepublicStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var republicState = await _context.RepublicStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (republicState == null)
            {
                return NotFound();
            }

            return View(republicState);
        }

        // GET: RepublicStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RepublicStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RepublicState republicState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(republicState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(republicState);
        }

        // GET: RepublicStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var republicState = await _context.RepublicStates.FindAsync(id);
            if (republicState == null)
            {
                return NotFound();
            }
            return View(republicState);
        }

        // POST: RepublicStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RepublicState republicState)
        {
            if (id != republicState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(republicState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepublicStateExists(republicState.Id))
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
            return View(republicState);
        }

        // GET: RepublicStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var republicState = await _context.RepublicStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (republicState == null)
            {
                return NotFound();
            }

            return View(republicState);
        }

        // POST: RepublicStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var republicState = await _context.RepublicStates.FindAsync(id);
            _context.RepublicStates.Remove(republicState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepublicStateExists(int id)
        {
            return _context.RepublicStates.Any(e => e.Id == id);
        }
    }
}
