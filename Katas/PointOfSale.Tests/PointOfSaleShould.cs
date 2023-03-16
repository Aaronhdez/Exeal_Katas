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
        var result = ProductScanner.Scan(new Product("")).Value;

        result.Should().Be("Error: Empty barcode");
    }

    [Test]
    public void DisplayAnErrorIfBarcodeIsNotValid()
    {
        var result = ProductScanner.Scan(new Product("99999")).Value;

        result.Should().Be("Error: Barcode not found");
    }

    [Test]
    public void DisplayPriceOfARegisteredBarcode()
    {
        var result = ProductScanner.Scan(new Product("12345")).Value;

        result.Should().Be("7,25€");
    }

    [Test]
    public void DisplayPriceOfAnotherRegisteredBarcode()
    {
        var result = ProductScanner.Scan(new Product("23456")).Value;

        result.Should().Be("12,50€");
    }

    [Test]
    public void DisplayValueOfAGroupOfProducts()
    {
        var products = new Bag(new List<Product>
        {
            new Product("12345"),
            new Product("23456")
        });
        var result = ProductScanner.Total(products).Value;

        result.Should().Be("19,75€");
    }

    [Test]
    public void DisplayValueOfAnotherGroupOfProducts()
    {
        var products = new Bag(new List<Product>
        {
            new Product("12345"),
            new Product("12345"),
            new Product("23456")
        });
        var result = ProductScanner.Total(products).Value;

        result.Should().Be("27,00€");
    }
}