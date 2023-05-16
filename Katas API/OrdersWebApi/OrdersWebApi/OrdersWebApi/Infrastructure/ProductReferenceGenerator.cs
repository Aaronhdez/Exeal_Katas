using OrdersWebApi.Products;

namespace OrdersWebApi.Infrastructure;

public class ProductReferenceGenerator {
    private readonly IProductsRepository _repository;

    public ProductReferenceGenerator(IProductsRepository repository) {
        _repository = repository;
        throw new NotImplementedException();
    }

    public string GenerateReferenceForTag(string tag) {
        throw new NotImplementedException();
    }
}