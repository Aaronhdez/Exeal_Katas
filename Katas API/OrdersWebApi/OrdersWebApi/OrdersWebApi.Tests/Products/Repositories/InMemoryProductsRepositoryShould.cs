using FluentAssertions;
using OrdersWebApi.Products.Repositories;

namespace OrdersWebApi.Tests.Products.Repositories;

public class InMemoryProductsRepositoryShould {
    private InMemoryProductsRepository _repository;

    [SetUp]
    public void SetUp() {
        _repository = new InMemoryProductsRepository();
    }
    
    [Test]
    public void FailWhenRepositoryIsEmpty() {
        var result = () => _repository.GetById("AnId").Result;

        result.Should().Throw<ArgumentException>();
    }
}