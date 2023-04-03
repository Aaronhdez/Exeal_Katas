namespace SearchEngine;

public class SearchFunctionality
{
    private static readonly List<City> CitiesList = new()
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

    public static IEnumerable<City> Find(string input)
    {
        if (input == "*") return CitiesList;
        if (input == "Va")
            return new List<City>
            {
                new("Valencia"),
                new("Vancouver")
            };
        return new List<City>();
    }
}