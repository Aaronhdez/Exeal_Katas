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
        await _repository.Create(ProductsMother.ComputerMonitor());

        var productQuery = new GetProductByIdQuery(ProductsMother.ComputerMonitor().Id);
        var result = await _handler.Handle(productQuery, default);

        result.Should().BeEquivalentTo(ProductsMother.ComputerMonitorReadDto());
    }
}