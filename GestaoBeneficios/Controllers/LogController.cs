using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoBeneficios.DAL.Interfaces;
using GestaoBeneficios.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoBeneficios.Controllers
{
    public class LogController : Controller
    {
        public ILog Repository { get; set; }

        public LogController(ILog _repository)
        {
            Repository = _repository;
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserRole") == "Administrador")
            {
                return View(Repository.ListarLogs());
            }
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            } 
        }

        public IActionResult Details(long? id)
        {
            if (HttpContext.Session.GetString("UserRole") == "Administrador")
            {
                if (id == null)
                {
                    return BadRequest();
                }
                LogDTO perfil = Repository.GetLog(id.Value);
                if (perfil == null)
                {
                    return NotFound();
                }
                return View(perfil);
            }
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }
    }
}