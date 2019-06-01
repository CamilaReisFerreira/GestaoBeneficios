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
    public class PessoaDAL : IPessoa
    {
        private readonly EFContext _context;

        public PessoaDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(PessoaDTO item)
        {
            var pessoa = new Pessoa
            {
                Nome = item.Nome,
                Login = item.Login,
                Senha = item.Senha,
                CPF = item.CPF,
                DataAdmissao = item.DataAdmissao,
                DataNascimento = item.DataNascimento
            };

            if (item.Cargo != null)
                pessoa.CargoId = item.Cargo.Id;
            if (item.Perfil != null)
                pessoa.PerfilId = item.Perfil.Id;

            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
        }

        public void Delete(long Id)
        {
            Pessoa pessoa = _context.Pessoas.FirstOrDefault(x => x.Id == Id);

            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
        }

        public PessoaDTO GetPessoa(long Id)
        {
            Pessoa pessoa = _context.Pessoas.Find(Id);
            return GetPesoaDTO(pessoa);
        }

        public IList<PessoaDTO> ListarPessoas()
        {
            List<PessoaDTO> pessoas =
            (from o in _context.Pessoas
             orderby o.Nome
             select new PessoaDTO()
             {
                 Id = o.Id,
                 Nome = o.Nome,
                 Login = o.Login,
                 Senha = o.Senha,
                 CPF = o.CPF,
                 DataAdmissao = o.DataAdmissao,
                 DataNascimento = o.DataNascimento,
                 Cargo = o.Cargo != null ? new CargoDTO
                 {
                     Id = o.Cargo.Id,
                     Nome = o.Cargo.Nome,
                     ValorBeneficio = o.Cargo.ValorBeneficio
                 } : null,
                 Perfil = o.Perfil != null ? new PerfilDTO
                 {
                     Id = o.Perfil.Id,
                     Tipo = o.Perfil.Tipo
                 } : null
             }).ToList();
            return pessoas;
        }

        public void Update(PessoaDTO item)
        {
            Pessoa pessoa = _context.Pessoas.FirstOrDefault(x => x.Id == item.Id);
            pessoa.Nome = item.Nome;
            pessoa.Login = item.Login;
            pessoa.Senha = item.Senha;
            pessoa.CPF = item.CPF;
            pessoa.DataAdmissao = item.DataAdmissao;
            pessoa.DataNascimento = item.DataNascimento;

            if (item.Cargo != null)
                pessoa.CargoId = item.Cargo.Id;
            if (item.Perfil != null)
                pessoa.PerfilId = item.Perfil.Id;

            _context.SaveChanges();
        }

        public PessoaDTO Login(string login, string senha)
        {
            Pessoa pessoa = _context.Pessoas.Where(x=> x.Login == login && x.Senha == senha).FirstOrDefault();
            return GetPesoaDTO(pessoa);
        }

        private PessoaDTO GetPesoaDTO(Pessoa pessoa)
        {
            var cargo = pessoa.CargoId != null ? _context.Cargos.Find(pessoa.CargoId) : null;
            var perfil = pessoa.PerfilId != null ? _context.Perfis.Find(pessoa.PerfilId) : null;

            return pessoa != null ?
                new PessoaDTO
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Login = pessoa.Login,
                    Senha = pessoa.Senha,
                    CPF = pessoa.CPF,
                    DataAdmissao = pessoa.DataAdmissao,
                    DataNascimento = pessoa.DataNascimento,
                    Cargo = cargo != null ? new CargoDTO
                    {
                        Id = cargo.Id,
                        Nome = cargo.Nome,
                        ValorBeneficio = cargo.ValorBeneficio
                    } : null,
                    Perfil = perfil != null ? new PerfilDTO
                    {
                        Id = perfil.Id,
                        Tipo = perfil.Tipo
                    } : null
                } : null;
        }
    }
}
