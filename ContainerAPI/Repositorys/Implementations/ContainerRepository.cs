using ContainerAPI.Context;
using ContainerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ContainerAPI.Repositorys.Implementations;

public class ContainerRepository : IContainerRepository
{
    protected ContextoDaAPI _context;

    public ContainerRepository(ContextoDaAPI context)
    {
        _context = context;
    }

    public async Task<List<Container>> GetAll()
    {
        List<Container> container = await _context.Set<Container>().ToListAsync();
        return container;
    }

    public async Task<Container?> GetById(Expression<Func<Container, bool>> predicate)
    {
        Container? container = await _context.Set<Container>().SingleOrDefaultAsync(predicate);
        return container;
    }

    public async Task Post(Container entity)
    {
        _context.Set<Container>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public void Put(Container entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<Container>().Update(entity);
        _context.SaveChanges();
    }
    public void Delete(Container entity)
    {
        _context.Set<Container>().Remove(entity);
        _context.SaveChanges();
    }
}
