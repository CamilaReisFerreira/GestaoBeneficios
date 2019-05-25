using GestaoBeneficios.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoBeneficios.DAL.Interfaces
{
    public interface IPessoa
    {
        IList<PessoaDTO> ListarPessoas();

        void Add(PessoaDTO item);

        void Update(PessoaDTO item);

        void Delete(long Id);

        PessoaDTO GetPessoa(long Id);
    }
}
