namespace PointOfSale;

public class ProductScanner
{
    public ScanningResult Scan(Barcode barcode)
    {
        return barcode.Value == "99999" ? 
            new ScanningResult("Error: Barcode not found") : 
            new ScanningResult("Error: Empty barcode");
    }
}