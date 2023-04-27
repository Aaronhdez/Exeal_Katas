namespace OrdersWebApi.Models.Orders;


public class Order
{
    public readonly string Id;
    public readonly string Timestamp;
    public readonly string Customer;
    public readonly string Address;
    public readonly Products Products;

    public Order(string id, string timestamp, string customer, string address, Products products)
    {
        Id = id;
        Timestamp = timestamp;
        Customer = customer;
        Address = address;
        Products = products;
    }

    private bool Equals(Order other)
    {
        return Id == other.Id && Timestamp == other.Timestamp && Customer == other.Customer &&
               Address == other.Address && Products.Equals(other.Products);
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
        return HashCode.Combine(Id, Timestamp, Customer, Address, Products);
    }

    public void AddProducts(List<Product> newProducts)
    {
        Products.Add(newProducts);
    }
}