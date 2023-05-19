using Newtonsoft.Json;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.CreateOrder;
using OrdersWebApi.Orders.Controllers.Requests;
using OrdersWebApi.Orders.Queries;
using OrdersWebApi.Products;

namespace OrdersWebApi.Tests.Orders;

public static class OrdersMother {
    
    //REQUESTS
    public static string GivenAnOrderRequestWithProductsAssigned(string[] products) {
        return JsonConvert.SerializeObject(new CreateOrderRequest (
            TestDefaultValues.CustomerName,
            TestDefaultValues.CustomerAddress,
            products
        ));
    }

    public static string GivenAnOrderRequestWithAProductId(string productId) {
        return JsonConvert.SerializeObject(new CreateOrderRequest(
            TestDefaultValues.CustomerName,
            TestDefaultValues.CustomerAddress,
            new [] {
                productId
            }
        ), Formatting.Indented);
    }
    
    //DTOS

    public static CreateOrderDto ACreatOrderDtoWithoutProducts() {
        return new CreateOrderDto(
            TestDefaultValues.OrderId, 
            TestDefaultValues.CustomerName, 
            TestDefaultValues.CustomerAddress, 
            Array.Empty<string>());
    }

    public static CreateOrderDto ACreateOrderDtoWithProducts() {
        return new CreateOrderDto(
            TestDefaultValues.OrderId,
            TestDefaultValues.CustomerName,
            TestDefaultValues.CustomerAddress,
            new[] {
                TestDefaultValues.ComputerMonitorId
            });
    }

    public static ReadOrderDto TestOrderReadDto() {
        return new ReadOrderDto(
            TestDefaultValues.OrderId,
            TestDefaultValues.CreationDate,
            TestDefaultValues.CustomerName,
            TestDefaultValues.CustomerAddress,
            new List<Product>());
    }

    //MODELS
    
    public static Order ATestOrderWithoutProducts() {
        return new Order(
            TestDefaultValues.OrderId,
            TestDefaultValues.CreationDate,
            TestDefaultValues.CustomerName,
            TestDefaultValues.CustomerAddress,
            new List<Product>());
    }

    public static Order ATestOrderWithAProduct() {
        return new Order(
            TestDefaultValues.OrderId, 
            TestDefaultValues.CreationDate, 
            TestDefaultValues.CustomerName, 
            TestDefaultValues.CustomerAddress,
            new List<Product> {
                TestDefaultValues.ComputerMonitor
            });
    }

    public static Order AnUpdatedTestOrderWithTwoProducts() {
        return new Order(
            TestDefaultValues.OrderId, 
            TestDefaultValues.CreationDate, 
            TestDefaultValues.CustomerName, 
            TestDefaultValues.CustomerAddress,
            new List<Product> {
                TestDefaultValues.ComputerMonitor,
                TestDefaultValues.ComputerMonitor
            });
    }
}