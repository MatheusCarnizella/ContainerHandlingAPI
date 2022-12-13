using Container.Domain.Entities;
using Container.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Container.Domain.Repositories.Repositories;

public class RelatorioRepository : IRelatorioRepository
{
    protected ContextoDaAPI _context;

    public RelatorioRepository(ContextoDaAPI context)
    {
        _context = context;
    }

    public async Task<List<Containers>?> GetByMovimentacao()
    {
        List<Containers> container = await _context.Containers.Include(x => x.Movimentacao).ToListAsync();
        return container;
    }
}
