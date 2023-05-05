using System.Data.SQLite;
using Dapper;
using FluentAssertions;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Repositories;

namespace OrdersWebApi.Tests.Orders.Repositories;

public class SQLiteOrdersRepositoryShould
{
    private SQLiteOrdersRepository _sqLiteOrdersRepository;
    private SQLiteConnection _sqLiteConnection;
    private Order _order;
    private Product _defaultProduct;

    [SetUp]
    public async Task SetUp()
    {
        _defaultProduct = new Product("PROD000001","Computer", 750);
        _order = new Order("ORD123456", "24/04/2023", "John Doe", "A Simple Street, 123",
            new Products(new List<Product>()));
        _sqLiteConnection = new SQLiteConnection("Data Source=:memory:");
        _sqLiteConnection.Open();
        await LoadDatabaseInstance();
        _sqLiteOrdersRepository = new SQLiteOrdersRepository(_sqLiteConnection);
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
        GivenAnOrderInDB(_order);

        var retrievedOrder = _sqLiteOrdersRepository.GetById("ORD123456").Result;

        retrievedOrder.Should().Be(_order);
    }


    [Test]
    public void InsertNewOrderWithoutProductsWhileRequested()
    {
        _sqLiteOrdersRepository.Create(_order);

        var retrievedOrder = _sqLiteOrdersRepository.GetById("ORD123456").Result;
        retrievedOrder.Should().Be(_order);
    }

    [Test]
    public void RetrieveAnListOfProductsForAnOrderWhileRequested()
    {
        _order.Products = new Products(new List<Product> { _defaultProduct });
        GivenAnOrderInDB(_order);
        GivenAProductInDB(_defaultProduct);
        GivenAProductAssignedToAnOrderInDB("PROD000001", _order.Id);
        
        var retrievedOrder = _sqLiteOrdersRepository.GetById("ORD123456").Result;
        
        retrievedOrder.Should().Be(_order);
    }
    
    [Test]
    public void AddANewProductToAnExistentOrderWhileRequested()
    {
        var product = new Product("PROD000003","Computer_3", 750);
        _order.Products = new Products(new List<Product> { _defaultProduct, product });
        GivenAnOrderInDB(_order);
        GivenAProductInDB(product);
        GivenAProductInDB(_defaultProduct);
        GivenAProductAssignedToAnOrderInDB("PROD000001", _order.Id);
        
        _sqLiteOrdersRepository.Update(_order);
        
        var retrievedOrder = _sqLiteOrdersRepository.GetById("ORD123456").Result;
        retrievedOrder.Should().Be(_order);
    }

    private void GivenAProductAssignedToAnOrderInDB(string productId, string expectedOrderId)
    {
        _sqLiteConnection.ExecuteAsync(
            $"INSERT INTO " +
            $"OrdersProducts(OrderID, ProductID) " +
            $"VALUES('{expectedOrderId}','{productId}')");
    }

    private void GivenAProductInDB(Product product)
    {
        _sqLiteConnection.ExecuteAsync(
            $"INSERT INTO " +
            $"Products(ID, [Name], [Value]) " +
            $"VALUES('{product.Id}', '{product.Name}','{product.Value}')");
    }

    private void GivenAnOrderInDB(Order expectedOrder)
    {
        _sqLiteConnection.ExecuteAsync(
            $"INSERT INTO " +
            $"Orders(ID, CreationDate, Customer, Address) " +
            $"VALUES('{expectedOrder.Id}','{expectedOrder.CreationDate}','{expectedOrder.Customer}','{expectedOrder.Address}')");
    }

    private async Task LoadDatabaseInstance()
    {
        await _sqLiteConnection.ExecuteAsync(
            @"Create Table if not exists Orders(
                ID VARCHAR(100) UNIQUE,
                CreationDate VARCHAR(100) NOT NULL,
                Customer VARCHAR(100) NOT NULL,
                Address VARCHAR(100) NOT NULL)");

        await _sqLiteConnection.ExecuteAsync(
            @"Create Table if not exists Products(
                ID VARCHAR(100) UNIQUE,
                Name VARCHAR(100) NOT NULL,
                Value INTEGER NOT NULL)");

        await _sqLiteConnection.ExecuteAsync(
            @"Create Table if not exists OrdersProducts(
                OrderID VARCHAR(100) NOT NULL,
                ProductID VARCHAR(100) NOT NULL)");
    }

}