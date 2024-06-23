using CoffeShop.Domain.Aggregates.Entities;

namespace CoffeShop.Domain.Aggregates.ValueObjects
{
    public class IngredientDose(Ingredient ingredient, int doses)
    {
        public Ingredient Ingredient { get; private set; } = ingredient;
        public int Doses { get; private set; } = doses;
    }
}
