using FluentAssertions;
using OrdersWebApi.Products;
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
        Action result = () => _repository.GetById("AnId");

        result.Should().Throw<ArgumentException>();
    }
    
    [Test]
    public async Task RetrieveAProductWhenItExists() {
        var product = new Product(
            "AnId", 
            "A Type", 
            "A Name", 
            "A Description", 
            "A Manufacturer", 
            "A Manufacturer Reference", 
            0);
        
        await _repository.Create(product);

        //var expectedDto
        var createdProduct = await _repository.GetById("AnId");
        
    }
}