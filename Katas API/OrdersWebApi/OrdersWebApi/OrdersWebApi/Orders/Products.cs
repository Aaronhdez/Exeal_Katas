namespace OrdersWebApi.Orders;

public class Products {
    public Products(List<Product>? products) {
        ProductsList = products;
    }

    public List<Product> ProductsList { get; }

    private bool Equals(Products other) {
        return ProductsList.SequenceEqual(other.ProductsList);
    }

    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Products)obj);
    }

    public override int GetHashCode() {
        return ProductsList.GetHashCode();
    }

    public void Add(List<Product> newProducts) {
        foreach (var product in newProducts) ProductsList.Add(product);
    }
}