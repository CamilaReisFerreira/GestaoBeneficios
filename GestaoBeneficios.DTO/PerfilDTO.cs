using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoBeneficios.DTO
{
    public class PerfilDTO : BaseDTO
    {
        [Display(Name = "Perfil")]
        public string Tipo { get; set; }
    }
}
