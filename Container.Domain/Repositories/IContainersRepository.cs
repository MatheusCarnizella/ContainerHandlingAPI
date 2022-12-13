using System.Linq.Expressions;
using Container.Domain.Entities;

namespace Container.Domain.Repositories;

public interface IContainersRepository
{
    Task<List<Containers>> GetAll();
    Task<Containers?> GetById(Expression<Func<Containers, bool>> predicate);
    Task Post(Containers entity);
    void Put(Containers entity);
    void Delete(Containers entity);
}
