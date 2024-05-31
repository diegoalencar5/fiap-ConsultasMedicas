using Consultas.ApplicationCore.Data;
using Consultas.ApplicationCore.Entities;

namespace Consultas.ApplicationCore.Repositories
{
    public class PacienteRepository : GenericRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}
