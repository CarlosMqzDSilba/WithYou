using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WithYou.Web.Data;
using WithYou.Web.Helpers;
using WithYou.Web.Models;

namespace WithYou.Web.Controllers
{
    public class LeadersController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;
        private readonly IImageHelper imagenHelper;

        public LeadersController(DataContext dataContext, ICombosHelper combosHelper, IImageHelper imagenHelper)
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


    }
}
