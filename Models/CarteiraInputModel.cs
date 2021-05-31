using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPA._000.RetornaCarteirasAPI.Models
{
    public class CarteiraInputModel
    {
        [Required]
        public int codigoCarteira { get; set; }
    }
}
