namespace PointOfSale;

public class ProductScanner
{
    public ScanningResult Scan(Barcode barcode)
    {
        if(barcode.Value == "99999") return new ScanningResult("Error: Barcode not found");
        return new ScanningResult("Error: Empty barcode");
    }
}