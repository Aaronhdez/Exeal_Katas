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
        var tag = "MON";
        _createProductDto = new CreateProductDto("An Id", tag, "A Name", "A Description",
            "A Manufacturer", "A Manufacturer Reference", 0);

        await _handler.Handle(new CreateProductCommand(_createProductDto), default);

        var product = new ProductReadDto{
            Id = "An Id", 
            ProductReference = "MON000001", 
            Name = "A Name", 
            Description = "A Description",
            Manufacturer = "A Manufacturer", 
            ManufacturerReference = "A Manufacturer Reference", 
            Value = 0};
        var expectedProduct = await _repository.GetById("An Id");
        expectedProduct.Should().BeEquivalentTo(product);
    }
}