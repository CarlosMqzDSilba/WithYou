using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WithYou.Web.Data.Entities;

namespace WithYou.Web.Models
{
    public class InvestigationViewModel: Investigation
    {
        public int RepublicStateId { get; set; }
        public int ProyectTypeId { get; set; }

        public IEnumerable<SelectListItem> ProyectTypes { get; set; }
        public IEnumerable<SelectListItem> RepublicStates { get; set; }
    }
}
