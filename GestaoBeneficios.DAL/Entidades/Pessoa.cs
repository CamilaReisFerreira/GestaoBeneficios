using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoBeneficios.DAL.Entidades
{
    public class Pessoa : Base
    {
        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataAdmissao { get; set; }

        public long CargoId { get; set; }
        public Cargo Cargo { get; set; }

        public long PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
