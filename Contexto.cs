using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ADS.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base("EscolaMVC") { }

        public DbSet<Escola> Escola { get; set; }
        public DbSet<Estudante> Estudante { get; set; }

    }
}
