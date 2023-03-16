namespace PointOfSale;

public class Bag
{
    public Bag(List<Product> products)
    {
        Products = products;
    }

    public List<Product> Products { get; }
}