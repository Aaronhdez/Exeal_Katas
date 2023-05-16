using OrdersWebApi.Products;

namespace OrdersWebApi.Infrastructure;

public class ProductReferenceGenerator {
    private readonly IProductsRepository _repository;

    public ProductReferenceGenerator(IProductsRepository repository) {
        _repository = repository;
    }

    public string GenerateReferenceForTag(string tag) {
        var numberOfProductsWithTag = _repository.GetAllProductsForTag(tag);
        return null;
    }
}