using CoffeShop.Domain.Abstraction;
using CoffeShop.Domain.Aggregates.ValueObjects;

namespace CoffeShop.Domain.Aggregates;

public class Drink : IAggregate
{
    public DrinkName Name { get; private set; }
    public IngredientDose[] IngredientDoses { get; private set; }

    public Drink(DrinkName name, IngredientDose[] ingredientDoses)
    {
        Name = name;
        IngredientDoses = ingredientDoses;
    }

    public decimal GetPrice()
    {
        decimal totalCost = IngredientDoses.Sum(dose => dose.Ingredient.Price * dose.Doses);
        return totalCost * 1.30m;
    }
}
