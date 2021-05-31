using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPainel.Models
{
    public class PessoaModel
    {
        public int? idPessoa { get; set; }
        public string nomePessoa { get; set; }
        public int cargoPessoa { get; set; }
        [NotMapped]
        public bool erro { get; set; }
    }
}
