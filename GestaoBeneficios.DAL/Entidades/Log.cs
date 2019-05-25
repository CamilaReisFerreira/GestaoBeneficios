using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoBeneficios.DAL.Entidades
{
    public class Log : Base
    {
        public long? Id_Colaborador { get; set; }

        public long? Id_Beneficio { get; set; }

        public DateTime Data { get; set; }

        public string Operacao { get; set; }

        public string Campo { get; set; }

        public string ValorAnterior { get; set; }

        public string ValorAtual { get; set; }

        public Pessoa Colaborador { get; set; }

        public Beneficio Beneficio { get; set; }
    }
}
