using ProjetoPainel.Models;
using RPA._000.RetornaCarteirasAPI.Models;
using RPA._000.RetornaCarteirasAPI.Models.Entities;
using System.Collections.Generic;

namespace ProjetoPainel.Repository.Interface
{
    public interface IRepository
    {
        bool AssociarPessoaCarteira(InCarteiraPessoa inCarteiraPessoa);
        void InserePessoa(string nomePessoa, int cargo);
        List<PessoaModel> GetPessoas();
        CarteiraModel GetCarteiraPorID(int codigoCarteira);
    }
}
