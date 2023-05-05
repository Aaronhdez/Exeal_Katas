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
    public void RetrieveAProductWhileRequested()
    {
        _sqLiteConnection.ExecuteAsync(
            $"INSERT INTO " +
            $"Products(ID, [Name], [Value]) " +
            $"VALUES('{_product.Id}', '{_product.Name}','{_product.Value}')");

        var retrievedOrder = _sqLiteProductsRepository.GetById(_product.Id).Result;

        retrievedOrder.Should().Be(_product);
    }
    
    [Test]
    public void InsertNewProductWhileRequested()
    {
        _sqLiteProductsRepository.Create(_product);

        var retrievedOrder = _sqLiteProductsRepository.GetById("PROD000001").Result;
        
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
    private readonly SQLiteConnection _connection;

    public SQLiteProductsRepository(SQLiteConnection connection)
    {
        _connection = connection;
    }

    public Task<Product> GetById(string productId)
    {
        return _connection.QueryFirstOrDefaultAsync<Product>($"SELECT * FROM Products WHERE ID = '{productId}'");
    }

    public Task Create(Product product)
    {
        return _connection.ExecuteAsync(
            $"INSERT INTO " +
            $"Products(ID, Name, Value) " +
            $"VALUES('{product.Id}','{product.Name}',{product.Value})");
    }
}