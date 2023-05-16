using FluentAssertions;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products.Repositories;

namespace OrdersWebApi.Tests.Infrastructure; 

public class ProductReferenceGeneratorShould {
    private InMemoryProductsRepository _repository;
    private ProductReferenceGenerator _referenceGenerator;

    [Test]
    public void GenerateAnIdForFirstOccurenceInARepository() {
        _repository = new InMemoryProductsRepository();
        _referenceGenerator = new ProductReferenceGenerator(_repository);

        var reference = _referenceGenerator.GenerateReferenceForTag("MON");

        var expectedReference = "MON000001";
        reference.Should().Be(expectedReference);
    }
}