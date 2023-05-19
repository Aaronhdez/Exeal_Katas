namespace OrdersWebApi.Orders.Commands.CreateOrder;

#pragma warning disable CS8602
public record CreateOrderDto(string Id, string Customer, string Address, string[] Products);