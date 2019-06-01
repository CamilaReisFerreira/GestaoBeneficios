﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoBeneficios.DAL.Interfaces;
using GestaoBeneficios.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPessoas.Controllers
{
    public class PessoaController : Controller
    {
        public IPessoa Repository { get; set; }
        public ICargo Cargo_Repository { get; set; }
        public IPerfil Perfil_Repository { get; set; }

        public PessoaController(IPessoa _repository, ICargo _cargoRepository, IPerfil _perfilRepository)
        {
            Repository = _repository;
            Cargo_Repository = _cargoRepository;
            Perfil_Repository = _perfilRepository;
        }


        public IActionResult Index()
        {
            return View(Repository.ListarPessoas());
        }

        public IActionResult Create()
        {
            ViewBag.Cargos = Cargo_Repository.ListarCargos();
            ViewBag.Perfis = Perfil_Repository.ListarPerfis();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PessoaDTO pessoa)
        {
            Repository.Add(pessoa);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            PessoaDTO pessoa = Repository.GetPessoa(id.Value);
            ViewBag.Cargos = Cargo_Repository.ListarCargos();
            ViewBag.Perfis = Perfil_Repository.ListarPerfis();
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PessoaDTO pessoa)
        {
            if (ModelState.IsValid)
            {
                Repository.Update(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            PessoaDTO pessoa = Repository.GetPessoa(id.Value);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(PessoaDTO pessoa)
        {
            PessoaDTO car = Repository.GetPessoa(pessoa.Id);
            if (car != null)
            {
                Repository.Delete(pessoa.Id);
                TempData["Message"] = "Pessoa " + car.Nome + " foi removida";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            PessoaDTO pessoa = Repository.GetPessoa(id.Value);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }
    }
}