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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public LoginController(IPessoa _repository, IHttpContextAccessor httpContextAccessor)
        {
            Repository = _repository;
            _httpContextAccessor = httpContextAccessor;
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

                _session.SetString("User", retorno.Login);
                _session.SetString("UserId", retorno.Id.ToString());
                _session.SetString("UserRole", retorno.Perfil.Tipo);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch(Exception ex)
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }
    }
}