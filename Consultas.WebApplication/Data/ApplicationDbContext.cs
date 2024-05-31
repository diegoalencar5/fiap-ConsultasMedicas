using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Consultas.WebApplication.Models;

namespace Consultas.WebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Consultas.WebApplication.Models.ConsultaViewModel> ConsultaViewModel { get; set; } = default!;
    }
}
