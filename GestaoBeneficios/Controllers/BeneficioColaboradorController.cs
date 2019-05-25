﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoBeneficios.DAL.Interfaces;
using GestaoBeneficios.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestaoBeneficio.Controllers
{
    public class BeneficioColaboradorController : Controller
    {
        public IBeneficioColaborador Repository { get; set; }

        public BeneficioColaboradorController(IBeneficioColaborador _repository)
        {
            Repository = _repository;
        }


        public IActionResult Index()
        {
            return View(Repository.ListarBeneficiosColaboradores());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BeneficioColaboradorDTO beneficio)
        {
            Repository.Add(beneficio);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BeneficioColaboradorDTO beneficio = Repository.GetBeneficioColaborador(id.Value);
            if (beneficio == null)
            {
                return NotFound();
            }
            return View(beneficio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BeneficioColaboradorDTO beneficio)
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
            if (id == null)
            {
                return BadRequest();
            }
            BeneficioColaboradorDTO beneficio = Repository.GetBeneficioColaborador(id.Value);
            if (beneficio == null)
            {
                return NotFound();
            }
            return View(beneficio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(BeneficioColaboradorDTO beneficio)
        {
            BeneficioColaboradorDTO car = Repository.GetBeneficioColaborador(beneficio.Id);
            if (car != null)
            {
                Repository.Delete(beneficio.Id);
                TempData["Message"] = "Benefício foi removido";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BeneficioColaboradorDTO beneficio = Repository.GetBeneficioColaborador(id.Value);
            if (beneficio == null)
            {
                return NotFound();
            }
            return View(beneficio);
        }
    }
}