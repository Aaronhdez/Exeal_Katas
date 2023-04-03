namespace SearchEngine;

public class City
{
    public string Name { get; }

    public City(string name)
    {
        Name = name;
    }

    private bool Equals(City other)
    {
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((City)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}