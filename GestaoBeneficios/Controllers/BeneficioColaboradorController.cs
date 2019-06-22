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
        public ILog Log_Repository { get; set; }

        public BeneficioColaboradorController(IBeneficioColaborador _repository,
            IBeneficio _beneficioRepository, IPessoa _pessoaRepository, ILog _logRepository)
        {
            Repository = _repository;
            Beneficio_Repository = _beneficioRepository;
            Pessoa_Repository = _pessoaRepository;
            Log_Repository = _logRepository;
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
            Log_Repository.Add(new LogDTO(beneficioColaborador,"Incluído"));
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
                var entity = Repository.GetBeneficioColaborador(beneficioColaborador.Id);
                Repository.Update(beneficioColaborador);

                #region Log

                if (entity.Colaborador?.Id != beneficioColaborador.Colaborador?.Id)
                {
                    var pessoa = Pessoa_Repository.GetPessoa(beneficioColaborador.Colaborador.Id);
                    Log_Repository.Add(new LogDTO(entity, "Alterado", "Colaborador", entity.Colaborador.Nome, pessoa.Nome));
                }
                if (entity.Beneficio?.Id != beneficioColaborador.Beneficio?.Id)
                {
                    var beneficio = Beneficio_Repository.GetBeneficio(beneficioColaborador.Beneficio.Id);
                    Log_Repository.Add(new LogDTO(entity, "Alterado", "Benefício", entity.Beneficio.Nome, beneficio.Nome));
                }
                if (entity.Quantidade != beneficioColaborador.Quantidade)
                {
                    Log_Repository.Add(new LogDTO(entity, "Alterado", "Quantidade", entity.Quantidade.ToString(), beneficioColaborador.Quantidade.ToString()));
                }
                if (entity.ValorTotal != beneficioColaborador.ValorTotal)
                {
                    Log_Repository.Add(new LogDTO(entity, "Alterado", "ValorTotal", entity.ValorTotal.ToString(), beneficioColaborador.ValorTotal.ToString()));
                }

                #endregion

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
            BeneficioColaboradorDTO entity = Repository.GetBeneficioColaborador(beneficioColaborador.Id);
            if (entity != null)
            {
                Repository.Delete(beneficioColaborador.Id);
                Log_Repository.Add(new LogDTO(entity, "Excluído"));
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