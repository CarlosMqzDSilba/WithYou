using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WithYou.Web.Data.Entities
{
    public class RepublicState : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        [Display(Name = "Estado")]
        public string Name { get; set; }
        public ICollection<Investigation> Investigations { get; set; }
    }
    
}
