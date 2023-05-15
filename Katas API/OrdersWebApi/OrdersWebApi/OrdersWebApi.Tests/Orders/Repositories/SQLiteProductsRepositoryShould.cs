using System.Data.SQLite;
using FluentAssertions;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Repositories;

namespace OrdersWebApi.Tests.Orders.Repositories;

public class SQLiteProductsRepositoryShould {
    private Item _item;
    private SQLiteConnection _sqLiteConnection;
    private SQLiteProductsRepository _sqLiteProductsRepository;
    private TestDBLoader _testDBLoader;

    [SetUp]
    public async Task SetUp() {
        _item = TestDefaultValues.ComputerMonitor;
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
        _testDBLoader.GivenAProductInDb(_item);

        var retrievedOrder = _sqLiteProductsRepository.GetById(_item.Id).Result;

        retrievedOrder.Should().Be(_item);
    }

    [Test]
    public void InsertNewProductWhileRequested() {
        _sqLiteProductsRepository.Create(_item);

        var retrievedOrder = _sqLiteProductsRepository.GetById(TestDefaultValues.ComputerMonitorId).Result;

        retrievedOrder.Should().Be(_item);
    }
}