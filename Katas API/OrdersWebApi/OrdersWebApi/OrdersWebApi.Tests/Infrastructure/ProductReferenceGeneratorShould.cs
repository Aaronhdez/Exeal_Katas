using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products;
using OrdersWebApi.Products.Repositories;

namespace OrdersWebApi.Tests.Infrastructure;

public class ProductReferenceGeneratorShould {
    private IProductsRepository _repository;
    private ProductReferenceGenerator _referenceGenerator;
    private ICollection<Product> _dummyList;

    [SetUp]
    public void SetUp() {
        _repository = Substitute.For<IProductsRepository>();
        _dummyList = Substitute.For<ICollection<Product>>();
        _repository.GetAllProductsForTag(Arg.Any<string>()).Returns(_dummyList);
        _referenceGenerator = new ProductReferenceGenerator(_repository);
    }

    [Test]
    public async Task GenerateAnIdForFirstOccurenceInARepository() {
        _dummyList.Count().Returns(0);

        var reference = await _referenceGenerator.GenerateReferenceForTag("MON");

        reference.Should().Be("MON000001");
    }

    [Test]
    public async Task GenerateAnIdForSecondOccurenceInARepository() {
        _dummyList.Count().Returns(1);

        var reference = await _referenceGenerator.GenerateReferenceForTag("MON");

        reference.Should().Be("MON000002");
    }

    [Test]
    public async Task GenerateAnIdForThirdOccurenceInARepository() {
        _dummyList.Count().Returns(2);

        var reference = await _referenceGenerator.GenerateReferenceForTag("MON");

        reference.Should().Be("MON000003");
    }

    [Test]
    public async Task GenerateAnIdFor10Ocurrences() {
        _dummyList.Count().Returns(9);

        var reference = await _referenceGenerator.GenerateReferenceForTag("MON");

        reference.Should().Be("MON000010");
    }

    [Test]
    public async Task GenerateAnIdFor100Ocurrences() {
        _dummyList.Count().Returns(99);

        var reference = await _referenceGenerator.GenerateReferenceForTag("MON");

        reference.Should().Be("MON000100");
    }

    [Test]
    public async Task GenerateAnIdFor1000Ocurrences() {
        _dummyList.Count().Returns(999);

        var reference = await _referenceGenerator.GenerateReferenceForTag("MON");

        reference.Should().Be("MON001000");
    }
    
    [Test]
    public async Task GenerateAnIdFor10000Ocurrences() {
        _dummyList.Count().Returns(9999);

        var reference = await _referenceGenerator.GenerateReferenceForTag("MON");

        reference.Should().Be("MON010000");
    }
}