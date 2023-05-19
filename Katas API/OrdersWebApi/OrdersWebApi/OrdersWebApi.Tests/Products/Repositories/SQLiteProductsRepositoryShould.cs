using System.Data.SQLite;
using FluentAssertions;
using OrdersWebApi.Orders.Repositories;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Queries;
using OrdersWebApi.Products.Repositories;
using OrdersWebApi.Tests.Orders.Repositories;

namespace OrdersWebApi.Tests.Products.Repositories;

public class SQLiteProductsRepositoryShould {
    private Product _product;
    private SQLiteConnection _sqLiteConnection;
    private SQLiteProductsRepository _sqLiteProductsRepository;
    private TestDBLoader _testDBLoader;
    private ProductReadDto _productDto;

    [SetUp]
    public async Task SetUp() {
        _product = ProductDefaultValues.ComputerMonitor;
        _productDto = new ProductReadDto{
            Id = ProductDefaultValues.ComputerMonitorId, 
            ProductReference = null, 
            Name = ProductDefaultValues.ComputerMonitor.Name, 
            Description = null,
            Manufacturer = null, 
            ManufacturerReference = null, 
            Value = (int) ProductDefaultValues.ComputerMonitor.Value};
        _sqLiteConnection = new SQLiteConnection("Data Source=:memory:");
        _testDBLoader = new TestDBLoader(_sqLiteConnection);
        _sqLiteProductsRepository = new SQLiteProductsRepository(_sqLiteConnection);
        _sqLiteConnection.Open();
        await _testDBLoader.LoadDatabase(_sqLiteConnection);
    }

    [TearDown]
    public async Task Teardown() {
        await _testDBLoader.ClearDatabase(_sqLiteConnection);
        _sqLiteConnection.Close();
        _sqLiteConnection.Dispose();
    }

    [Test]
    public void RetrieveAProductWhileRequested() {
        _testDBLoader.GivenAProductInDb(_product);

        var retrievedOrder = _sqLiteProductsRepository.GetById(_product.Id).Result;

        retrievedOrder.Should().BeEquivalentTo(_productDto);
    }

    [Test]
    public void InsertNewProductWhileRequested() {
        _sqLiteProductsRepository.Create(_product);

        var retrievedOrder = _sqLiteProductsRepository.GetById(ProductDefaultValues.ComputerMonitorId).Result;

        retrievedOrder.Should().BeEquivalentTo(_productDto);
    }
}