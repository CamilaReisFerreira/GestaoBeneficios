using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoBeneficios.DAL.Interfaces;
using GestaoBeneficios.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestaoBeneficios.Controllers
{
    public class PerfilController : Controller
    {
        public IPerfil Repository { get; set; }

        public PerfilController(IPerfil _repository)
        {
            Repository = _repository;
        }


        public IActionResult Index()
        {
            return View(Repository.ListarPerfis());
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            PerfilDTO perfil = Repository.GetPerfil(id.Value);
            if (perfil == null)
            {
                return NotFound();
            }
            return View(perfil);
        }
    }
}