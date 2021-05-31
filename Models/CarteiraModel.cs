using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPA._000.RetornaCarteirasAPI.Models
{
    public class CarteiraModel
    {
        public string cod { get; set; }
        public int id_gecliente_int { get; set; }
        public string carteira { get; set; }
        public string tab_filha { get; set; }
        public string ip { get; set; }
        public string banco { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }

        public int? idsuper { get; set; }
        public string super { get; set; }
        public int? idexecutivo { get; set; }
        public string executivo { get; set; }
        public int? idcoordenador { get; set; }
        public string coordenador { get; set; }
        public int? idbp { get; set; }
        public string bp { get; set; }
        public int? idlidertecnico { get; set; }
        public string lidertecnico { get; set; }
        public int? idprogramador { get; set; }
        public string programador { get; set; }
        [NotMapped]
        public bool erro { get; set; }
    }
}
