namespace OrdersWebApi.Orders;

#pragma warning disable CS8602
public class Item {
    public Item(string id, string name, long value) {
        Id = id;
        Name = name;
        Value = value;
    }

    public Item(string id, string type, string name, string description, string manufacturer, string manufacturerReference, int value) {
        Id = id;
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
    public long Value { get; }

    private bool Equals(Item other) {
        return Id == other.Id && Name == other.Name && Value == other.Value;
    }

    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Item)obj);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Name, Value);
    }
}