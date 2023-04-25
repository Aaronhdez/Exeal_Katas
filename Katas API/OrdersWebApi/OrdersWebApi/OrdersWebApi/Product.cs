namespace OrdersWebApi;

#pragma warning disable CS8602
public class Product
{
    private string Name { get; }
    private int Value { get; }

    public Product(string name, int value)
    {
        Name = name;
        Value = value;
    }
}