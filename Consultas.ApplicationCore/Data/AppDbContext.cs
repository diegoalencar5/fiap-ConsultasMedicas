using Consultas.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Consultas.ApplicationCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>().HasOne(s => s.Paciente).WithMany(s=> s.Consultas).HasForeignKey(s => s.IdPaciente);
            modelBuilder.Entity<Consulta>().HasOne(s => s.Medico).WithMany(s => s.Consultas).HasForeignKey(s => s.IdMedico);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
