using System.Data;
using System.Data.SQLite;
using Dapper;
using OrdersWebApi.Orders;
using OrdersWebApi.Products;

namespace OrdersWebApi.Tests.Orders.Repositories;

public class TestDBLoader {
    private readonly SQLiteConnection _sqLiteConnection;

    public TestDBLoader(SQLiteConnection sqLiteConnection) {
        _sqLiteConnection = sqLiteConnection;
    }

    public void GivenAProductAssignedToAnOrderInDb(string productId, string expectedOrderId) {
        _sqLiteConnection.ExecuteAsync(
            $"INSERT INTO OrdersProducts(OrderID, ProductID) VALUES('{expectedOrderId}','{productId}')");
    }

    public void GivenAProductInDb(Product product) {
        _sqLiteConnection.ExecuteAsync(
            $"INSERT INTO Products(ID, [Name], [Value]) VALUES('{product.Id}', '{product.Name}','{product.Value}')");
    }

    public void GivenAnOrderInDb(Order expectedOrder) {
        _sqLiteConnection.ExecuteAsync(
            $"INSERT INTO Orders(ID, CreationDate, Name, Address) VALUES('{expectedOrder.Id}','{expectedOrder.CreationDate}','{expectedOrder.Customer}','{expectedOrder.Address}')");
    }

    public async Task LoadDatabase(IDbConnection sqLiteConnection) {
        await sqLiteConnection.ExecuteAsync(
            @"Create Table if not exists Orders(
                ID VARCHAR(100),
                CreationDate VARCHAR(100),
                Name VARCHAR(100),
                Address VARCHAR(100))");

        await sqLiteConnection.ExecuteAsync(
            @"Create Table if not exists Products(
                ID VARCHAR(100),
                Name VARCHAR(100),
                Value INTEGER)");

        await sqLiteConnection.ExecuteAsync(
            @"Create Table if not exists OrdersProducts(
                OrderID VARCHAR(100),
                ProductID VARCHAR(100))");
    }


    public async Task ClearDatabase(IDbConnection sqLiteConnection) {
        await sqLiteConnection.ExecuteAsync(@"
            Drop table OrdersProducts;
            Drop table Products;
            Drop table Orders;");
    }
}