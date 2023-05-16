﻿using OrdersWebApi.Products.Queries;

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
            "MON", 
            "A Name", 
            "A Description",
            "A Manufacturer", 
            "A Manufacturer Reference", 
            0));
    }

    public Task Create(Product product) {
        _dictionary.Add(product.Id, product);
        return Task.CompletedTask;
    }
}