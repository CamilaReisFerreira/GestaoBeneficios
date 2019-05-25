using GestaoBeneficios.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoBeneficios.DAL.Interfaces
{
    public interface ICargo
    {
        IList<CargoDTO> ListarCargos();

        void Add(CargoDTO item);

        void Update(CargoDTO item);

        void Delete(long Id);

        CargoDTO GetCargo(long Id);
    }
}
