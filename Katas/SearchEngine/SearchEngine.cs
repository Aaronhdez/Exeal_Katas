using System.Text.RegularExpressions;

namespace SearchEngine;

public class SearchEngine
{
    private readonly IRepository _citiesRepository;

    public SearchEngine(IRepository citiesRepository)
    {
        _citiesRepository = citiesRepository;
    }

    public IEnumerable<City> Find(string input)
    {
        return !string.IsNullOrEmpty(input) ? 
            CitiesFoundWith(input) : new List<City>();
    }

    private IEnumerable<City> CitiesFoundWith(string input)
    {
        if (input == "*") return _citiesRepository.GetCities();

        return _citiesRepository.GetCities()
            .Where(city => Regex.IsMatch(city.Name, $"(?i){input}(?-i)"))
            .ToList();
    }
}