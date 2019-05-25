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
    public class CargoDAL : ICargo
    {
        private readonly EFContext _context;

        public CargoDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(CargoDTO item)
        {
            var cargo = new Cargo
            {
                Nome = item.Nome,
                ValorBeneficio = item.ValorBeneficio
            };

            _context.Cargos.Add(cargo);
            _context.SaveChanges();
        }

        public void Delete(long Id)
        {
            Cargo cargo = _context.Cargos.FirstOrDefault(x => x.Id == Id);

            _context.Cargos.Remove(cargo);
            _context.SaveChanges();
        }

        public CargoDTO GetCargo(long Id)
        {
            Cargo cargo = _context.Cargos.Find(Id);
            return cargo != null ?
                new CargoDTO { Id = cargo.Id,
                    Nome = cargo.Nome,
                    ValorBeneficio = cargo.ValorBeneficio } : null;
        }

        public IList<CargoDTO> ListarCargos()
        {
            List<CargoDTO> cargos =
            (from o in _context.Cargos
             orderby o.Nome
             select new CargoDTO()
             {
                 Id = o.Id,
                 Nome = o.Nome,
                 ValorBeneficio = o.ValorBeneficio
             }).ToList();
            return cargos;
        }

        public void Update(CargoDTO item)
        {
            Cargo cargo = _context.Cargos.FirstOrDefault(x => x.Id == item.Id);
            cargo.Nome = item.Nome;
            cargo.ValorBeneficio = cargo.ValorBeneficio;
            _context.SaveChanges();
        }
    }
}
