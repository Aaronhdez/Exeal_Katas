using OrdersWebApi.Products;

namespace OrdersWebApi.Orders;

public class Order {
    public string Id { get; }
    public string CreationDate { get; }
    public string Customer { get; }
    public string Address { get; }
    public List<Product> Products { get; }
    
    public Order(string id, string creationDate, string customer, string address, List<Product> products) {
        Id = id;
        CreationDate = creationDate;
        Customer = customer;
        Address = address;
        Products = products;
    }

    public void AddProduct(Product newProduct) {
        Products.Add(newProduct);
    }

    public Dictionary<Product, int> GetProductsAssociated() {
        var itemsAssociated = new Dictionary<Product, int>();
        foreach (var item in Products) {
            if (itemsAssociated.ContainsKey(item)) {
                itemsAssociated[item] += 1;
            } else {
                itemsAssociated.Add(item, 1);
            }
        }
        return itemsAssociated;
    }

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
}