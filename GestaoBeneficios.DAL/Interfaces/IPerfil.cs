using GestaoBeneficios.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoBeneficios.DAL.Interfaces
{
    public interface IPerfil
    {
        IList<PerfilDTO> ListarPerfis();

        PerfilDTO GetPerfil(long Id);
    }
}
