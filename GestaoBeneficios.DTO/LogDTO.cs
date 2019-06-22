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

        public LogDTO(BeneficioColaboradorDTO beneficioColaborador, string operacao, string campo = "", 
            string valorAnterior = "", string valorAtual = "")
        {
            this.Colaborador = beneficioColaborador.Colaborador;
            this.Beneficio = beneficioColaborador.Beneficio;
            this.Data = DateTime.Now;
            this.Operacao = operacao;
            this.Campo = campo;
            this.ValorAnterior = valorAnterior;
            this.ValorAtual = valorAtual;
        }

        public LogDTO() { }

    }
}
