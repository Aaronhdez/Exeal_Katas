using System.Collections.Immutable;
using OrdersWebApi.Products.Queries;

namespace OrdersWebApi.Products.Repositories;

public class InMemoryProductsRepository : IProductsRepository {
    private readonly Dictionary<string,Product> _dictionary;
    public InMemoryProductsRepository() {
        _dictionary = new Dictionary<string, Product>();
    }
    
    public Task<Product> GetById(string productId) {
        if (!_dictionary.ContainsKey(productId)) throw new ArgumentException();
        return Task.FromResult(new Product(
            "An Id", 
            "A product reference",
            "MON", 
            "A Name", 
            "A Description",
            "A Manufacturer", 
            "A Manufacturer Reference", 
            0));
    }

    public Task<IEnumerable<Product>> GetAllProductsForTag(string tag) {
        var taggedProducts = new List<Product>();
        foreach (var product in _dictionary.Values) {
            if(product.Type == tag) taggedProducts.Add(product);
        }
        return Task.FromResult<IEnumerable<Product>>(taggedProducts);
    }

    public Task Create(Product product) {
        _dictionary.Add(product.Id, product);
        return Task.CompletedTask;
    }
}