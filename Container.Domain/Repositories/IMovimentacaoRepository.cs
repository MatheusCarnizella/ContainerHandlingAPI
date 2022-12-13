using Container.Domain.Entities;
using System.Linq.Expressions;

namespace Container.Domain.Repositories;

public interface IMovimentacaoRepository
{
    Task<List<Movimentacao>> GetAll();
    Task<Movimentacao?> GetById(Expression<Func<Movimentacao, bool>> predicate);
    Task Post(Movimentacao entity);
    void Put(Movimentacao entity);
    void Delete(Movimentacao entity);
}
