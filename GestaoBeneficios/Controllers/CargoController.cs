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
    public class CargoController : Controller
    {
        public ICargo Repository { get; set; }

        public CargoController(ICargo _repository)
        {
            Repository = _repository;
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserRole") == "Administrador")
            {
                return View(Repository.ListarCargos());
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
        public IActionResult Create(CargoDTO cargo)
        {
            Repository.Add(cargo);
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
                CargoDTO cargo = Repository.GetCargo(id.Value);
                if (cargo == null)
                {
                    return NotFound();
                }
                return View(cargo);
            }
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CargoDTO cargo)
        {
            if (ModelState.IsValid)
            {
                Repository.Update(cargo);
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        public IActionResult Delete(long? id)
        {
            if (HttpContext.Session.GetString("UserRole") == "Administrador")
            {
                if (id == null)
                {
                    return BadRequest();
                }
                CargoDTO cargo = Repository.GetCargo(id.Value);
                if (cargo == null)
                {
                    return NotFound();
                }
                return View(cargo);
            }
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            } 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CargoDTO cargo)
        {
            CargoDTO car = Repository.GetCargo(cargo.Id);
            if (car != null)
            {
                Repository.Delete(cargo.Id);
                TempData["Message"] = "Cargo " + car.Nome + " foi removido";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            if (HttpContext.Session.GetString("UserRole") == "Administrador")
            {
                if (id == null)
                {
                    return BadRequest();
                }
                CargoDTO cargo = Repository.GetCargo(id.Value);
                if (cargo == null)
                {
                    return NotFound();
                }
                return View(cargo);
            }
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }
    }
}