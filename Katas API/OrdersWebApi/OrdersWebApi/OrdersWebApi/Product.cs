namespace OrdersWebApi;

#pragma warning disable CS8602
public class Product
{
    private string ComputerMonitor { get; }
    private int Value { get; }

    public Product(string computerMonitor, int value)
    {
        ComputerMonitor = computerMonitor;
        Value = value;
    }
}