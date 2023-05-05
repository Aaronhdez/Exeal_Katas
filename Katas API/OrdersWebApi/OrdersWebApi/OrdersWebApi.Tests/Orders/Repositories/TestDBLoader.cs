using System.Data;
using System.Data.SQLite;
using Dapper;
using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests.Orders.Repositories;

public class TestDBLoader {
    
    private SQLiteConnection _sqLiteConnection;

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
            $"INSERT INTO Orders(ID, CreationDate, Customer, Address) VALUES('{expectedOrder.Id}','{expectedOrder.CreationDate}','{expectedOrder.Customer}','{expectedOrder.Address}')");
    }

    public async Task LoadDatabase(IDbConnection sqLiteConnection) {
        await sqLiteConnection.ExecuteAsync(
            $@"Create Table if not exists Orders(
                ID VARCHAR(100) UNIQUE,
                CreationDate VARCHAR(100) NOT NULL,
                Customer VARCHAR(100) NOT NULL,
                Address VARCHAR(100) NOT NULL)");

        await sqLiteConnection.ExecuteAsync(
            @"Create Table if not exists Products(
                ID VARCHAR(100) UNIQUE,
                Name VARCHAR(100) NOT NULL,
                Value INTEGER NOT NULL)");

        await sqLiteConnection.ExecuteAsync(
            @"Create Table if not exists OrdersProducts(
                OrderID VARCHAR(100) NOT NULL,
                ProductID VARCHAR(100) NOT NULL)");
    }
}