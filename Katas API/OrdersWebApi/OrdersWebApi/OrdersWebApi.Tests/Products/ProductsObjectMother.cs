using Newtonsoft.Json;
using OrdersWebApi.Products.Controllers.Requests;

namespace OrdersWebApi.Tests.Products;

public static class ProductsObjectMother {
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
}