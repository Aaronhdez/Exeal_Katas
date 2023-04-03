namespace SearchEngine;

public class CitiesRepository : IRepository
{
    private readonly List<City> _citiesList = new()
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

    public List<City> GetCities()
    {
        return _citiesList;
    }
}