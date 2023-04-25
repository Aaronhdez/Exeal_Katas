namespace OrdersWebApi;

public class Products
{
    public Product[] ProductsList { get; }

    public Products(Product[] products)
    {
        ProductsList = products;
    }
}