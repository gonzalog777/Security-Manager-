using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecurityManager.Models;
using SecurityManager.Models.AppModels;

namespace SecurityManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ReporteAlarma> Alarmas { get; set; }
        public DbSet<ReporteAccidente> Accidentes { get; set; }
        public DbSet<ReporteEpp> Epps { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ReporteAlarma>().ToTable("Alarma");
            builder.Entity<ReporteAccidente>().ToTable("Accidente");
            builder.Entity<ReporteEpp>().ToTable("Epp");
            builder.Entity<Cargo>().ToTable("Cargo");
            builder.Entity<Empleado>().ToTable("Empleado");
        }
    }
}
