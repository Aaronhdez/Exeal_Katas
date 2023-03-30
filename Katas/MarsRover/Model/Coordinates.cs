namespace MarsRover.Model;

public class Coordinates
{
    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    private int X { get; set; }
    private int Y { get; set; }

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

    public void IncreaseY()
    {
        Y += 1;
    }

    public void DecreaseY()
    {
        Y -= 1;
    }

    public void IncreaseX()
    {
        X += 1;
    }

    public void DecreaseX()
    {
        X -= 1;
    }
}