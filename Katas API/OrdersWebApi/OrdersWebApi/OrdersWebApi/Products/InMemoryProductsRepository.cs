using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests.Products;

public class InMemoryProductsRepository : IProductsRepository {
    private readonly Dictionary<string,Item> _dictionary;
    public InMemoryProductsRepository() {
        _dictionary = new Dictionary<string, Item>();
    }

   // public Task<Item> GetById(string productId) {
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

    public Task Create(Item item) {
        _dictionary.Add(item.Id, item);
        return Task.CompletedTask;
    }
}