using System.Data.SQLite;
using FluentAssertions;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Repositories;

namespace OrdersWebApi.Tests.Orders.Repositories;

public class SQLiteOrdersRepositoryShould {
    private Item _defaultItem;
    private Order _order;
    private SQLiteConnection _sqLiteConnection;
    private SQLiteOrdersRepository _sqLiteOrdersRepository;
    private TestDBLoader _testDBLoader;

    [SetUp]
    public async Task SetUp() {
        _defaultItem = new Item("PROD000001", "Computer", 750);
        _order = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new List<Item>());
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

        var retrievedOrder = _sqLiteOrdersRepository.GetById("ORD123456").Result;

        retrievedOrder.Should().Be(_order);
    }

    [Test]
    public void InsertNewOrderWithoutProductsWhileRequested() {
        _sqLiteOrdersRepository.Create(_order);

        var retrievedOrder = _sqLiteOrdersRepository.GetById("ORD123456").Result;
        
        retrievedOrder.Should().Be(_order);
    }

    [Test]
    public void RetrieveAnListOfProductsForAnOrderWhileRequested() {
        _order.Products = new List<Item> { _defaultItem };
        _testDBLoader.GivenAnOrderInDb(_order);
        _testDBLoader.GivenAProductInDb(_defaultItem);
        _testDBLoader.GivenAProductAssignedToAnOrderInDb("PROD000001", _order.Id);

        var retrievedOrder = _sqLiteOrdersRepository.GetById("ORD123456").Result;

        retrievedOrder.Should().Be(_order);
    }

    [Test]
    public void AddANewProductToAnExistentOrderWhileRequested() {
        var product = new Item("PROD000003", "Computer_3", 750);
        _order.Products = new List<Item> { _defaultItem, product };
        _testDBLoader.GivenAnOrderInDb(_order);
        _testDBLoader.GivenAProductInDb(product);
        _testDBLoader.GivenAProductInDb(_defaultItem);
        _testDBLoader.GivenAProductAssignedToAnOrderInDb("PROD000001", _order.Id);

        _sqLiteOrdersRepository.Update(_order);
        var retrievedOrder = _sqLiteOrdersRepository.GetById("ORD123456").Result; 
        
        retrievedOrder.Should().Be(_order);
    }
}