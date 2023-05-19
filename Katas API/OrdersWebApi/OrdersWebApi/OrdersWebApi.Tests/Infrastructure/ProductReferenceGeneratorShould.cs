using FluentAssertions;
using NSubstitute;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products;

namespace OrdersWebApi.Tests.Infrastructure;

public class ProductReferenceGeneratorShould {
    private ICollection<Product> _dummyList;
    private ProductReferenceGenerator _referenceGenerator;
    private IProductsRepository _repository;

    [SetUp]
    public void SetUp() {
        _repository = Substitute.For<IProductsRepository>();
        _dummyList = Substitute.For<ICollection<Product>>();
        _repository.GetAllProductsForTag(Arg.Any<string>()).Returns(_dummyList);
        _referenceGenerator = new ProductReferenceGenerator(_repository);
    }

    [TestCase(0, "MON", "MON000001")]
    [TestCase(1, "MON", "MON000002")]
    [TestCase(2, "MON", "MON000003")]
    [TestCase(9, "MON", "MON000010")]
    [TestCase(99, "MON", "MON000100")]
    [TestCase(999, "MON", "MON001000")]
    [TestCase(9999, "MON", "MON010000")]
    [TestCase(99999, "MON", "MON100000")]
    public async Task GenerateIdForDifferentOccurrences(int occurrences, string tag, string expectedReference) {
        _dummyList.Count.Returns(occurrences);

        var reference = await _referenceGenerator.GenerateReferenceForTag(tag);

        reference.Should().Be(expectedReference);
    }
}