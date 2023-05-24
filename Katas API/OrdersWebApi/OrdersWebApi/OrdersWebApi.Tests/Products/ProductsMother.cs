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
        var computerMonitor = ComputerMonitor();
        return JsonConvert.SerializeObject(new CreateProductRequest(
            computerMonitor.Type,
            computerMonitor.Name,
            computerMonitor.Description,
            computerMonitor.Manufacturer,
            computerMonitor.ManufacturerReference,
            computerMonitor.Value));
    }

    public static string KeyboardCreationRequest() {
        var keyboard = Keyboard();
        return JsonConvert.SerializeObject(new CreateProductRequest(
            keyboard.Type,
            keyboard.Name,
            keyboard.Description,
            keyboard.Manufacturer,
            keyboard.ManufacturerReference,
            keyboard.Value));
    }

    public static string MouseCreationRequest() {
        var mouse = Mouse();
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

    public static ProductReadDto ComputerMonitorReadDto() {
        return new ProductReadDto {
            Id = ProductDefaultValues.ComputerMonitorId,
            ProductReference = ProductDefaultValues.ComputerMonitorReference,
            Name = ProductDefaultValues.ComputerMonitorName,
            Description = ProductDefaultValues.ComputerMonitorDescription,
            Manufacturer = ProductDefaultValues.ComputerMonitorManufacturer,
            ManufacturerReference = ProductDefaultValues.ComputerMonitorManufacturerReference,
            Value = ProductDefaultValues.ComputerMonitorValue
        };
    }

    public static CreateProductDto TestCreateComputerMonitorDto(string tag) {
        return new CreateProductDto(
            ProductDefaultValues.ComputerMonitorId,
            tag,
            ProductDefaultValues.ComputerMonitorName,
            ProductDefaultValues.ComputerMonitorDescription,
            ProductDefaultValues.ComputerMonitorManufacturer,
            ProductDefaultValues.ComputerMonitorManufacturerReference,
            ProductDefaultValues.ComputerMonitorValue);
    }

    //MODELS
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