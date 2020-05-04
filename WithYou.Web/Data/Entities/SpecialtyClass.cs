using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WithYou.Web.Data.Entities
{
    public class SpecialtyClass:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Area de especialidad")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string Name { get; set; }
        public ICollection<Researcher> Researchers { get; set; }
    }
}
