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
    public class ResearchersController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;
        private readonly IImageHelper imagenHelper;

        public ResearchersController(DataContext dataContext, ICombosHelper combosHelper, IImageHelper imagenHelper)
        {
            this.dataContext = dataContext;
            this.combosHelper = combosHelper;
            this.imagenHelper = imagenHelper;
        }


        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Researchers.ToListAsync());
        }

        public IActionResult Create()
        {
            var model = new ResearcherViewModel
            {
                Genders = combosHelper.GetComboGenders()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResearcherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var research = new Researcher
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Enrollment = model.Enrollment,
                    BirthDay = model.BirthDay,
                    Gender = await dataContext.Genders.FirstOrDefaultAsync(m => m.Id == model.GenderId),
                    ImageUrl = await imagenHelper.UploadImageAsync(model.ImageFile, model.Enrollment, "Students")

                };
                dataContext.Researchers.Add(research);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
