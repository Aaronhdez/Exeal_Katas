using Newtonsoft.Json;
using OrdersWebApi.Orders.Commands.AddProductsToOrder;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Commands;
using OrdersWebApi.Products.Controllers.Requests;
using OrdersWebApi.Products.Queries;

namespace OrdersWebApi.Tests.Products;

public static class ProductsMother {
    
    //REQUESTS
    public static string ComputerMonitorCreationRequest() {
        return JsonConvert.SerializeObject(new CreateProductRequest(
            TestDefaultValues.ComputerMonitor.Type,
            TestDefaultValues.ComputerMonitor.Name,
            TestDefaultValues.ComputerMonitor.Description,
            TestDefaultValues.ComputerMonitor.Manufacturer,
            TestDefaultValues.ComputerMonitor.ManufacturerReference,
            TestDefaultValues.ComputerMonitor.Value));
    }

    public static string KeyboardCreationRequest() {
        return JsonConvert.SerializeObject(new CreateProductRequest(
        TestDefaultValues.Keyboard.Type,
        TestDefaultValues.Keyboard.Name,
        TestDefaultValues.Keyboard.Description,
        TestDefaultValues.Keyboard.Manufacturer,
        TestDefaultValues.Keyboard.ManufacturerReference,
        TestDefaultValues.Keyboard.Value));
    }

    public static string MouseCreationRequest() {
        return JsonConvert.SerializeObject(new CreateProductRequest(
            TestDefaultValues.Mouse.Type,
            TestDefaultValues.Mouse.Name,
            TestDefaultValues.Mouse.Description,
            TestDefaultValues.Mouse.Manufacturer,
            TestDefaultValues.Mouse.ManufacturerReference,
            TestDefaultValues.Mouse.Value));
    }

    //DTOs

    public static AddProductsDto AddAProductDto() {
        return new AddProductsDto(TestDefaultValues.OrderId, new [] {
            TestDefaultValues.ComputerMonitorId
        });
    }

    public static AddProductsDto AddTwoProductsDto() {
        return new AddProductsDto(TestDefaultValues.OrderId, new [] {
            TestDefaultValues.ComputerMonitorId,
            TestDefaultValues.ComputerMonitorId
        });
    }
    
    public static ProductReadDto TestExpectedProductReadDto() {
        return new ProductReadDto{
            Id = "An Id", 
            ProductReference = "MON000001", 
            Name = "A Name", 
            Description = "A Description",
            Manufacturer = "A Manufacturer", 
            ManufacturerReference = "A Manufacturer Reference", 
            Value = 0};
    }
    
    public static ProductReadDto TestProductReadDto() {
        return new ProductReadDto{
            Id = "An Id", 
            ProductReference = "MON000001", 
            Name = "A Name", 
            Description = "A Description",
            Manufacturer = "A Manufacturer", 
            ManufacturerReference = "A Manufacturer Reference", 
            Value = 0};
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