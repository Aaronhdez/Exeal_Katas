using FluentAssertions;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Commands;
using OrdersWebApi.Products.Queries;
using OrdersWebApi.Products.Repositories;

namespace OrdersWebApi.Tests.Products.CommandHandlers;

public class CreateProductCommandHandlerShould {
    private CreateProductDto _createProductDto;
    private CreateProductCommandHandler _handler;
    private IProductsRepository _repository;
    private CreateProductCommand _command;
    private ProductReferenceGenerator _referenceGenerator;

    [SetUp]
    public void SetUp() {
        _repository = new InMemoryProductsRepository();
        _referenceGenerator = new ProductReferenceGenerator(_repository);
        _handler = new CreateProductCommandHandler(_repository, _referenceGenerator);
    }

    [Test]
    public async Task StoreAProductInRepository() {
        _createProductDto = ProductsMother.TestCreateProductDto("MON");

        await _handler.Handle(new CreateProductCommand(_createProductDto), default);

        var product = ProductsMother.TestExpectedProductReadDto();
        var expectedProduct = await _repository.GetById("An Id");
        expectedProduct.Should().BeEquivalentTo(product);
    }
}