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
        var product = ProductsMother.ComputerMonitor();
        await _repository.Create(product);

        var productQuery = new GetProductByIdQuery(product.Id);
        var result = await _handler.Handle(productQuery, default);

        var expectedDto = ProductsMother.ComputerMonitorReadDto();
        result.Should().BeEquivalentTo(expectedDto);
    }
}