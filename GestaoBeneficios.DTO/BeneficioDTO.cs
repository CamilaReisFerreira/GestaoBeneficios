using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoBeneficios.DTO
{
    public class BeneficioDTO : BaseDTO
    {
        public string Nome { get; set; }

        [Display(Name = "Fator de Conversão")]
        public double FatorConversao { get; set; }
    }
}
