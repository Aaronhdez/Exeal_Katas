namespace OrdersWebApi.Products.Controllers.Requests;

public class CreateProductRequest {
    public string Type;
    public string Name;
    public string Description;
    public string Manufacturer;
    public string ManufacturerReference;
    public int Value;
}