using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoBeneficios.DTO
{
    public class LogDTO : BaseDTO
    {
        public PessoaDTO Colaborador { get; set; }

        public BeneficioDTO Beneficio { get; set; }

        public DateTime Data { get; set; }

        [Display(Name = "Operação")]
        public string Operacao { get; set; }

        public string Campo { get; set; }

        [Display(Name = "Valor Anterior")]
        public string ValorAnterior { get; set; }

        [Display(Name = "Valor Atual")]
        public string ValorAtual { get; set; }

        public long? Id_Colaborador { get; set; }

        public long? Id_Beneficio { get; set; }
    }
}
