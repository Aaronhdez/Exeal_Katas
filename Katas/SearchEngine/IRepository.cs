namespace SearchEngine;

public interface IRepository
{
    IEnumerable<City> GetCities();
}