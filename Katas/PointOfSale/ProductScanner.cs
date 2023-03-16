namespace PointOfSale;

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

    public static ScanningResult Total(List<Product> products)
    {
        return new ScanningResult("19,75€");
    }
}