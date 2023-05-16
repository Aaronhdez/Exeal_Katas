using System.Data.SQLite;
using FluentAssertions;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Repositories;

namespace OrdersWebApi.Tests.Orders.Repositories;

public class SQLiteOrdersRepositoryShould {
    private Product _defaultProduct;
    private Order _order;
    private SQLiteConnection _sqLiteConnection;
    private SQLiteOrdersRepository _sqLiteOrdersRepository;
    private TestDBLoader _testDBLoader;

    [SetUp]
    public async Task SetUp() {
        _defaultProduct = TestDefaultValues.ComputerMonitor;
        _order = new Order(TestDefaultValues.OrderId, TestDefaultValues.CreationDate, TestDefaultValues.CustomerName, TestDefaultValues.CustomerAddress,
            new List<Product>());
        _sqLiteConnection = new SQLiteConnection("Data Source=:memory:");
        _testDBLoader = new TestDBLoader(_sqLiteConnection);
        _sqLiteOrdersRepository = new SQLiteOrdersRepository(_sqLiteConnection);
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
    public void RetrieveAnOrderWithoutProductsWhileRequested() {
        _testDBLoader.GivenAnOrderInDb(_order);

        var retrievedOrder = _sqLiteOrdersRepository.GetById(TestDefaultValues.OrderId).Result;

        retrievedOrder.Should().Be(_order);
    }

    [Test]
    public void InsertNewOrderWithoutProductsWhileRequested() {
        _sqLiteOrdersRepository.Create(_order);

        var retrievedOrder = _sqLiteOrdersRepository.GetById(TestDefaultValues.OrderId).Result;

        retrievedOrder.Should().Be(_order);
    }

    [Test]
    public void RetrieveAnListOfProductsForAnOrderWhileRequested() {
        _order.Products = new List<Product> { _defaultProduct };
        _testDBLoader.GivenAnOrderInDb(_order);
        _testDBLoader.GivenAProductInDb(_defaultProduct);
        _testDBLoader.GivenAProductAssignedToAnOrderInDb(TestDefaultValues.ComputerMonitorId, _order.Id);

        var retrievedOrder = _sqLiteOrdersRepository.GetById(TestDefaultValues.OrderId).Result;

        retrievedOrder.Should().Be(_order);
    }

    [Test]
    public void AddANewProductToAnExistentOrderWhileRequested() {
        var product = TestDefaultValues.Keyboard;
        _order.Products = new List<Product> { _defaultProduct, product };
        _testDBLoader.GivenAnOrderInDb(_order);
        _testDBLoader.GivenAProductInDb(product);
        _testDBLoader.GivenAProductInDb(_defaultProduct);
        _testDBLoader.GivenAProductAssignedToAnOrderInDb(TestDefaultValues.ComputerMonitorId, _order.Id);

        _sqLiteOrdersRepository.Update(_order);
        var retrievedOrder = _sqLiteOrdersRepository.GetById(TestDefaultValues.OrderId).Result;

        retrievedOrder.Should().Be(_order);
    }
}