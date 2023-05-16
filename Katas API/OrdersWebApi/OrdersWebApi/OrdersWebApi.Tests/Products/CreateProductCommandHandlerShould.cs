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

        var product = new ProductReadDto("An Id", 
            "MON", 
            "A Name", 
            "A Description",
            "A Manufacturer", 
            "A Manufacturer Reference", 
            0);
        var expectedProduct = await _repository.GetReadDtoById("An Id");
        expectedProduct.Should().Be(product);
    }
}