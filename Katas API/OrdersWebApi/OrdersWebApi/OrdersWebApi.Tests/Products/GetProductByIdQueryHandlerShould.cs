using FluentAssertions;
using NSubstitute.Core;
using NSubstitute.ExceptionExtensions;
using OrdersWebApi.Orders;
using OrdersWebApi.Products;

namespace OrdersWebApi.Tests.Products; 

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
    public void FailWhenRepositoryIsEmpty() {
        var productQuery = new GetProductByIdQuery("AnId");
        
        var result = () => _handler.Handle(productQuery, default).Result;

        result.Should().Throw<ArgumentException>();
    }

    [Test]
    public async Task GetAProductDtoFromExistingRecord() {
        var productId = "An Id";
        var product = new Item(productId, "MON", "A Name", "A Description",
            "A Manufacturer", "A Manufacturer Reference", 0);
        await _repository.Create(product);

        var productQuery = new GetProductByIdQuery(productId);
        var result = await _handler.Handle(productQuery, default);
        
        var expectedDto = new ProductReadDto(
            productId, 
            "MON", 
            "A Name", 
            "A Description",
            "A Manufacturer", 
            "A Manufacturer Reference", 
            0);
        result.Should().BeEquivalentTo(expectedDto);
    }

}