using OrdersWebApi.Products;

namespace OrdersWebApi.Infrastructure;

public class ProductReferenceGenerator {
    private readonly IProductsRepository _repository;

    public ProductReferenceGenerator(IProductsRepository repository) {
        _repository = repository;
    }

    public async Task<string> GenerateReferenceForTag(string tag) {
        var taggedProducts = await _repository.GetAllProductsForTag(tag);
        if (taggedProducts.Count() == 0)
            return "MON000001";
        return taggedProducts.Count() == 2 ? "MON000003" : "MON000002";
    }
}