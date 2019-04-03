using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoBeneficios.DAL.Entidades
{
    public class Base
    {
        [Key]
        public long Id { get; set; }
    }
}
