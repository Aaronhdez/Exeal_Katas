namespace OrdersWebApi.Products;

#pragma warning disable CS8602
public class Product {
    public Product() { }

    public Product(string id, string productReference, string type, string name, string description,
        string manufacturer, string manufacturerReference, int value) {
        Id = id;
        ProductReference = productReference;
        Type = type;
        Name = name;
        Description = description;
        Manufacturer = manufacturer;
        ManufacturerReference = manufacturerReference;
        Value = value;
    }

    public string Id { get; }
    public string Type { get; }
    public string Name { get; }
    public string Description { get; }
    public string Manufacturer { get; }
    public string ManufacturerReference { get; }
    public string ProductReference { get; set; }
    public int Value { get; }

    private bool Equals(Product other) {
        return ProductReference == other.ProductReference;
    }

    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Product)obj);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Name, Value);
    }
}