using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WithYou.Web.Data.Entities;

namespace WithYou.Web.Models
{
    public class LeaderViewModel:Leader
    {
        public IFormFile ImageFile { get; set; }
        public int GenderId { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; }
    }
}
