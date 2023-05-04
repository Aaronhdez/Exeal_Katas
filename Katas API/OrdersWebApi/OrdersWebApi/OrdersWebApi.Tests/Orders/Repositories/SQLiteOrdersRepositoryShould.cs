using System.Data.SQLite;
using Dapper;
using FluentAssertions;
using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests.Orders.Repositories;

public class SQLiteOrdersRepositoryShould
{
    private SQLiteOrdersRepository _inMemoryOrdersRepository;
    private SQLiteConnection _sqLiteConnection;

    [SetUp]
    public async Task SetUp()
    {
        _sqLiteConnection = new SQLiteConnection("Data Source=:memory:");
        _sqLiteConnection.Open();
        await _sqLiteConnection.ExecuteAsync(
            @"Create Table if not exists Orders(
                ID VARCHAR(100) UNIQUE,
                CreationDate VARCHAR(100) NOT NULL,
                Customer VARCHAR(100) NOT NULL,
                Address VARCHAR(100) NOT NULL)");
        _inMemoryOrdersRepository = new SQLiteOrdersRepository(_sqLiteConnection);
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
        var expected = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products(new List<Product>()));
        _sqLiteConnection.ExecuteAsync(
            $"INSERT INTO " +
            $"Orders(ID, CreationDate, Customer, Address) " +
            $"VALUES('{expected.Id}','{expected.CreationDate}','{expected.Customer}','{expected.Address}')");

        var retrievedOrder = _inMemoryOrdersRepository.GetById("ORD123456").Result;
        
        retrievedOrder.Should().Be(expected);
    }
    

    [Test]
    public void InsertNewOrderWithoutProductsWhileRequested()
    {
        var expectedOrder = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products(new List<Product>()));
    
        _inMemoryOrdersRepository.Create(expectedOrder);
    
        var retrievedOrder = _inMemoryOrdersRepository.GetById("ORD123456").Result;
        retrievedOrder.Should().Be(expectedOrder);
    }
}

public class SQLiteOrdersRepository : IOrderRepository
{
    private readonly SQLiteConnection _connection;

    public SQLiteOrdersRepository(SQLiteConnection connection)
    {
        _connection = connection;
    }

    public Task Create(Order order)
    {
        return _connection.ExecuteAsync(
            $"INSERT INTO " +
            $"Orders(ID, CreationDate, Customer, Address) " +
            $"VALUES('{order.Id}','{order.CreationDate}','{order.Customer}','{order.Address}')");
    }

    public Task<Order> GetById(string id)
    {
         var queryResult = _connection.QueryFirstOrDefaultAsync<dynamic?>($"SELECT * FROM Orders WHERE ID = '{id}'").Result;
         var retrievedOrder = new Order(queryResult.ID, queryResult.CreationDate, queryResult.Customer, queryResult.Address, new Products(new List<Product>()));
         return Task.FromResult(retrievedOrder);
    }

    public Task Update(Order orderModel)
    {
        throw new NotImplementedException();
    }
}