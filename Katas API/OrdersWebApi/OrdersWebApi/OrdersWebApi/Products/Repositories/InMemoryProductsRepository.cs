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
        return Task.FromResult(_dictionary[productId]);
    }

    public Task<IEnumerable<Product>> GetAllProductsForTag(string tag) {
        var taggedProducts = _dictionary.Values.Where(product => product.Type == tag).ToList();
        return Task.FromResult<IEnumerable<Product>>(taggedProducts);
    }

    public Task Create(Product product) {
        _dictionary.Add(product.Id, product);
        return Task.CompletedTask;
    }
}