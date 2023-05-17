using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Repositories;

namespace OrdersWebApi.Tests.Infrastructure; 

public class ProductReferenceGeneratorShould {
    private IProductsRepository _repository;
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
    
    [Test]
    public async Task GenerateAnIdForThirdOccurenceInARepository() {
        _repository = new InMemoryProductsRepository();
        _referenceGenerator = new ProductReferenceGenerator(_repository);
        await _repository.Create(TestDefaultValues.ComputerMonitor);
        await _repository.Create(TestDefaultValues.AnotherComputerMonitor);

        var reference = await _referenceGenerator.GenerateReferenceForTag("MON");

        var expectedReference = "MON000003";
        reference.Should().Be(expectedReference);
    }

    [Test]
    public async Task GenerateAnIdFor10Ocurrences() {
        _repository = Substitute.For<IProductsRepository>();
        _referenceGenerator = new ProductReferenceGenerator(_repository);
        _repository.GetAllProductsForTag(Arg.Any<string>()).Returns(new List<Product> {
            new(), new(), new(), new(), new(), new(), new(), new(), new(),
        });
        var reference = await _referenceGenerator.GenerateReferenceForTag("MON");

        var expectedReference = "MON000010";
        reference.Should().Be(expectedReference);
    }
    
    [Test]
    public async Task GenerateAnIdFor100Ocurrences() {
        _repository = Substitute.For<IProductsRepository>();
        var dummyList = Substitute.For<ICollection<Product>>();
        dummyList.Count().Returns(99);
        _repository.GetAllProductsForTag(Arg.Any<string>()).Returns(dummyList);
        _referenceGenerator = new ProductReferenceGenerator(_repository);
        
        var reference = await _referenceGenerator.GenerateReferenceForTag("MON");

        var expectedReference = "MON000100";
        reference.Should().Be(expectedReference);
    }
}