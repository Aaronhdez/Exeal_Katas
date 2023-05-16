using FluentAssertions;
using FluentAssertions.Common;
using NSubstitute;
using OrdersWebApi.Orders;
using OrdersWebApi.Orders.Repositories;
using OrdersWebApi.Products;

namespace OrdersWebApi.Tests.Products;

public class CreateProductCommandHandlerShould {
    private CreateProductDto _createProductDto;
    private CreateProductCommandHandler _handler;
    private IProductsRepository _repository;
    private CreateProductCommand _command;

    [SetUp]
    public void SetUp() {
        _repository = new InMemoryProductsRepository();
        _handler = new CreateProductCommandHandler(_repository);
    }

    [Test]
    public async Task StoreAProductInRepository() {
        _createProductDto = new CreateProductDto("An Id", "MON", "A Name", "A Description",
            "A Manufacturer", "A Manufacturer Reference", 0);

        await _handler.Handle(new CreateProductCommand(_createProductDto), default);

        var product = new ProductReadDto{
            Id = "An Id", 
            ProductReference = "MON", 
            Name = "A Name", 
            Description = "A Description",
            Manufacturer = "A Manufacturer", 
            ManufacturerReference = "A Manufacturer Reference", 
            Value = 0};
        var expectedProduct = await _repository.GetById("An Id");
        expectedProduct.Should().BeEquivalentTo(product);
    }
}