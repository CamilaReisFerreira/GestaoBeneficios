using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoBeneficios.DTO
{
    public class CargoDTO : BaseDTO
    {
        public string Nome { get; set; }

        [Display(Name = "Valor do Benefício")]
        public double ValorBeneficio { get; set; }
    }
}
