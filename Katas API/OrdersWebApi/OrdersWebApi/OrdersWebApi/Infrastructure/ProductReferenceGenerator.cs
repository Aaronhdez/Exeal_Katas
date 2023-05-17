using OrdersWebApi.Products;

namespace OrdersWebApi.Infrastructure;

public class ProductReferenceGenerator {
    private readonly IProductsRepository _repository;

    public ProductReferenceGenerator(IProductsRepository repository) {
        _repository = repository;
    }

    public async Task<string> GenerateReferenceForTag(string tag) {
        var taggedProducts = await _repository.GetAllProductsForTag(tag);
        return GetFormattedReference(tag, taggedProducts);
    }

    private static string GetFormattedReference(string tag, IEnumerable<Product> taggedProducts) {
        var lastNumber = taggedProducts.Count()+1;
        if(lastNumber >= 1000) return tag + "00" + lastNumber;
        if(lastNumber >= 100) return tag + "000" + lastNumber;
        if(lastNumber >= 10) return tag + "0000" + lastNumber;
        return tag + "00000" + lastNumber;
    }
}