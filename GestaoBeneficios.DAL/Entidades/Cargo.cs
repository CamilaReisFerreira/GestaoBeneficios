using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoBeneficios.DAL.Entidades
{
    public class Cargo : Base
    {
        public string Nome { get; set; }

        public double ValorBeneficio { get; set; }
    }
}
