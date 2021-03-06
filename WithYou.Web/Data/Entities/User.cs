﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace WithYou.Web.Data.Entities
{
    public class User: IdentityUser
    {
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Fecha de alta")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Foto")]
        public string ImageUrl { get; set; }

        [Display(Name = "Nombre")]
        public string FullName => $"{LastName} {FirstName}";

        public Gender Gender { get; set; }
    }
}
