namespace OrdersWebApi.Orders;

#pragma warning disable CS8602
public class Item {
    public Item(string id, string name, long value) {
        Id = id;
        Name = name;
        Value = value;
    }

    public string Id { get; }
    public string Name { get; }
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