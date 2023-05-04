using MediatR;
using OrdersWebApi;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Queries;
using OrdersWebApi.Orders.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(OrdersWebApi.Program).Assembly));
builder.Services.AddSingleton<IClock, SystemClock>();
builder.Services.AddSingleton<IOrderRepository, InMemoryOrdersRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

namespace OrdersWebApi
{
    public partial class Program
    {
    }
}