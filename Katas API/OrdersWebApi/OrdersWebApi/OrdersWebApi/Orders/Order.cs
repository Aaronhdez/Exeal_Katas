using OrdersWebApi.Products;
using OrdersWebApi.Users;

namespace OrdersWebApi.Orders;

public class Order {
    public Order(string id, string creationDate,User vendor, User customer, List<Product> products) {
        Id = id;
        CreationDate = creationDate;
        Vendor = vendor;
        Customer = customer;
        Products = products;
    }

    public string Id { get; }
    public string CreationDate { get; }
    public User Vendor { get; }
    public User Customer { get; }
    public List<Product> Products { get; }

    public void AddProduct(Product newProduct) {
        Products.Add(newProduct);
    }

    public Dictionary<Product, int> GetProductsAssociated() {
        var itemsAssociated = new Dictionary<Product, int>();
        foreach (var item in Products)
            if (itemsAssociated.ContainsKey(item))
                itemsAssociated[item] += 1;
            else
                itemsAssociated.Add(item, 1);
        return itemsAssociated;
    }

    private bool Equals(Order other) {
        return Id == other.Id;
    }

    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Order)obj);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Id, CreationDate, Customer, Products);
    }
}