using FluentAssertions;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Queries;
using OrdersWebApi.Products.Repositories;

namespace OrdersWebApi.Tests.Products.QueryHandlers;

public class GetProductByIdQueryHandlerShould {
    private GetProductByIdQuery _getOrderByIdQuery;
    private GetProductByIdQueryHandler _handler;
    private IProductsRepository _repository;

    [SetUp]
    public void SetUp() {
        _repository = new InMemoryProductsRepository();
        _handler = new GetProductByIdQueryHandler(_repository);
    }

    [Test]
    public async Task GetAProductDtoFromExistingRecord() {
        var productId = "An Id";
        var product = new Product(productId, "MON", "A Name", "A Description",
            "A Manufacturer", "A Manufacturer Reference", 0);
        await _repository.Create(product);

        var productQuery = new GetProductByIdQuery(productId);
        var result = await _handler.Handle(productQuery, default);
        
        var expectedDto = new ProductReadDto{
            Id = "An Id", 
            ProductReference = "A product reference", 
            Name = "A Name", 
            Description = "A Description",
            Manufacturer = "A Manufacturer", 
            ManufacturerReference = "A Manufacturer Reference", 
            Value = 0};
        result.Should().BeEquivalentTo(expectedDto);
    }

}