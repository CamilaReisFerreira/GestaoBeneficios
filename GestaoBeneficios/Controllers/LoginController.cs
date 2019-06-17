using GestaoBeneficios.DAL.Interfaces;
using GestaoBeneficios.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestaoBeneficios.Controllers
{
    public class LoginController : Controller
    {
        public IPessoa Repository { get; set; }

        public LoginController(IPessoa _repository)
        {
            Repository = _repository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            try
            {
                var retorno = Repository.Login(loginViewModel.Login, loginViewModel.Senha);
                if (retorno == null)
                    return RedirectToAction("NaoAutorizado", "Home", new { area = "" });

                HttpContext.Session.SetString("User", retorno.Login);
                HttpContext.Session.SetString("UserId", retorno.Id.ToString());
                HttpContext.Session.SetString("UserRole", retorno.Perfil.Tipo);
                return RedirectToAction("Index", "Home", false);
            }
            catch(Exception ex)
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }
    }
}