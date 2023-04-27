namespace OrdersWebApi.Orders;

public class Products
{
    public List<Product> ProductsList { get; }

    public Products(List<Product> products)
    {
        ProductsList = products;
    }
    
    private bool Equals(Products other)
    {
        return ProductsList.SequenceEqual(other.ProductsList);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Products)obj);
    }

    public override int GetHashCode()
    {
        return ProductsList.GetHashCode();
    }

    public void Add(List<Product> newProducts)
    {
        foreach (var product in newProducts)
        {
            ProductsList.Add(product);
        }
    }
}