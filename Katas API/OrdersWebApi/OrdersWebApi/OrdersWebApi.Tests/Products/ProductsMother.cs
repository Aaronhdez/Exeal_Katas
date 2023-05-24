using Newtonsoft.Json;
using OrdersWebApi.Orders.Commands.AddProductsToOrder;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Commands;
using OrdersWebApi.Products.Controllers.Requests;
using OrdersWebApi.Products.Queries;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.TestUtils;

namespace OrdersWebApi.Tests.Products;

public static class ProductsMother {
    //REQUESTS
    public static string ComputerMonitorCreationRequest() {
        return JsonConvert.SerializeObject(new CreateProductRequest(
            ProductDefaultValues.ComputerMonitor.Type,
            ProductDefaultValues.ComputerMonitor.Name,
            ProductDefaultValues.ComputerMonitor.Description,
            ProductDefaultValues.ComputerMonitor.Manufacturer,
            ProductDefaultValues.ComputerMonitor.ManufacturerReference,
            ProductDefaultValues.ComputerMonitor.Value));
    }

    public static string KeyboardCreationRequest() {
        return JsonConvert.SerializeObject(new CreateProductRequest(
            ProductDefaultValues.Keyboard.Type,
            ProductDefaultValues.Keyboard.Name,
            ProductDefaultValues.Keyboard.Description,
            ProductDefaultValues.Keyboard.Manufacturer,
            ProductDefaultValues.Keyboard.ManufacturerReference,
            ProductDefaultValues.Keyboard.Value));
    }

    public static string MouseCreationRequest() {
        return JsonConvert.SerializeObject(new CreateProductRequest(
            ProductDefaultValues.Mouse.Type,
            ProductDefaultValues.Mouse.Name,
            ProductDefaultValues.Mouse.Description,
            ProductDefaultValues.Mouse.Manufacturer,
            ProductDefaultValues.Mouse.ManufacturerReference,
            ProductDefaultValues.Mouse.Value));
    }

    //DTOs

    public static AddProductsDto AddAProductDto() {
        return new AddProductsDto(OrderDefaultValues.OrderId, new[] {
            ProductDefaultValues.ComputerMonitorId
        });
    }

    public static AddProductsDto AddTwoProductsDto() {
        return new AddProductsDto(OrderDefaultValues.OrderId, new[] {
            ProductDefaultValues.ComputerMonitorId,
            ProductDefaultValues.ComputerMonitorId
        });
    }

    public static ProductReadDto TestExpectedProductReadDto() {
        return new ProductReadDto {
            Id = "An Id",
            ProductReference = "MON000001",
            Name = "A Name",
            Description = "A Description",
            Manufacturer = "A Manufacturer",
            ManufacturerReference = "A Manufacturer Reference",
            Value = 0
        };
    }

    public static ProductReadDto TestProductReadDto() {
        return new ProductReadDto {
            Id = "An Id",
            ProductReference = "MON000001",
            Name = "A Name",
            Description = "A Description",
            Manufacturer = "A Manufacturer",
            ManufacturerReference = "A Manufacturer Reference",
            Value = 0
        };
    }

    public static CreateProductDto TestCreateProductDto(string tag) {
        return new CreateProductDto(
            "An Id",
            tag,
            "A Name",
            "A Description",
            "A Manufacturer",
            "A Manufacturer Reference",
            0);
    }

    //MODELS
    public static Product ATestProduct(string productId) {
        return new Product(
            productId,
            "MON000001",
            "MON",
            "A Name",
            "A Description",
            "A Manufacturer",
            "A Manufacturer Reference",
            0);
    }
}