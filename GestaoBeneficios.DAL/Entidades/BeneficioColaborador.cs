using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoBeneficios.DAL.Entidades
{
    public class BeneficioColaborador : Base
    {
        public long? Id_Colaborador { get; set; }

        public long? Id_Beneficio { get; set; }

        public int Quantidade { get; set; }

        public double ValorTotal { get; set; }

        public Pessoa Colaborador { get; set; }

        public Beneficio Beneficio { get; set; }
    }
}
