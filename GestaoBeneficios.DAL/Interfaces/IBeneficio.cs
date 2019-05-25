using GestaoBeneficios.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoBeneficios.DAL.Interfaces
{
    public interface IBeneficio
    {
        IList<BeneficioDTO> ListarBeneficios();

        void Add(BeneficioDTO item);

        void Update(BeneficioDTO item);

        void Delete(long Id);

        BeneficioDTO GetBeneficio(long Id);
    }
}
