using ProjetoPainel.Models;
using ProjetoPainel.Models.Data;
using ProjetoPainel.Repository.Interface;
using RPA._000.RetornaCarteirasAPI.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPainel.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly DataContext _context;
        public PessoaRepository(DataContext context)
        {
            _context = context;
        }
        public void inserirPessoa(InPessoa pessoa)
        {
            _context.rpa_pessoa.Add(new Rpa_pessoa { Nome = pessoa.nomePessoa, Cargo = (Cargo)pessoa.cargo});
            _context.SaveChanges();
        }

        public Rpa_pessoa buscaPessoa(int id)
        {
            return _context.rpa_pessoa.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Rpa_pessoa> getPessoas()
        {
            return _context.rpa_pessoa.ToList();
        }
    }
}
