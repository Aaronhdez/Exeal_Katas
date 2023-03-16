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
        
        result.Should().Be("Error: Barcode not found");
    }
}