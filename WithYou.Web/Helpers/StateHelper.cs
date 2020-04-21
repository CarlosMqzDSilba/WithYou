using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WithYou.Web.Data;
namespace WithYou.Web.Helpers
{
    public class StateHelper : IStateHelper
    {
        private readonly DataContext dataContext;

        public StateHelper(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IEnumerable<SelectListItem> GetComboRepublicStates()
        {
            var list = dataContext.RepublicStates.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = $"{c.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Debe seleccionar un estado....]",
                Value = "0"
            });
            return list;
        }
    }
}
