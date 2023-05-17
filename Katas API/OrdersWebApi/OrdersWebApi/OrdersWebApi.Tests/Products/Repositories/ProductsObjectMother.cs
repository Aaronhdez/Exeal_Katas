using Newtonsoft.Json;
using OrdersWebApi.Products.Controllers.Requests;

namespace OrdersWebApi.Tests.Acceptance;

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
}