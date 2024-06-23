using CoffeShop.Domain.Repositories;
using CoffeShop.Domain.Services;

namespace CoffeShop.Infrastructure.Services;

public class DrinkService : IDrinkService
{
    public readonly IDrinkRepository _repository;
    public DrinkService(IDrinkRepository repository)
    {
        _repository = repository;
    }
    public string[] GetAllDrinkNames()
    {
        return _repository.GetAll().Select(x => x.Name.ToString()).ToArray()!;
    }
}
