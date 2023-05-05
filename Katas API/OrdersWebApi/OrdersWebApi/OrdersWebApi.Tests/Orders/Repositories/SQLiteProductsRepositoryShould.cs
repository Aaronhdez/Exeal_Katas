using System.Data.SQLite;
using Dapper;
using FluentAssertions;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Repositories;

namespace OrdersWebApi.Tests.Orders.Repositories;

public class SQLiteProductsRepositoryShould
{
    private SQLiteProductsRepository _sqLiteProductsRepository;
    private SQLiteConnection _sqLiteConnection;
    private Product _product;

    [SetUp]
    public async Task SetUp()
    {
        _product = new Product("PROD000001", "Computer", 150);
        _sqLiteConnection = new SQLiteConnection("Data Source=:memory:");
        _sqLiteConnection.Open();
        await LoadDatabaseInstance();
        _sqLiteProductsRepository = new SQLiteProductsRepository(_sqLiteConnection);
    }
    
    [TearDown]
    public void Teardown()
    {
        _sqLiteConnection.Close();
        _sqLiteConnection.Dispose();
    }
    
    [Test]
    public void RetrieveAnOrderWithoutProductsWhileRequested()
    {
        _sqLiteConnection.ExecuteAsync(
            $"INSERT INTO " +
            $"Products(ID, [Name], [Value]) " +
            $"VALUES('{_product.Id}', '{_product.Name}','{_product.Value}')");

        var retrievedOrder = _sqLiteProductsRepository.GetById(_product.Id).Result;

        retrievedOrder.Should().Be(_product);
    }
    
    private async Task LoadDatabaseInstance()
    {
        await _sqLiteConnection.ExecuteAsync(
            @"Create Table if not exists Products(
                ID VARCHAR(100) UNIQUE,
                Name VARCHAR(100) NOT NULL,
                Value INTEGER NOT NULL)");
    }
}

public class SQLiteProductsRepository
{
    private readonly SQLiteConnection _sqLiteConnection;

    public SQLiteProductsRepository(SQLiteConnection sqLiteConnection)
    {
        _sqLiteConnection = sqLiteConnection;
    }

    public Task<Product> GetById(string productId)
    {
        return _sqLiteConnection.QueryFirstOrDefaultAsync<Product>($"SELECT * FROM Products WHERE ID = '{productId}'");
    }   
}