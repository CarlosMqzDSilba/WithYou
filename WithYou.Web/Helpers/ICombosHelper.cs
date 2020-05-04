using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WithYou.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboGenders();
        IEnumerable<SelectListItem> GetComboRepublicStates();
        IEnumerable<SelectListItem> GetComboProyectTypes();
    }
}
