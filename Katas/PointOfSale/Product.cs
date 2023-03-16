namespace PointOfSale;

public class Product
{
    public Product(string barcode)
    {
        Value = barcode;
    }

    public string Value { get; }
}