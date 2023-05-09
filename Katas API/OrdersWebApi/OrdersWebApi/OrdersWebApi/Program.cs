using System.Data.SQLite;
using Dapper;
using OrdersWebApi;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

CreateDatabase();

builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssembly(typeof(OrdersWebApi.Program).Assembly));
builder.Services.AddSingleton<IClock, SystemClock>();
builder.Services.AddScoped(_ => new SQLiteConnection("Data Source=./Orders.db"));
builder.Services.AddTransient<IOrderRepository, SQLiteOrdersRepository>();
builder.Services.AddTransient<IProductsRepository, SQLiteProductsRepository>();

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
                Customer VARCHAR(100),
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

    sqLiteConnection.Close();
    sqLiteConnection.Dispose();
}

namespace OrdersWebApi {
    public class Program { }
}