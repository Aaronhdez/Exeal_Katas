namespace PointOfSale;

public class Barcode
{
    public Barcode(string barcode)
    {
        Value = barcode;
    }

    public string Value { get; }
}