using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoBeneficios.DTO
{
    public class BaseDTO
    {
        [Display(Name = "Código")]
        public long Id { get; set; }
    }
}
