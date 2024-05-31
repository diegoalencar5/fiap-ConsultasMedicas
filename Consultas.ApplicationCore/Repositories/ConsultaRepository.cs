using Consultas.ApplicationCore.Data;
using Consultas.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consultas.ApplicationCore.Repositories
{
    public class ConsultaRepository : GenericRepository<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(AppDbContext _context) : base(_context)
        {
        }

        public override async Task<IEnumerable<Consulta>> GetAll()
        {
            return await Context.Consulta.Include(s => s.Paciente).Include(s => s.Medico).ToListAsync();
        }

    }
}
