namespace OrdersWebApi;

public class CreateOrderModelDto
{
    private string Id { get; }
    private string Timestamp { get; }
    private string Customer { get; }
    private string Address { get; }
    private Product[] Products { get; }

    public CreateOrderModelDto(string id, string timestamp, string customer, string address, Product[] products)
    {
        Id = id;
        Timestamp = timestamp;
        Customer = customer;
        Address = address;
        Products = products;
    }

    private bool Equals(CreateOrderModelDto other)
    {
        return Id == other.Id && Timestamp == other.Timestamp && Customer == other.Customer && Address == other.Address && Products.Equals(other.Products);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((CreateOrderModelDto)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Timestamp, Customer, Address, Products);
    }
}