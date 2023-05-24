using Newtonsoft.Json;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Commands.CreateOrder;
using OrdersWebApi.Orders.Controllers.Requests;
using OrdersWebApi.Orders.Queries;
using OrdersWebApi.Products;
using OrdersWebApi.Tests.Products;
using OrdersWebApi.Tests.Users;
using OrdersWebApi.TestUtils;
using OrdersWebApi.TestUtils.Orders;
using OrdersWebApi.TestUtils.Products;
using OrdersWebApi.TestUtils.Users;

namespace OrdersWebApi.Tests.Orders;

public static class OrdersMother {
    //REQUESTS
    public static string GivenACreateOrderRequest(string vendorId, string customerId, string[] products) {
        return JsonConvert.SerializeObject(new CreateOrderRequest(
            vendorId,
            customerId,
            products
        ));
    }

    //DTOS

    public static CreateOrderDto ACreatOrderDtoWithoutProducts() {
        return new CreateOrderDto(
            OrderDefaultValues.OrderId,
            UserDefaultValues.VendorId,
            UserDefaultValues.CustomerId,
            Array.Empty<string>());
    }

    public static CreateOrderDto ACreateOrderDtoWithProducts() {
        return new CreateOrderDto(
            OrderDefaultValues.OrderId,
            UserDefaultValues.VendorId,
            UserDefaultValues.CustomerId,
            new[] {
                ProductDefaultValues.ComputerMonitorId
            });
    }

    public static ReadOrderDto TestOrderReadDto() {
        return new ReadOrderDto(
            OrderDefaultValues.OrderId,
            TestDefaultValues.CreationDate,
            UsersMother.TestReadVendorDto(),
            UsersMother.TestReadCustomerDto(),
            new List<Product>());
    }

    //MODELS

    public static Order ATestOrderWithoutProducts() {
        return new Order(OrderDefaultValues.OrderId, TestDefaultValues.CreationDate, UsersMother.TestVendor(),UsersMother.TestUser(), new List<Product>());
    }

    public static Order ATestOrderWithAProduct() {
        return new Order(OrderDefaultValues.OrderId, TestDefaultValues.CreationDate, UsersMother.TestVendor(),UsersMother.TestUser(), new List<Product> {
            ProductsMother.ComputerMonitor()
        });
    }

    public static Order AnUpdatedTestOrderWithTwoProducts() {
        var computerMonitor = ProductsMother.ComputerMonitor();
        return new Order(OrderDefaultValues.OrderId, TestDefaultValues.CreationDate, UsersMother.TestVendor(),UsersMother.TestUser(), new List<Product> {
            computerMonitor,
            computerMonitor
        });
    }
}