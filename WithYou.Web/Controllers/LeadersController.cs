using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WithYou.Web.Data;
using WithYou.Web.Data.Entities;
using WithYou.Web.Helpers;
using WithYou.Web.Models;

namespace WithYou.Web.Controllers
{
    public class LeadersController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;
        private readonly ImagenHelper imagenHelper;

        public LeadersController(DataContext dataContext,ICombosHelper combosHelper, ImagenHelper imagenHelper)
        {
            this.dataContext = dataContext;
            this.combosHelper = combosHelper;
            this.imagenHelper = imagenHelper;
        }

        // GET: Leaders
        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Leaders.ToListAsync());
        }

        public IActionResult Create()
        {
            var model = new LeaderViewModel
            {
                Genders = combosHelper.GetComboGenders()
            };
            return View(model);
        }

        // POST: Leaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Enrollment,BirthDay,ImageUrl")] Leader leader)
        {
            if (ModelState.IsValid)
            {
                dataContext.Add(leader);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leader);
        }

        // GET: Leaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leader = await dataContext.Leaders.FindAsync(id);
            if (leader == null)
            {
                return NotFound();
            }
            return View(leader);
        }

        // POST: Leaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Enrollment,BirthDay,ImageUrl")] Leader leader)
        {
            if (id != leader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dataContext.Update(leader);
                    await dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaderExists(leader.Id))
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
            return View(leader);
        }

        // GET: Leaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leader = await dataContext.Leaders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leader == null)
            {
                return NotFound();
            }

            return View(leader);
        }

        // POST: Leaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leader = await dataContext.Leaders.FindAsync(id);
            dataContext.Leaders.Remove(leader);
            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaderExists(int id)
        {
            return dataContext.Leaders.Any(e => e.Id == id);
        }
    }
}
