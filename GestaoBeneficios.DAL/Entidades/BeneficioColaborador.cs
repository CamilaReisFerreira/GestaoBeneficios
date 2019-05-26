using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoBeneficios.DAL.Entidades
{
    public class BeneficioColaborador : Base
    {      
        public int Quantidade { get; set; }

        public double ValorTotal { get; set; }

        public long ColaboradorId { get; set; }
        public Pessoa Colaborador { get; set; }

        public long BeneficioId { get; set; }
        public Beneficio Beneficio { get; set; }
    }
}
