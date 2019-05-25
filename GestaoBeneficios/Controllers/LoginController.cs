using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GestaoBeneficios.Controllers
{
    public class LoginController : Controller
    {
        private AuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.Authentication;
            }
        }

        //private GerenciadorUsuario UserManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
        //    }
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}