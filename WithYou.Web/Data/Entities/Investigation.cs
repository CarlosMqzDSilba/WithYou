using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WithYou.Web.Data.Entities
{
    public class Investigation:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        [MinLength(20, ErrorMessage = "El campo {0} debe de contener una descripción")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        public RepublicState RepublicState { get; set; }
        public ProyectType ProyectType { get; set; }
    }
}
