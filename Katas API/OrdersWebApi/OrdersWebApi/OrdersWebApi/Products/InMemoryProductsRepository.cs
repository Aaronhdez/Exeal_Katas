using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests.Products;

public class InMemoryProductsRepository : IProductsRepository {
    private readonly Dictionary<string,Item> _dictionary;
    public InMemoryProductsRepository() {
        _dictionary = new Dictionary<string, Item>();
    }

    public Task<Item> GetById(string productId) {
        return Task.FromResult(_dictionary[productId]);
    }
    
    public Task<ProductReadDto> GetReadDtoById(string productId) {
        if (!_dictionary.ContainsKey(productId)) throw new ArgumentException();
        return Task.FromResult(new ProductReadDto("An Id", 
            "MON", 
            "A Name", 
            "A Description",
            "A Manufacturer", 
            "A Manufacturer Reference", 
            0));
    }

    public Task Create(Item item) {
        _dictionary.Add(item.Id, item);
        return Task.CompletedTask;
    }
}