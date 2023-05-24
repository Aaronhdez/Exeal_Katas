using FluentAssertions;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Commands;
using OrdersWebApi.Products.Repositories;

namespace OrdersWebApi.Tests.Products.CommandHandlers;

public class CreateProductCommandHandlerShould {
    private CreateProductCommand _command;
    private CreateProductDto _createProductDto;
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
        _createProductDto = ProductsMother.TestCreateComputerMonitorDto("MON");

        await _handler.Handle(new CreateProductCommand(_createProductDto), default);

        var product = ProductsMother.ComputerMonitorReadDto();
        var expectedProduct = await _repository.GetById(_createProductDto.Id);
        expectedProduct.Should().BeEquivalentTo(product);
    }
}