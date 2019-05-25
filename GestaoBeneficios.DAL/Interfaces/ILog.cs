using GestaoBeneficios.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoBeneficios.DAL.Interfaces
{
    public interface ILog
    {
        IList<LogDTO> ListarLogs();

        void Add(LogDTO item);

        //void Update(LogDTO item);

        //void Delete(long Id);

        LogDTO GetLog(long Id);
    }
}
