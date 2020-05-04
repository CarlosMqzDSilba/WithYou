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
    public class InvestigationsController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;

        public InvestigationsController(DataContext dataContext, ICombosHelper combosHelper)
        {
            this.dataContext = dataContext;
            this.combosHelper = combosHelper;
        }


        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Investigations.ToListAsync());
        }

        public IActionResult Create()
        {
            var model = new InvestigationViewModel
            {
                RepublicStates = combosHelper.GetComboRepublicStates(),
                ProyectTypes= combosHelper.GetComboProyectTypes()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvestigationViewModel model)
        {
            if(ModelState.IsValid)
            {
                var invastigation = new Investigation
                {
                    Name=model.Name,
                    Description=model.Description,
                    ProyectType=await dataContext.ProyectTypes.FirstOrDefaultAsync(m=>m.Id==model.ProyectTypeId),
                    RepublicState = await dataContext.RepublicStates.FirstOrDefaultAsync(m => m.Id == model.RepublicStateId),
                    
                };
                dataContext.Investigations.Add(invastigation);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



    }
}
