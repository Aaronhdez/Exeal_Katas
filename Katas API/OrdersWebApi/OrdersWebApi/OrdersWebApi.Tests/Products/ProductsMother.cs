using Newtonsoft.Json;
using OrdersWebApi.Orders.Commands.AddProductsToOrder;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Commands;
using OrdersWebApi.Products.Controllers.Requests;
using OrdersWebApi.Products.Queries;
using OrdersWebApi.Tests.Orders;
using OrdersWebApi.TestUtils;
using OrdersWebApi.TestUtils.Orders;
using OrdersWebApi.TestUtils.Products;

namespace OrdersWebApi.Tests.Products;

public static class ProductsMother {

    //REQUESTS
    public static string ComputerMonitorCreationRequest() {
        var computerMonitor = ProductsMother.ComputerMonitor();
        return JsonConvert.SerializeObject(new CreateProductRequest(
            computerMonitor.Type,
            computerMonitor.Name,
            computerMonitor.Description,
            computerMonitor.Manufacturer,
            computerMonitor.ManufacturerReference,
            computerMonitor.Value));
    }

    public static string KeyboardCreationRequest() {
        var keyboard = ProductsMother.Keyboard();
        return JsonConvert.SerializeObject(new CreateProductRequest(
            keyboard.Type,
            keyboard.Name,
            keyboard.Description,
            keyboard.Manufacturer,
            keyboard.ManufacturerReference,
            keyboard.Value));
    }

    public static string MouseCreationRequest() {
        var mouse = ProductsMother.Mouse();
        return JsonConvert.SerializeObject(new CreateProductRequest(
            mouse.Type,
            mouse.Name,
            mouse.Description,
            mouse.Manufacturer,
            mouse.ManufacturerReference,
            mouse.Value));
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

    public static Product ComputerMonitor() {
        return new Product(
            ProductDefaultValues.ComputerMonitorId,
            ProductDefaultValues.ComputerMonitorReference,
            "MON",
            ProductDefaultValues.ComputerMonitorName,
            ProductDefaultValues.ComputerMonitorDescription,
            ProductDefaultValues.ComputerMonitorManufacturer,
            ProductDefaultValues.ComputerMonitorManufacturerReference,
            ProductDefaultValues.ComputerMonitorValue);
    }

    public static Product Keyboard() {
        return new Product(
            ProductDefaultValues.KeyboardId,
            ProductDefaultValues.KeyboardReference,
            "KEY",
            ProductDefaultValues.KeyboardName,
            ProductDefaultValues.KeyboardDescription,
            ProductDefaultValues.KeyboardManufacturer,
            ProductDefaultValues.KeyboardManufacturerReference,
            ProductDefaultValues.KeyboardValue);
    }

    public static Product Mouse() {
        return new Product(
            ProductDefaultValues.MouseId,
            ProductDefaultValues.MouseReference,
            "MOU",
            ProductDefaultValues.MouseName,
            ProductDefaultValues.MouseDescription,
            ProductDefaultValues.MouseManufacturer,
            ProductDefaultValues.MouseManufacturerReference,
            ProductDefaultValues.MouseValue);
    }
}