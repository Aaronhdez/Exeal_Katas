using FluentAssertions;

namespace OrdersWebApi.Tests.Products;

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