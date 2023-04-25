namespace OrdersWebApi;


public class Order
{
    private readonly string _id;
    private readonly string _timestamp;
    private readonly string _customer;
    private readonly string _address;
    private readonly Products _products;

    public Order(string id, string timestamp, string customer, string address, Products products)
    {
        _id = id;
        _timestamp = timestamp;
        _customer = customer;
        _address = address;
        _products = products;
    }

    private bool Equals(Order other)
    {
        return _id == other._id && _timestamp == other._timestamp && _customer == other._customer &&
               _address == other._address; 
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
        return HashCode.Combine(_id, _timestamp, _customer, _address, _products);
    }
}