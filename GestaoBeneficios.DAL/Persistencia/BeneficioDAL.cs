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
    public class BeneficioDAL : IBeneficio
    {
        private readonly EFContext _context;

        public BeneficioDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(BeneficioDTO item)
        {
            var beneficio = new Beneficio
            {
                Nome = item.Nome,
                FatorConversao = item.FatorConversao
            };

            _context.Beneficios.Add(beneficio);
            _context.SaveChanges();
        }

        public void Delete(long Id)
        {
            Beneficio beneficio = _context.Beneficios.FirstOrDefault(x => x.Id == Id);

            _context.Beneficios.Remove(beneficio);
            _context.SaveChanges();
        }

        public BeneficioDTO GetBeneficio(long Id)
        {
            Beneficio beneficio = _context.Beneficios.Find(Id);
            return beneficio != null ?
                new BeneficioDTO { Id = beneficio.Id,
                    Nome = beneficio.Nome,
                    FatorConversao = beneficio.FatorConversao } : null;
        }

        public IList<BeneficioDTO> ListarBeneficios()
        {
            List<BeneficioDTO> beneficios =
            (from o in _context.Beneficios
             orderby o.Nome
             select new BeneficioDTO()
             {
                 Id = o.Id,
                 Nome = o.Nome,
                 FatorConversao = o.FatorConversao
             }).ToList();
            return beneficios;
        }

        public void Update(BeneficioDTO item)
        {
            Beneficio beneficio = _context.Beneficios.FirstOrDefault(x => x.Id == item.Id);
            beneficio.Nome = item.Nome;
            beneficio.FatorConversao = beneficio.FatorConversao;
            _context.SaveChanges();
        }
    }
}
