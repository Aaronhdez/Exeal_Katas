using System.Data.SQLite;
using Dapper;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Repositories;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Repositories;
using OrdersWebApi.Users;
using OrdersWebApi.Users.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ResetDatabase();
CreateDatabase();

builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssembly(typeof(OrdersWebApi.Program).Assembly));
builder.Services.AddSingleton<IClock, SystemClock>();
builder.Services.AddSingleton<IGuidGenerator, GuidGenerator>();
builder.Services.AddSingleton<ProductReferenceGenerator>();
//builder.Services.AddScoped(_ => new SQLiteConnection("Data Source=./Orders.db"));
builder.Services.AddSingleton<IOrderRepository, InMemoryOrdersRepository>();
builder.Services.AddSingleton<IProductsRepository, InMemoryProductsRepository>();
builder.Services.AddSingleton<IUsersRepository, InMemoryUsersRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void CreateDatabase() {
    var sqLiteConnection = new SQLiteConnection("Data Source=./Orders.db");
    sqLiteConnection.ExecuteAsync(
        @"Create Table if not exists Orders(
                ID VARCHAR(100),
                CreationDate VARCHAR(100),
                Name VARCHAR(100),
                Address VARCHAR(100))");

    sqLiteConnection.ExecuteAsync(
        @"Create Table if not exists Products(
                ID VARCHAR(100),
                Name VARCHAR(100),
                Value INTEGER)");

    sqLiteConnection.ExecuteAsync(
        @"Create Table if not exists OrdersProducts(
                OrderID VARCHAR(100),
                ProductID VARCHAR(100))");

    sqLiteConnection.ExecuteAsync(
        "INSERT INTO " +
        "Products(ID, Name, Value) " +
        "VALUES('1c93009e-101f-4f4b-bf6b-a1c1d486dd03','Computer Monitor',100)");
    sqLiteConnection.ExecuteAsync(
        "INSERT INTO " +
        "Products(ID, Name, Value) " +
        "VALUES('08083948-2d0d-4808-b0a8-fbd9d6ad4388','Keyboard',20)");
    sqLiteConnection.ExecuteAsync(
        "INSERT INTO " +
        "Products(ID, Name, Value) " +
        "VALUES('5e0b445b-1eeb-41c0-86cb-dd097c27d41e','Mouse',15)");

    sqLiteConnection.Close();
    sqLiteConnection.Dispose();
}

void ResetDatabase() {
    var sqLiteConnection = new SQLiteConnection("Data Source=./Orders.db");
    sqLiteConnection.ExecuteAsync("DELETE FROM Orders");
    sqLiteConnection.ExecuteAsync("DELETE FROM Products");
    sqLiteConnection.ExecuteAsync("DELETE FROM OrdersProducts");

    sqLiteConnection.Close();
    sqLiteConnection.Dispose();
}

namespace OrdersWebApi {
    public class Program { }
}