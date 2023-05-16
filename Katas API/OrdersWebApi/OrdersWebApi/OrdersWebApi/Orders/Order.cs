using OrdersWebApi.Products;

namespace OrdersWebApi.Orders;

public class Order {
    public Order(string id, string creationDate, string customer, string address, List<Product> products) {
        Id = id;
        CreationDate = creationDate;
        Customer = customer;
        Address = address;
        Products = products;
    }

    public string Id { get; }
    public string CreationDate { get; }
    public string Customer { get; set; }
    public string Address { get; set; }
    public List<Product> Products { get; set; }

    private bool Equals(Order other) {
        return Id == other.Id && CreationDate == other.CreationDate && Customer == other.Customer &&
               Address == other.Address && Products.SequenceEqual(other.Products);
    }

    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Order)obj);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Id, CreationDate, Customer, Address, Products);
    }

    public void AddProducts(List<Product> newProducts) {
        foreach (var newProduct in newProducts) Products.Add(newProduct);
    }
}