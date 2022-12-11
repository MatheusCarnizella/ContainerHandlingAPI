using ContainerAPI.Models;
using System.Linq.Expressions;

namespace ContainerAPI.Repositorys;

public interface IContainerRepository
{
    Task<List<Container>> GetAll();
    Task<Container?> GetById(Expression<Func<Container, bool>> predicate);
    Task Post(Container entity);
    void Put(Container entity);
    void Delete(Container entity);
}
