using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoBeneficios.DTO
{
    public class BeneficioColaboradorDTO : BaseDTO
    {
        public PessoaDTO Colaborador { get; set; }

        public BeneficioDTO Beneficio { get; set; }

        public int Quantidade { get; set; }

        [Display(Name = "Valor Total")]
        public double ValorTotal { get; set; }
    }
}
