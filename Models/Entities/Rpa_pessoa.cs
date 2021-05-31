using System.ComponentModel.DataAnnotations;

namespace RPA._000.RetornaCarteirasAPI.Models.Entities
{
    public class Rpa_pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Cargo Cargo { get; set; }
    }
}
