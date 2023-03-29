namespace MarsRover;

public class Coordinates
{
    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    private bool Equals(Coordinates other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Coordinates)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}