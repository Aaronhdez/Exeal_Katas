using Newtonsoft.Json;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Controllers.Requests;
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
    
    
    //MODELS
    
    public static Order ATestOrder() {
        return new Order(
            TestDefaultValues.OrderId, 
            TestDefaultValues.CreationDate, 
            TestDefaultValues.CustomerName, 
            TestDefaultValues.CustomerAddress,
            new List<Product> {
                TestDefaultValues.ComputerMonitor
            });
    }

    public static Order AnUpdatedTestOrder() {
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