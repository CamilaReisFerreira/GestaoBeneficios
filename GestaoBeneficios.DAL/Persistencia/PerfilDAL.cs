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
    public class PerfilDAL : IPerfil
    {
        private readonly EFContext _context;

        public PerfilDAL(EFContext context)
        {
            _context = context;
        }

        public PerfilDTO GetPerfil(long Id)
        {
            Perfil perfil = _context.Perfis.Find(Id);
            return perfil != null ?
                new PerfilDTO { Id = perfil.Id,
                    Tipo = perfil.Tipo } : null;
        }

        public IList<PerfilDTO> ListarPerfis()
        {
            List<PerfilDTO> perfils =
            (from o in _context.Perfis
             orderby o.Tipo
             select new PerfilDTO()
             {
                 Id = o.Id,
                 Tipo = o.Tipo
             }).ToList();
            return perfils;
        }
    }
}
