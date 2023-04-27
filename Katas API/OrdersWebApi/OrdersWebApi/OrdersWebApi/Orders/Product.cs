namespace OrdersWebApi.Orders;

#pragma warning disable CS8602
public class Product
{
    public string Name { get; }
    public int Value { get; }

    public Product(string name, int value)
    {
        Name = name;
        Value = value;
    }

    private bool Equals(Product other)
    {
        return Name == other.Name && Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Product)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Value);
    }
}