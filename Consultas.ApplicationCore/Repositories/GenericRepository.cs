using Consultas.ApplicationCore.Data;
using Microsoft.EntityFrameworkCore;

namespace Consultas.ApplicationCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected AppDbContext Context;

        public GenericRepository(AppDbContext _context)
        {
            this.Context = _context;
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync();
        }
        public virtual async Task<T> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task Insert(T obj)
        {
            await Context.Set<T>().AddAsync(obj);
            await Context.SaveChangesAsync();
        }
        public async Task Update(int id, T obj)
        {
            Context.Set<T>().Update(obj);
            await Context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
