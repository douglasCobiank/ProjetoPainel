using Microsoft.EntityFrameworkCore;
using ProjetoPainel.Models.Data;
using ProjetoPainel.Repository.Interface;
using RPA._000.RetornaCarteirasAPI.Models.Entities;
using System;
using System.Linq;

namespace ProjetoPainel.Repository
{
    public class CarteiraPessoaRepository : ICarteiraPessoaRepository
    {
        private readonly DataContext _context;
        public CarteiraPessoaRepository(DataContext context)
        {
            _context = context;
        }

        public void InsereCarteiraPessoa(Rpa_carteirapessoa rpa_Carteirapessoa)
        {
            _context.rpa_carteirapessoa.Add(rpa_Carteirapessoa);
            _context.SaveChanges();
        }

        public Rpa_carteirapessoa GetCarteirapessoa(int cod_carteira)
        {
            return _context.rpa_carteirapessoa.Where(x => x.Cod_carteira == cod_carteira).FirstOrDefault();
        }

        public void AtualizaCarteiraPessoa(Rpa_carteirapessoa rpa_Carteirapessoa)
        {
            _context.rpa_carteirapessoa.Update(rpa_Carteirapessoa);
            _context.SaveChanges();
        }

        public Rpa_carteirapessoa getCarteiraPorId(int codigoCarteira)
        {
            try
            {
                return _context.rpa_carteirapessoa
                        .Include(x => x.BP)
                        .Include(x => x.Coordenador)
                        .Include(x => x.Executivo)
                        .Include(x => x.LiderTecnico)
                        .Include(x => x.Programador)
                        .Include(x => x.Super)
                        .Where(x => x.Cod_carteira == codigoCarteira).FirstOrDefault();
            }
            catch
            {
                throw new Exception("Ocorreu um erro ao tentar buscar a carteira");
            }
        }
    }
}
