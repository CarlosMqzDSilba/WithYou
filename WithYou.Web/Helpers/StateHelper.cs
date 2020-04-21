using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WithYou.Web.Data;
namespace WithYou.Web.Helpers
{
    public class StateHelper : IStateHelper
    {
        private readonly DataContext dataContext01;

        public StateHelper(DataContext dataContext01)
        {
            this.dataContext01 = dataContext01;
        }
        public IEnumerable<SelectListItem> GetComboGenders()
        {
            var list = dataContext01.RepublicStates.Select(c => new SelectListItem
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

        public IEnumerable<SelectListItem> GetComboRepublicStates()
        {
            throw new System.NotImplementedException();
        }
    }
}
