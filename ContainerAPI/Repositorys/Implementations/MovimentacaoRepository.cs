using ContainerAPI.Context;
using ContainerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ContainerAPI.Repositorys.Implementations;

public class MovimentacaoRepository : IMovimentacaoRepository
{
    protected ContextoDaAPI _context;

    public MovimentacaoRepository(ContextoDaAPI context)
    {
        _context = context;
    }
    public async Task<List<Movimentacao>> GetAll()
    {
        List<Movimentacao> movimentacao = await _context.Set<Movimentacao>().ToListAsync();
        return movimentacao;
    }

    public async Task<Movimentacao?> GetById(Expression<Func<Movimentacao, bool>> predicate)
    {
        Movimentacao? movimentacao = await _context.Set<Movimentacao>().SingleOrDefaultAsync(predicate);
        return movimentacao;
    }

    public async Task Post(Movimentacao entity)
    {
        _context.Set<Movimentacao>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public void Put(Movimentacao entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<Movimentacao>().Update(entity);
        _context.SaveChanges();
    }
    public void Delete(Movimentacao entity)
    {
        _context.Set<Movimentacao>().Remove(entity);
        _context.SaveChanges();
    }
}
