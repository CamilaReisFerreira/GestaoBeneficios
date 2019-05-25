using GestaoBeneficios.DAL.Context;
using GestaoBeneficios.DAL.Entidades;
using GestaoBeneficios.DAL.Interfaces;
using GestaoBeneficios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoBeneficios.DAL.Persistencia
{
    public class BeneficioColaboradorDAL : IBeneficioColaborador
    {
        private readonly EFContext _context;

        public BeneficioColaboradorDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(BeneficioColaboradorDTO item)
        {
            var beneficioColaborador = new BeneficioColaborador
            {
                Quantidade = item.Quantidade,
                ValorTotal = item.ValorTotal
            };

            if (item.Colaborador != null)
                beneficioColaborador.Id_Colaborador = item.Colaborador.Id;
            if (item.Beneficio != null)
                beneficioColaborador.Id_Beneficio = item.Beneficio.Id;

            _context.BeneficiosColaboradores.Add(beneficioColaborador);
            _context.SaveChanges();
        }

        public void Delete(long Id)
        {
            BeneficioColaborador beneficioColaborador = _context.BeneficiosColaboradores.FirstOrDefault(x => x.Id == Id);

            _context.BeneficiosColaboradores.Remove(beneficioColaborador);
            _context.SaveChanges();
        }

        public BeneficioColaboradorDTO GetBeneficioColaborador(long Id)
        {
            BeneficioColaborador beneficioColaborador = _context.BeneficiosColaboradores.Find(Id);
            var colaborador = beneficioColaborador.Id_Colaborador != null ? _context.Pessoas.Find(beneficioColaborador.Id_Colaborador) : null;
            var beneficio = beneficioColaborador.Id_Beneficio != null ? _context.Beneficios.Find(beneficioColaborador.Id_Beneficio) : null;

            return beneficioColaborador != null ?
                new BeneficioColaboradorDTO
                {
                    Id = beneficioColaborador.Id,
                    Quantidade = beneficioColaborador.Quantidade,
                    ValorTotal = beneficioColaborador.ValorTotal,
                    Colaborador = colaborador != null ? new PessoaDTO
                    {
                        Id = colaborador.Id,
                        Nome = colaborador.Nome,
                        Login = colaborador.Login,
                        Senha = colaborador.Senha,
                        CPF = colaborador.CPF,
                        DataAdmissao = colaborador.DataAdmissao,
                        DataNascimento = colaborador.DataNascimento,
                    } : null,
                    Beneficio = beneficio != null ? new BeneficioDTO
                    {
                        Id = beneficio.Id,
                        Nome = beneficio.Nome,
                        FatorConversao = beneficio.FatorConversao
                    } : null
                } : null;
        }

        public IList<BeneficioColaboradorDTO> ListarBeneficiosColaboradores()
        {
            List<BeneficioColaboradorDTO> beneficioColaboradors =
            (from o in _context.BeneficiosColaboradores
             orderby o.ValorTotal
             select new BeneficioColaboradorDTO()
             {
                 Id = o.Id,
                 Quantidade = o.Quantidade,
                 ValorTotal = o.ValorTotal,
                 Colaborador = o.Colaborador != null ? new PessoaDTO
                 {
                     Id = o.Colaborador.Id,
                     Nome = o.Colaborador.Nome,
                     Senha = o.Colaborador.Senha,
                     CPF = o.Colaborador.CPF,
                     DataAdmissao = o.Colaborador.DataAdmissao,
                     DataNascimento = o.Colaborador.DataNascimento
                 } : null,
                 Beneficio = o.Beneficio != null ? new BeneficioDTO
                 {
                     Id = o.Beneficio.Id,
                     Nome = o.Beneficio.Nome,
                     FatorConversao = o.Beneficio.FatorConversao
                 } : null,
             }).ToList();
            return beneficioColaboradors;
        }

        public void Update(BeneficioColaboradorDTO item)
        {
            BeneficioColaborador beneficioColaborador = _context.BeneficiosColaboradores.FirstOrDefault(x => x.Id == item.Id);
            beneficioColaborador.Quantidade = item.Quantidade;
            beneficioColaborador.ValorTotal = item.ValorTotal;

            if (item.Colaborador != null)
                beneficioColaborador.Id_Colaborador = item.Colaborador.Id;
            if (item.Beneficio != null)
                beneficioColaborador.Id_Beneficio = item.Beneficio.Id;

            _context.SaveChanges();
        }
    }
}
