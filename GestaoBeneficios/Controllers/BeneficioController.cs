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
    public class BeneficioController : Controller
    {
        public IBeneficio Repository { get; set; }

        public BeneficioController(IBeneficio _repository)
        {
            Repository = _repository;
        }


        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return View(Repository.ListarBeneficios());
            }
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UserRole") == "Administrador")
            {
                return View();
            }
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BeneficioDTO beneficio)
        {
            Repository.Add(beneficio);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(long? id)
        {
            if (HttpContext.Session.GetString("UserRole") == "Administrador")
            {
                if (id == null)
                {
                    return BadRequest();
                }
                BeneficioDTO beneficio = Repository.GetBeneficio(id.Value);
                if (beneficio == null)
                {
                    return NotFound();
                }
                return View(beneficio);
            }
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BeneficioDTO beneficio)
        {
            if (ModelState.IsValid)
            {
                Repository.Update(beneficio);
                return RedirectToAction("Index");
            }
            return View(beneficio);
        }

        public IActionResult Delete(long? id)
        {
            if (HttpContext.Session.GetString("UserRole") == "Administrador")
            {
                if (id == null)
                {
                    return BadRequest();
                }
                BeneficioDTO beneficio = Repository.GetBeneficio(id.Value);
                if (beneficio == null)
                {
                    return NotFound();
                }
                return View(beneficio);
            }
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(BeneficioDTO beneficio)
        {
            BeneficioDTO car = Repository.GetBeneficio(beneficio.Id);
            if (car != null)
            {
                Repository.Delete(beneficio.Id);
                TempData["Message"] = "Beneficio " + car.Nome + " foi removido";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                if (id == null)
                {
                    return BadRequest();
                }
                BeneficioDTO beneficio = Repository.GetBeneficio(id.Value);
                if (beneficio == null)
                {
                    return NotFound();
                }
                return View(beneficio);
            }
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }
    }
}