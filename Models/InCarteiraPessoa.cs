using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPainel.Models
{
    public class InCarteiraPessoa
    {
        public int id_super { get; set; }
        public int id_executivo { get; set; }
        public int cod_carteira { get; set; }
        public int id_coordenador { get; set; }
        public int id_bp { get; set; }
        public int id_lidertecnico { get; set; } 
        public int id_programador { get; set; } 
    }
}
