using GestaoBeneficios.DAL.Interfaces;
using GestaoBeneficios.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Login(LoginViewModel login)
        {
            var retorno = Repository.Login("camila", "camila");
            _session.SetString("User", retorno.Login);
            _session.SetString("UserRole", retorno.Perfil.Tipo);
            return RedirectToAction("Login");
        }
    }
}