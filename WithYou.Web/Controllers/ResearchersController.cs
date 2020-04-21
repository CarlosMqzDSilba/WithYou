﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WithYou.Web.Data;
using WithYou.Web.Data.Entities;
using WithYou.Web.Helpers;
using WithYou.Web.Models;

namespace WithYou.Web.Controllers
{
    public class ResearchersController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;
        private readonly ImagenHelper imagenHelper;

        public ResearchersController(DataContext dataContext, ICombosHelper combosHelper, ImagenHelper imagenHelper)
        {
            this.dataContext = dataContext;
            this.combosHelper = combosHelper;
            this.imagenHelper = imagenHelper;
        }


        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Leaders.ToListAsync());
        }

        public IActionResult Create()
        {
            var model = new ResearcherViewModel
            {
                Genders = combosHelper.GetComboGenders()
            };
            return View(model);
        }

        // POST: Researchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Enrollment,BirthDay,ImageUrl")] Researcher researcher)
        {
            if (ModelState.IsValid)
            {
                dataContext.Add(researcher);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(researcher);
        }

        // GET: Researchers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researcher = await dataContext.Researchers.FindAsync(id);
            if (researcher == null)
            {
                return NotFound();
            }
            return View(researcher);
        }

        // POST: Researchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Enrollment,BirthDay,ImageUrl")] Researcher researcher)
        {
            if (id != researcher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dataContext.Update(researcher);
                    await dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResearcherExists(researcher.Id))
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
            return View(researcher);
        }

        // GET: Researchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researcher = await dataContext.Researchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (researcher == null)
            {
                return NotFound();
            }

            return View(researcher);
        }

        // POST: Researchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var researcher = await dataContext.Researchers.FindAsync(id);
            dataContext.Researchers.Remove(researcher);
            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResearcherExists(int id)
        {
            return dataContext.Researchers.Any(e => e.Id == id);
        }
    }
}