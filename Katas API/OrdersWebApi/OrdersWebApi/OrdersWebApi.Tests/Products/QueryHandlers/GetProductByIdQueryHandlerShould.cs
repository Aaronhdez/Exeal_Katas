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
        var product = ProductsMother.ATestProduct(productId);
        await _repository.Create(product);

        var productQuery = new GetProductByIdQuery(productId);
        var result = await _handler.Handle(productQuery, default);

        var expectedDto = ProductsMother.TestProductReadDto();
        result.Should().BeEquivalentTo(expectedDto);
    }
}