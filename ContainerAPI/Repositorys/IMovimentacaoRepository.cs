using ContainerAPI.Models;
using System.Linq.Expressions;

namespace ContainerAPI.Repositorys;

public interface IMovimentacaoRepository
{
    Task<List<Movimentacao>> GetAll();
    Task<Movimentacao?> GetById(Expression<Func<Movimentacao, bool>> predicate);
    Task Post(Movimentacao entity);
    void Put(Movimentacao entity);
    void Delete(Movimentacao entity);
}
