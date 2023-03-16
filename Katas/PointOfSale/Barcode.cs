namespace PointOfSale;

public class Barcode
{
    public Barcode(string barcode)
    {
        Value = barcode;
    }

    private string Value { get; }
}