using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoBeneficios.DTO
{
    public class ApplicationUser : IdentityUser
    {
        public PessoaDTO User { get; set; }
    }
}
