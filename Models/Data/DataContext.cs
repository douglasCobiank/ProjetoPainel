using Microsoft.EntityFrameworkCore;
using RPA._000.RetornaCarteirasAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPainel.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Rpa_carteirapessoa> rpa_carteirapessoa { get; set; }
        public DbSet<Rpa_pessoa> rpa_pessoa { get; set; }

    }
}
