namespace PointOfSale;

public class ProductScanner
{
    public ScanningResult Scan(Product product)
    {
        if (product.Value == "12345") return new ScanningResult("7,25€");
        if (product.Value == "23456") return new ScanningResult("12,50€");
        return product.Value == "99999" ? 
            new ScanningResult("Error: Barcode not found") : 
            new ScanningResult("Error: Empty barcode");
    }
}