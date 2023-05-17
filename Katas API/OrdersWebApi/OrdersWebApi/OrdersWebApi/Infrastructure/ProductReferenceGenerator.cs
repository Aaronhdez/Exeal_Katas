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
        return lastNumber switch {
            >= 100000 => tag + lastNumber,
            >= 10000 => tag + "0" + lastNumber,
            >= 1000 => tag + "00" + lastNumber,
            >= 100 => tag + "000" + lastNumber,
            >= 10 => tag + "0000" + lastNumber,
            _ => tag + "00000" + lastNumber
        };
    }
}