using RPA._000.RetornaCarteirasAPI.Models.Entities;

namespace ProjetoPainel.Repository.Interface
{
    public interface ICarteiraPessoaRepository
    {
        void InsereCarteiraPessoa(Rpa_carteirapessoa rpa_Carteirapessoa);
        Rpa_carteirapessoa GetCarteirapessoa(int cod_carteira);
        void AtualizaCarteiraPessoa(Rpa_carteirapessoa rpa_Carteirapessoa);
        Rpa_carteirapessoa getCarteiraPorId(int codigoCarteira);
    }
}
