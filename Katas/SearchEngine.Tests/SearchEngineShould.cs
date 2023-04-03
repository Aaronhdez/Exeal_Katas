using FluentAssertions;

namespace SearchEngine.Tests;

public class SearchEngineShould
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GiveAllCitiesIfInputIsAnAsterisk()
    {
        var citiesList = new List<City>
        {
            new City("Paris"),
            new City("Budapest"),
            new City("Skopje"),
            new City("Rotterdam"),
            new City("Valencia"),
            new City("Amsterdam"),
            new City("Sydney"),
            new City("Vienna"),
            new City("Vancouver"),
            new City("New York City"),
            new City("London"),
            new City("Bangkok"),
            new City("Dubai"),
            new City("Rome"),
            new City("Istanbul"),
        };
        
        var result = SearchFunctionality.Find("*");

        result.Should().BeEquivalentTo(citiesList);
    }

    [TestCase("1")]
    [TestCase("")]
    public void DoNotReturnAnyResultIfInputIsLessThanTwoCharactersLong(string input)
    {
        var expectedList = new List<City>();
        
        var result = SearchFunctionality.Find(input);
        
        result.Should().BeEquivalentTo(expectedList);
    }

    [Test]
    public void ReturnValenciaAndVancouverIfInputIsVa()
    {
        var expectedList = new List<City>{
            new("Valencia"), 
            new("Vancouver")};
        
        var result = SearchFunctionality.Find("Va");

        result.Should().BeEquivalentTo(expectedList);
    }
    
    [Test]
    public void ReturnValenciaViennaAndVancouverIfInputIsV()
    {
        var expectedList = new List<City>{
            new("Valencia"), 
            new("Vienna"), 
            new("Vancouver")};
        
        var result = SearchFunctionality.Find("V");

        result.Should().BeEquivalentTo(expectedList);
    }
    
    [Test]
    public void ReturnLondonIfInputIsLo()
    {
        var expectedList = new List<City>{
            new("London")};
        
        var result = SearchFunctionality.Find("Lo");

        result.Should().BeEquivalentTo(expectedList);
    }
}