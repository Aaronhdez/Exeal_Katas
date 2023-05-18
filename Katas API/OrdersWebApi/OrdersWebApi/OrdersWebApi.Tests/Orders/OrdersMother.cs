using Newtonsoft.Json;
using OrdersWebApi.Orders.Controllers.Requests;

namespace OrdersWebApi.Tests.Orders;

public static class OrdersMother {
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
}