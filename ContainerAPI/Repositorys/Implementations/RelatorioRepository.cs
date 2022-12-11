using ContainerAPI.Context;
using ContainerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ContainerAPI.Repositorys.Implementations;

public class RelatorioRepository : IRelatorioRepository
{
    protected ContextoDaAPI _context;

    public RelatorioRepository(ContextoDaAPI context)
    {
        _context = context;
    }

    public async Task<List<Container>?> GetByMovimentacao()
    {
        List<Container> container = await _context.Containers.Include(x => x.Movimentacao).ToListAsync();
        return container;
    }
}
