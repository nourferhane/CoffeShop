using CoffeShop.Domain.Abstraction;
using System.Numerics;

namespace CoffeShop.Domain.Aggregates.ValueObjects;

public class DrinkName(string identifier) : IIdentifier, IEquatable<DrinkName>
{
    private string _name = string.IsNullOrWhiteSpace(identifier) ? throw new ArgumentException("Drink identifier cannot be null or whitespace.") :
            identifier;

    public static DrinkName ToDrinkIdentifier(string id) => new(id);

    public string GetIdentifier() => _name;

    public static DrinkName Espresso => new(nameof(Espresso));
    public static DrinkName Milk => new(nameof(Milk));
    public static DrinkName Capuccino => new(nameof(Capuccino));
    public static DrinkName HotChocolate => new(nameof(HotChocolate));
    public static DrinkName CoffeMilk => new(nameof(CoffeMilk));
    public static DrinkName Mokaccino => new(nameof(Mokaccino));
    public static DrinkName Tea => new(nameof(Tea));

    public static DrinkName NameFor(string name) => new(name);

    public override string ToString() => _name;

    public bool Equals(DrinkName? other)
    {
        return other is not null && other._name.Equals(_name, StringComparison.OrdinalIgnoreCase);
    }
}
