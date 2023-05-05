using System.Data.SQLite;
using Dapper;
using FluentAssertions;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Repositories;

namespace OrdersWebApi.Tests.Orders.Repositories;

public class SQLiteProductsRepositoryShould {
    private Product _product;
    private SQLiteConnection _sqLiteConnection;
    private SQLiteProductsRepository _sqLiteProductsRepository;
    private TestDBLoader _testDBLoader;

    [SetUp]
    public async Task SetUp() {
        _product = new Product("PROD000001", "Computer", 150);
        _sqLiteConnection = new SQLiteConnection("Data Source=:memory:");
        _testDBLoader = new TestDBLoader(_sqLiteConnection);
        _sqLiteProductsRepository = new SQLiteProductsRepository(_sqLiteConnection);
        _sqLiteConnection.Open();
        await _testDBLoader.LoadDatabase(_sqLiteConnection);
    }

    [TearDown]
    public void Teardown() {
        _sqLiteConnection.Close();
        _sqLiteConnection.Dispose();
    }

    [Test]
    public void RetrieveAProductWhileRequested() {
        _testDBLoader.GivenAProductInDb(_product);

        var retrievedOrder = _sqLiteProductsRepository.GetById(_product.Id).Result;

        retrievedOrder.Should().Be(_product);
    }

    [Test]
    public void InsertNewProductWhileRequested() {
        _sqLiteProductsRepository.Create(_product);

        var retrievedOrder = _sqLiteProductsRepository.GetById("PROD000001").Result;

        retrievedOrder.Should().Be(_product);
    }
}