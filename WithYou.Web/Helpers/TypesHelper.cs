using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WithYou.Web.Data;



namespace WithYou.Web.Helpers
{
    public class TypesHelper : ITypesHelper
    {
        private readonly DataContext dataContext;

        public TypesHelper(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IEnumerable<SelectListItem> GetComboGenders()
        {
            var list = dataContext.Genders.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = $"{c.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Debe seleccionar un genero....]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboProyectTypes()
        {
            throw new System.NotImplementedException();
        }
    }
}
