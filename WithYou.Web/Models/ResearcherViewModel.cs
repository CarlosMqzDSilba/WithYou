using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WithYou.Web.Data.Entities;

namespace WithYou.Web.Models
{
    public class ResearcherViewModel: Researcher
    {
        public IFormFile ImageFile { get; set; }
        public int GenderId { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; }
    }
}
