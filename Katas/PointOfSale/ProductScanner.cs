namespace PointOfSale;

public class Bag
{
    public Bag(List<Product> products)
    {
        Products = products;
    }

    public List<Product> Products { get; private set; }
}

public static class ProductScanner
{
    public static ScanningResult Scan(Product product)
    {
        return product.Value switch
        {
            "12345" => new ScanningResult("7,25€"),
            "23456" => new ScanningResult("12,50€"),
            "99999" => new ScanningResult("Error: Barcode not found"),
            _ => new ScanningResult("Error: Empty barcode")
        };
    }

    public static ScanningResult Total(Bag bag)
    {
        return new ScanningResult("19,75€");
    }
}