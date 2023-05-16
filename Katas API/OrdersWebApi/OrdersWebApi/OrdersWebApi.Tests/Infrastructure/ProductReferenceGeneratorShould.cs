using FluentAssertions;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products.Repositories;

namespace OrdersWebApi.Tests.Infrastructure; 

public class ProductReferenceGeneratorShould {
    private InMemoryProductsRepository _repository;
    private ProductReferenceGenerator _referenceGenerator;

    [Test]
    public async Task GenerateAnIdForFirstOccurenceInARepository() {
        _repository = new InMemoryProductsRepository();
        _referenceGenerator = new ProductReferenceGenerator(_repository);

        var reference = await _referenceGenerator.GenerateReferenceForTag("MON");

        var expectedReference = "MON000001";
        reference.Should().Be(expectedReference);
    }
    
    [Test]
    public async Task GenerateAnIdForSecondOccurenceInARepository() {
        _repository = new InMemoryProductsRepository();
        _referenceGenerator = new ProductReferenceGenerator(_repository);
        await _repository.Create(TestDefaultValues.ComputerMonitor);

        var reference = await _referenceGenerator.GenerateReferenceForTag("MON");

        var expectedReference = "MON000002";
        reference.Should().Be(expectedReference);
    }
}