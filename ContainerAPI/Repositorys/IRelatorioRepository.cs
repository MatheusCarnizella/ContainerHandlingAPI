using ContainerAPI.Models;
using System.Linq.Expressions;

namespace ContainerAPI.Repositorys;

public interface IRelatorioRepository
{
    Task <List<Container>?> GetByMovimentacao();
}
