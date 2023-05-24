using FluentAssertions;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Commands;
using OrdersWebApi.Products.Queries;
using OrdersWebApi.Products.Repositories;

namespace OrdersWebApi.Tests.Products.CommandHandlers;

public class CreateProductCommandHandlerShould {
    private CreateProductCommand _command;
    private CreateProductCommandHandler _handler;
    private ProductReferenceGenerator _referenceGenerator;
    private IProductsRepository _repository;

    [SetUp]
    public void SetUp() {
        _repository = new InMemoryProductsRepository();
        _referenceGenerator = new ProductReferenceGenerator(_repository);
        _handler = new CreateProductCommandHandler(_repository, _referenceGenerator);
    }

    [Test]
    public async Task StoreAProductInRepository() {
        var createProductDto = ProductsMother.TestCreateComputerMonitorDto("MON");

        await _handler.Handle(new CreateProductCommand(createProductDto), default);

        var expectedProduct = await _repository.GetById(createProductDto.Id);
        expectedProduct.Should().BeEquivalentTo(ProductsMother.ComputerMonitorReadDto());
    }
}