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
    public async Task RetrieveEmptyListForAGivenTagWhenThereAreNoOccurrences() {
        _repository = new InMemoryProductsRepository();

        var taggedProducts = await _repository.GetAllProductsForTag("MON");

        taggedProducts.Should().BeEmpty();
    }

    [Test]
    public async Task RetrieveProductsForAGivenTagWhenThereAreOccurrences() {
        _repository = new InMemoryProductsRepository();
        await _repository.Create(ProductDefaultValues.Keyboard);

        var taggedProducts = await _repository.GetAllProductsForTag(ProductDefaultValues.Keyboard.Type);

        taggedProducts.Should().HaveCount(1);
    }

    [Test]
    public void FailWhenRepositoryIsEmpty() {
        Action result = () => _repository.GetById("AnId");

        result.Should().Throw<ArgumentException>();
    }


    //[Test]
    //public async Task RetrieveAProductWhenItExists() {
    //    var product = new Product(
    //        "AnId", 
    //        "A product reference",
    //        "A Type", 
    //        "A Name", 
    //        "A Description", 
    //        "A Manufacturer", 
    //        "A Manufacturer Reference", 
    //        0);
    //    
    //    await _repository.Create(product);
    //
    //    //var expectedDto
    //    var createdProduct = await _repository.GetById("AnId");
    //    
    //}
}