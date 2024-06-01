using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//para usar "DataAnnotations"
using System.ComponentModel.DataAnnotations; 

namespace Guia10.Models
{
    public class Doctor
    {
        //agregar propiedades -> campos
        [Key]
        [Display(Name ="Codigo Doctor")]
        [Required(ErrorMessage ="El codigo es obligatorio")]
        [StringLength(6, MinimumLength = 6, ErrorMessage= "El codigo debe tener 6 Caracteres")]

        public string CodigoDoctor { get; set; }
        [Display(Name = "No. DUI")]
        [Required(ErrorMessage = "El DUI es obligatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El DUi debe  tener 10 Caracteres")]
        public string DUI { get; set; }
        
        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los Nombres deben tener entre 3 y 50 Caracteres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los Apellidos deben tener entre 3 y 50 Caracteres")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "La Especialidad es  obligatorio")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "La especialidad debe tener entre 5 y 20 Caracteres")]
        public string Especialidad { get; set; }
        [Required(ErrorMessage = "El cargo es  obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El Cargo debe tener entre 5 y 20 Caracteres")]
        public string Cargo { get; set; }
        

    }
}