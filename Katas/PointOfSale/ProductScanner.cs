namespace PointOfSale;

public class ProductScanner
{
    public ScanningResult Scan(Barcode barcode)
    {
        return new ScanningResult("Error: Barcode not found");
    }
}