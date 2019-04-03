using GestaoBeneficios.DAL.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoBeneficios.DAL.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options) { }

        public DbSet<Beneficio> Beneficios { get; set; }
        public DbSet<BeneficioColaborador> BeneficiosColaboradores { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
