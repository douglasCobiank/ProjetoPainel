using ProjetoPainel.Models;
using RPA._000.RetornaCarteirasAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPainel.Repository.Interface
{
    public interface IPessoaRepository
    {
        public void inserirPessoa(InPessoa pessoa );
        Rpa_pessoa buscaPessoa(int id);
        List<Rpa_pessoa> getPessoas();
    }
}
