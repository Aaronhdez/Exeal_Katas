using FluentAssertions;

namespace SearchEngine.Tests;

public class SearchEngineShould
{
    private SearchEngine? _searchEngine;
    private CitiesRepository _citiesRepository;

    [SetUp]
    public void Setup()
    {
        _citiesRepository = new CitiesRepository();
        _searchEngine = new SearchEngine(_citiesRepository);
    }

    [Test]
    public void GiveAllCitiesIfInputIsAnAsterisk()
    {
        var citiesList = new List<City>
        {
            new("Paris"),
            new("Budapest"),
            new("Skopje"),
            new("Rotterdam"),
            new("Valencia"),
            new("Amsterdam"),
            new("Sydney"),
            new("Vienna"),
            new("Vancouver"),
            new("New York City"),
            new("London"),
            new("Bangkok"),
            new("Dubai"),
            new("Rome"),
            new("Istanbul"),
        };

        var result = _searchEngine.Find("*");

        result.Should().BeEquivalentTo(citiesList);
    }

    [TestCase("1")]
    [TestCase("")]
    public void DoNotReturnAnyResultIfInputIsLessThanTwoCharactersLong(string input)
    {
        var expectedList = new List<City>();
        
        var result = _searchEngine.Find(input);
        
        result.Should().BeEquivalentTo(expectedList);
    }

    [Test]
    public void ReturnValenciaAndVancouverIfInputIsVa()
    {
        var expectedList = new List<City>{
            new("Valencia"), 
            new("Vancouver")};
        
        var result = _searchEngine.Find("Va");

        result.Should().BeEquivalentTo(expectedList);
    }
    
    [Test]
    public void ReturnValenciaViennaAndVancouverIfInputIsV()
    {
        var expectedList = new List<City>{
            new("Valencia"), 
            new("Vienna"), 
            new("Vancouver")};
        
        var result = _searchEngine.Find("V");

        result.Should().BeEquivalentTo(expectedList);
    }
    
    [Test]
    public void ReturnLondonIfInputIsLo()
    {
        var expectedList = new List<City>{
            new("London")};
        
        var result = _searchEngine.Find("Lo");

        result.Should().BeEquivalentTo(expectedList);
    }
    
    [Test]
    public void ReturnValenciaAndVancouverIfInputIsva()
    {
        var expectedList = new List<City>{
            new("Valencia"), 
            new("Vancouver")};
        
        var result = _searchEngine.Find("va");

        result.Should().BeEquivalentTo(expectedList);
    }
    
    [Test]
    public void ReturnValenciaViennaAndVancouverIfInputIsv()
    {
        var expectedList = new List<City>{
            new("Valencia"), 
            new("Vienna"), 
            new("Vancouver")};
        
        var result = _searchEngine.Find("v");

        result.Should().BeEquivalentTo(expectedList);
    }
    
    [Test]
    public void ReturnBudapestInputIsApe()
    {
        var expectedList = new List<City>{
            new("Budapest")};
        
        var result = _searchEngine.Find("ape");

        result.Should().BeEquivalentTo(expectedList);
    }
    
    [Test]
    public void ReturnRotterdamInputIsOtt()
    {
        var expectedList = new List<City>{
            new("Rotterdam")};
        
        var result = _searchEngine.Find("Ott");

        result.Should().BeEquivalentTo(expectedList);
    }
}