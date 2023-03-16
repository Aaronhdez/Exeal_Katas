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
        
        var result = ProductScanner.Scan(new Product("")).Value;
        
        result.Should().Be("Error: Empty barcode");
    }

    [Test]
    public void DisplayAnErrorIfBarcodeIsNotValid()
    {
        var scanner = new ProductScanner();
        
        var result = ProductScanner.Scan(new Product("99999")).Value;
        
        result.Should().Be("Error: Barcode not found");
    }

    [Test]
    public void DisplayPriceOfARegisteredBarcode()
    {
        var scanner = new ProductScanner();
        
        var result = ProductScanner.Scan(new Product("12345")).Value;
        
        result.Should().Be("7,25€");
    }

    [Test]
    public void DisplayPriceOfAnotherRegisteredBarcode()
    {
        var scanner = new ProductScanner();
        
        var result = ProductScanner.Scan(new Product("23456")).Value;
        
        result.Should().Be("12,50€");
    }
}