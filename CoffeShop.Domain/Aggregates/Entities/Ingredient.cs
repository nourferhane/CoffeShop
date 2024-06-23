using CoffeShop.Domain.Abstraction;

namespace CoffeShop.Domain.Aggregates.Entities;

public class Ingredient : IEntity
{
    public readonly string Name;
    public decimal Price { get; private set; }
    private readonly string[] _authorizedIngredients =
        [
            "Milk",
            "Coffee",
            "Chocolate",
            "Tea",
            "Water",
        ];

    public Ingredient(string name, decimal price)
    {
        var authorizedName = _authorizedIngredients.FirstOrDefault(i => i.Equals(name, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentException($"Ingredient '{name}' is not authorized.");
        Name = authorizedName;
        Price = price > 0 ? price : throw new ArgumentException("Ingredeitn price can not be lower or equals zero");
    }
}
