using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WithYou.Web.Data;
using WithYou.Web.Data.Entities;
using WithYou.Web.Models;

namespace WithYou.Web.Controllers
{
    public class InvestigationsController :  Controller
    {
        private readonly DataContext dataContext;

        public InvestigationsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }


        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Leaders.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Investigations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Investigation investigation)
        {
            if (ModelState.IsValid)
            {
                dataContext.Add(investigation);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(investigation);
        }

        // GET: Investigations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigation = await dataContext.Investigations.FindAsync(id);
            if (investigation == null)
            {
                return NotFound();
            }
            return View(investigation);
        }

        // POST: Investigations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Investigation investigation)
        {
            if (id != investigation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dataContext.Update(investigation);
                    await dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestigationExists(investigation.Id))
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
            return View(investigation);
        }

        // GET: Investigations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigation = await dataContext.Investigations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (investigation == null)
            {
                return NotFound();
            }

            return View(investigation);
        }

        // POST: Investigations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investigation = await dataContext.Investigations.FindAsync(id);
            dataContext.Investigations.Remove(investigation);
            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestigationExists(int id)
        {
            return dataContext.Investigations.Any(e => e.Id == id);
        }
    }
}
