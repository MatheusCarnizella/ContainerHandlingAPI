using Container.Domain.Entities;
using Container.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Container.Domain.Repositories.Repositories
{
    public class ContainerRepository : IContainersRepository
    {
        protected ContextoDaAPI _context;

        public ContainerRepository(ContextoDaAPI context)
        {
            _context = context;
        }

        public async Task<List<Containers>> GetAll()
        {
            List<Containers> container = await _context.Set<Containers>().ToListAsync();
            return container;
        }

        public async Task<Containers?> GetById(Expression<Func<Containers, bool>> predicate)
        {
            Containers? container = await _context.Set<Containers>().SingleOrDefaultAsync(predicate);
            return container;
        }

        public async Task Post(Containers entity)
        {
            _context.Set<Containers>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public void Put(Containers entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<Containers>().Update(entity);
            _context.SaveChanges();
        }
        public void Delete(Containers entity)
        {
            _context.Set<Containers>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
