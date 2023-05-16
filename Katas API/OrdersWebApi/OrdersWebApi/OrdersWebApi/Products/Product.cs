namespace OrdersWebApi.Products;

#pragma warning disable CS8602
public class Product {
    public Product(string id, string name, long value) {
        Id = id;
        Name = name;
        Value = value;
    }

    public Product(string id, string type, string name, string description, string manufacturer, string manufacturerReference, int value) {
        Id = id;
        ProductReference = "A product reference";
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
    public long Value { get; }

    private bool Equals(Product other) {
        return Id == other.Id && Name == other.Name && Value == other.Value;
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