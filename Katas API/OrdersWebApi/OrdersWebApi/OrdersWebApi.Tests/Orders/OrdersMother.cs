using Newtonsoft.Json;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.CreateOrder;
using OrdersWebApi.Orders.Controllers.Requests;
using OrdersWebApi.Orders.Queries;
using OrdersWebApi.Products;
using OrdersWebApi.Tests.Products;
using OrdersWebApi.Users;

namespace OrdersWebApi.Tests.Orders;

public static class OrdersMother {
    //REQUESTS
    public static string GivenAnOrderRequestWithProductsAssigned(string[] products) {
        return JsonConvert.SerializeObject(new CreateOrderRequest(
            UserDefaultValues.CustomerName,
            UserDefaultValues.CustomerAddress,
            products
        ));
    }

    public static string GivenAnOrderRequestWithAProductId(string productId) {
        return JsonConvert.SerializeObject(new CreateOrderRequest(
            UserDefaultValues.CustomerName,
            UserDefaultValues.CustomerAddress,
            new[] {
                productId
            }
        ), Formatting.Indented);
    }

    //DTOS

    public static CreateOrderDto ACreatOrderDtoWithoutProducts() {
        return new CreateOrderDto(
            OrderDefaultValues.OrderId,
            UserDefaultValues.CustomerName,
            UserDefaultValues.CustomerAddress,
            Array.Empty<string>());
    }

    public static CreateOrderDto ACreateOrderDtoWithProducts() {
        return new CreateOrderDto(
            OrderDefaultValues.OrderId,
            UserDefaultValues.CustomerName,
            UserDefaultValues.CustomerAddress,
            new[] {
                ProductDefaultValues.ComputerMonitorId
            });
    }

    public static ReadOrderDto TestOrderReadDto() {
        return new ReadOrderDto(
            OrderDefaultValues.OrderId,
            TestDefaultValues.CreationDate,
            UserDefaultValues.CustomerName,
            UserDefaultValues.CustomerAddress,
            new List<Product>());
    }

    //MODELS

    public static Order ATestOrderWithoutProducts() {
        return new Order(OrderDefaultValues.OrderId, TestDefaultValues.CreationDate, new User(UserDefaultValues.UserId, UserDefaultValues.CustomerName, UserDefaultValues.CustomerAddress), new List<Product>());
    }

    public static Order ATestOrderWithAProduct() {
        return new Order(OrderDefaultValues.OrderId, TestDefaultValues.CreationDate, new User(UserDefaultValues.UserId, UserDefaultValues.CustomerName, UserDefaultValues.CustomerAddress), new List<Product> {
            ProductDefaultValues.ComputerMonitor
        });
    }

    public static Order AnUpdatedTestOrderWithTwoProducts() {
        return new Order(OrderDefaultValues.OrderId, TestDefaultValues.CreationDate, new User(UserDefaultValues.UserId, UserDefaultValues.CustomerName, UserDefaultValues.CustomerAddress), new List<Product> {
            ProductDefaultValues.ComputerMonitor,
            ProductDefaultValues.ComputerMonitor
        });
    }
}