namespace OrdersWebApi.Model.Orders;

public class Products
{
    public Product[] ProductsList { get; }

    public Products(Product[] products)
    {
        ProductsList = products;
    }
    
    private bool Equals(Products other)
    {
        return !ProductsList.Where((t, i) => t.Equals(other.ProductsList[i])).Any();
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
}