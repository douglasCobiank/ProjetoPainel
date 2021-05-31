using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPA._000.RetornaCarteirasAPI.Models.Entities
{
    public class Rpa_carteirapessoa
    {
        public int Id { get; set; }
        public Rpa_pessoa Super { get; set; }
        public int Id_executivo { get; set; }
        public Rpa_pessoa Executivo { get; set; }
        public int Cod_carteira { get; set; }
        public Rpa_pessoa Coordenador { get; set; }
        public Rpa_pessoa BP { get; set; }
        public Rpa_pessoa LiderTecnico { get; set; }
        public Rpa_pessoa Programador { get; set; }
    }
}
