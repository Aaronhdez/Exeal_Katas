using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests.Products;

public class InMemoryProductsRepository : IProductsRepository {
    private readonly Dictionary<string,Product> _dictionary;
    public InMemoryProductsRepository() {
        _dictionary = new Dictionary<string, Product>();
    }

   // public Task<Product> GetById(string productId) {
   //     return Task.FromResult(_dictionary[productId]);
   // }
    
    public Task<ProductReadDto> GetById(string productId) {
        if (!_dictionary.ContainsKey(productId)) throw new ArgumentException();
        return Task.FromResult(new ProductReadDto{
            Id = "An Id", 
            ProductReference = "MON", 
            Name = "A Name", 
            Description = "A Description",
            Manufacturer = "A Manufacturer", 
            ManufacturerReference = "A Manufacturer Reference", 
            Value = 0});
    }

    public Task Create(Product product) {
        _dictionary.Add(product.Id, product);
        return Task.CompletedTask;
    }
}