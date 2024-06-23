using CoffeShop.Domain.Abstraction;

namespace CoffeShop.Domain.Repositories;

public interface IBaseRepository<T> where T : IAggregate
{
    T Get(IIdentifier id);
    T[] GetAll();
}
