using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WithYou.Web.Data.Entities;

namespace WithYou.Web.Models
{
    public class InvestigationViewModel : Investigation
    {
        public int RepublicStateId { get; set; }
        public int ProyectTypeId { get; set; }

        public IEnumerable<SelectListItem> ProyectTypes { get; set; }
        public IEnumerable<SelectListItem> RepublicStates { get; set; }
    }
}
