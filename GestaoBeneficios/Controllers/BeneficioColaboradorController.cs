using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoBeneficios.DAL.Interfaces;
using GestaoBeneficios.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoBeneficio.Controllers
{
    public class BeneficioColaboradorController : Controller
    {
        public IBeneficioColaborador Repository { get; set; }
        public IBeneficio Beneficio_Repository { get; set; }
        public IPessoa Pessoa_Repository { get; set; }

        public BeneficioColaboradorController(IBeneficioColaborador _repository,
            IBeneficio _beneficioRepository, IPessoa _pessoaRepository)
        {
            Repository = _repository;
            Beneficio_Repository = _beneficioRepository;
            Pessoa_Repository = _pessoaRepository;
        }


        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                if (HttpContext.Session.GetString("UserRole") == "Administrador")
                    return View(Repository.ListarBeneficiosColaboradores());
                else
                {
                    var id = Convert.ToInt64(HttpContext.Session.GetString("UserId"));
                    return View(Repository.ListarBeneficiosPorPessoa(id));
                }
                
            }
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }

        public IActionResult Create()
        { 
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                var pessoas = Pessoa_Repository.ListarPessoas();
                if (HttpContext.Session.GetString("UserRole") == "Colaborador")
                    pessoas = pessoas.Where(x => x.Id == Convert.ToInt64(HttpContext.Session.GetString("UserId"))).ToList();

                ViewBag.Pessoas = pessoas;
                ViewBag.Beneficios = Beneficio_Repository.ListarBeneficios();
                return View();
            }
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BeneficioColaboradorDTO beneficioColaborador)
        {
            Repository.Add(beneficioColaborador);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(long? id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                if (id == null)
                {
                    return BadRequest();
                }
                BeneficioColaboradorDTO beneficio = Repository.GetBeneficioColaborador(id.Value);

                var pessoas = Pessoa_Repository.ListarPessoas();
                if (HttpContext.Session.GetString("UserRole") == "Colaborador")
                    pessoas = pessoas.Where(x => x.Id == Convert.ToInt64(HttpContext.Session.GetString("UserId"))).ToList();

                ViewBag.Pessoas = pessoas;
                ViewBag.Beneficios = Beneficio_Repository.ListarBeneficios();

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
        public IActionResult Edit(BeneficioColaboradorDTO beneficioColaborador)
        {
            if (ModelState.IsValid)
            {
                Repository.Update(beneficioColaborador);
                return RedirectToAction("Index");
            }
            return View(beneficioColaborador);
        }

        public IActionResult Delete(long? id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
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
            else
            {
                return RedirectToAction("NaoAutorizado", "Home", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(BeneficioColaboradorDTO beneficioColaborador)
        {
            BeneficioColaboradorDTO car = Repository.GetBeneficioColaborador(beneficioColaborador.Id);
            if (car != null)
            {
                Repository.Delete(beneficioColaborador.Id);
                TempData["Message"] = "Benefício foi removido";
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
                BeneficioColaboradorDTO beneficio = Repository.GetBeneficioColaborador(id.Value);
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