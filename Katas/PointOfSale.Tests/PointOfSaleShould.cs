namespace PointOfSale.Tests;
using PointOfSale;


public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DisplayAnErrorIfBarcodeIsEmpty()
    {
        var scanner = new ProductScanner();
        
        var result = scanner.Scan(new Barcode("")).Value;
        
        result.Should().Be("Error: Empty barcode");
    }

    [Test]
    public void DisplayAnErrorIfBarcodeIsNotValid()
    {
        var scanner = new ProductScanner();
        
        var result = scanner.Scan(new Barcode("99999")).Value;
        
        result.Should().Be("Error: Barcode not found");
    }

    [Test]
    public void DisplayPriceOfARegisteredBarcode()
    {
        var scanner = new ProductScanner();
        
        var result = scanner.Scan(new Barcode("12345")).Value;
        
        result.Should().Be("12,75€");
    }
}