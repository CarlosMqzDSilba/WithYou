using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WithYou.Web.Helpers
{
    public interface ITypesHelper
    {
        IEnumerable<SelectListItem> GetComboProyectTypes();
    }
}
