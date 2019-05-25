using GestaoBeneficios.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoBeneficios.DAL.Persistencia
{
    public class Login : UserManager<PessoaDTO>
    {
        public Login(IUserStore<PessoaDTO> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<PessoaDTO> passwordHasher, IEnumerable<IUserValidator<PessoaDTO>> userValidators, IEnumerable<IPasswordValidator<PessoaDTO>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<PessoaDTO>> logger) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        //public static Login Create(IdentityFactoryOptions<Login> options, IOwinContext context)
        //{
        //    var db = context.Get<Login>();
        //    var manager = new GerenciadorUsuario(new UserStore<PessoaDTO>(db));
        //    return manager;
        //}
    }
}
