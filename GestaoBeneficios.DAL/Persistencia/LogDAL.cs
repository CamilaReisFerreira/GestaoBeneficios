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
    public class LogDAL : ILog
    {
        private readonly EFContext _context;

        public LogDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(LogDTO item)
        {
            var log = new Log
            {
                Operacao = item.Operacao,
                Campo = item.Campo,
                ValorAnterior = item.ValorAnterior,
                ValorAtual = item.ValorAtual,
                Data = item.Data
            };

            if (item.Colaborador != null)
                log.ColaboradorId = item.Colaborador.Id;
            if (item.Beneficio != null)
                log.BeneficioId = item.Beneficio.Id;

            _context.Logs.Add(log);
            _context.SaveChanges();
        }

        public LogDTO GetLog(long Id)
        {
            Log log = _context.Logs.Find(Id);
            var colaborador = log.ColaboradorId != null ? _context.Pessoas.Find(log.ColaboradorId) : null;
            var beneficio = log.BeneficioId != null ? _context.Beneficios.Find(log.BeneficioId) : null;

            return log != null ?
                new LogDTO
                {
                    Id = log.Id,
                    Operacao = log.Operacao,
                    Campo = log.Campo,
                    ValorAnterior = log.ValorAnterior,
                    ValorAtual = log.ValorAtual,
                    Data = log.Data,
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

        public IList<LogDTO> ListarLogs()
        {
            List<LogDTO> logs =
            (from log in _context.Logs
             orderby log.Data descending
             select new LogDTO()
             {
                 Id = log.Id,
                 Operacao = log.Operacao,
                 Campo = log.Campo,
                 ValorAnterior = log.ValorAnterior,
                 ValorAtual = log.ValorAtual,
                 Data = log.Data,
                 Colaborador = log.Colaborador != null ? new PessoaDTO
                 {
                     Id = log.Colaborador.Id,
                     Nome = log.Colaborador.Nome,
                     Senha = log.Colaborador.Senha,
                     CPF = log.Colaborador.CPF,
                     DataAdmissao = log.Colaborador.DataAdmissao,
                     DataNascimento = log.Colaborador.DataNascimento
                 } : null,
                 Beneficio = log.Beneficio != null ? new BeneficioDTO
                 {
                     Id = log.Beneficio.Id,
                     Nome = log.Beneficio.Nome,
                     FatorConversao = log.Beneficio.FatorConversao
                 } : null,
             }).ToList();
            return logs;
        }

    }
}
