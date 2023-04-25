namespace OrdersWebApi.Model.Orders;


public class Order
{
    public readonly string Id;
    private readonly string _timestamp;
    private readonly string _customer;
    private readonly string _address;
    private readonly Products _products;

    public Order(string id, string timestamp, string customer, string address, Products products)
    {
        Id = id;
        _timestamp = timestamp;
        _customer = customer;
        _address = address;
        _products = products;
    }

    private bool Equals(Order other)
    {
        return Id == other.Id && _timestamp == other._timestamp && _customer == other._customer &&
               _address == other._address && _products.Equals(other._products);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Order)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, _timestamp, _customer, _address, _products);
    }
}