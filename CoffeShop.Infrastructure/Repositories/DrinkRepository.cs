using CoffeShop.Domain.Abstraction;
using CoffeShop.Domain.Aggregates;
using CoffeShop.Domain.Aggregates.Entities;
using CoffeShop.Domain.Aggregates.ValueObjects;
using CoffeShop.Domain.Repositories;
using CoffeShop.Infrastructure.Exceptions;

namespace CoffeShop.Infrastructure.Repositories;

public class DrinkRepository : IDrinkRepository
{
    private IReadOnlyCollection<Drink> _drinks;
    public DrinkRepository()
    {
        var milk = new Ingredient("Milk", 0.10m);
        var coffee = new Ingredient("Coffee", 0.30m);
        var chocolate = new Ingredient("Chocolate", 0.40m);
        var tea = new Ingredient("Tea", 0.30m);
        var water = new Ingredient("Water", 0.05m);

        _drinks = new List<Drink>
        {
            new(DrinkName.Espresso,
            [
                new IngredientDose(water, 2),
                new IngredientDose(coffee, 1)
            ]),
            new(DrinkName.Milk,
            [
                new IngredientDose(milk, 2),
                new IngredientDose(water, 1)
            ]),
            new(DrinkName.Capuccino,
            [
                new IngredientDose(milk, 2),
                new IngredientDose(water, 1),
                new IngredientDose(coffee, 1),
                new IngredientDose(chocolate, 1)
            ]),
            new(DrinkName.HotChocolate,
            [
                new IngredientDose(milk, 3),
                new IngredientDose(chocolate, 2)
            ]),
            new(DrinkName.CoffeMilk,
            [
                new IngredientDose(milk, 1),
                new IngredientDose(water, 2),
                new IngredientDose(coffee, 1)
            ]),
            new (DrinkName.Mokaccino,
            [
                new IngredientDose(milk, 1),
                new IngredientDose(water, 2),
                new IngredientDose(coffee, 1),
                new IngredientDose(chocolate, 2)
            ]),
            new(DrinkName.Tea,
            [
                new IngredientDose(water, 2),
                new IngredientDose(tea, 1)
            ])
        };
    }

    public Drink Get(IIdentifier id)
    {
        var dring = _drinks.FirstOrDefault(d => d.Name.Equals(DrinkName.NameFor(id.ToString())));
        return dring ?? throw new EntityNotFoundException();
    }

    public Drink[] GetAll() => _drinks.ToArray();
}
