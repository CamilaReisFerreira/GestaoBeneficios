using GestaoBeneficios.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoBeneficios.DAL.Interfaces
{
    public interface IBeneficioColaborador
    {
        IList<BeneficioColaboradorDTO> ListarBeneficiosColaboradores();

        IList<BeneficioColaboradorDTO> ListarBeneficiosPorPessoa(long Id);

        void Add(BeneficioColaboradorDTO item);

        void Update(BeneficioColaboradorDTO item);

        void Delete(long Id);

        BeneficioColaboradorDTO GetBeneficioColaborador(long Id);
    }
}
