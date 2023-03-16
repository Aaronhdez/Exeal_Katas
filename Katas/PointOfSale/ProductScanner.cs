namespace PointOfSale;

public class ProductScanner
{
    public ScanningResult Scan(Barcode barcode)
    {
        if (barcode.Value == "12345") return new ScanningResult("12,75€");
        return barcode.Value == "99999" ? 
            new ScanningResult("Error: Barcode not found") : 
            new ScanningResult("Error: Empty barcode");
    }
}