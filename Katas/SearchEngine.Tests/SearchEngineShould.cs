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
}