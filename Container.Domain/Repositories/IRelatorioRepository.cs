using Container.Domain.Entities;

namespace Container.Domain.Repositories;

public interface IRelatorioRepository
{
    Task<List<Containers>?> GetByMovimentacao();
}
