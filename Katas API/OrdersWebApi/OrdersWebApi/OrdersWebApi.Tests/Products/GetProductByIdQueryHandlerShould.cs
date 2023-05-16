using FluentAssertions;
using NSubstitute.Core;
using NSubstitute.ExceptionExtensions;
using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests.Products; 

public class GetProductByIdQueryHandlerShould {
    private GetProductByIdQuery _getOrderByIdQuery;
    private GetProductByIdQueryHandler _handler;
    private IProductsRepository _ordersRepository;

    [SetUp]
    public void SetUp() {
        _ordersRepository = new InMemoryProductsRepository();
        _handler = new GetProductByIdQueryHandler(_ordersRepository);
    }

    [Test]
    public void FailWhenRepositoryIsEmpty() {
        var productQuery = new GetProductByIdQuery("AnId");
        
        var result = () => _handler.Handle(productQuery, default).Result;

        result.Should().Throw<ArgumentException>();
    }
    
    
}