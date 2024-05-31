using Consultas.ApplicationCore.Data;
using Consultas.ApplicationCore.Entities;

namespace Consultas.ApplicationCore.Repositories
{
    public class MedicoRepository : GenericRepository<Medico>, IMedicoRepository
    {
        public MedicoRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}
