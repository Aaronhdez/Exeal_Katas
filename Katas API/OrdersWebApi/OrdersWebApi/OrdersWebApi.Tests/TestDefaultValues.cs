using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests.Acceptance;

public static class TestDefaultValues {
    public static DateTime CreationDateTime = new DateTime(2023, 04, 24);
    public static readonly string CreationDate = CreationDateTime.ToString("dd/MM/yyyy");

    // Users
    public const string CompanyName = "Computer Stuff Inc.";
    public const string CompanyAddress = "A company Address";
    public const string CustomerAddress = "A Simple Address, 123";
    public const string CustomerName = "John Doe";

    // Products
    public const string ComputerMonitorId = "PROD000001";
    private const string ComputerMonitorName = "Computer Monitor";
    private const int ComputerMonitorValue = 100;
    public static readonly Item ComputerMonitor = new(ComputerMonitorId, ComputerMonitorName, ComputerMonitorValue);

    public const string KeyboardId = "PROD000002";
    private const string KeyboardName = "Keyboard";
    private const int KeyboardValue = 20;
    public static readonly Item Keyboard = new(KeyboardId, KeyboardName, KeyboardValue);

    public const string MouseId = "PROD000003";
    private const string MouseName = "Mouse";
    private const int MouseValue = 15;
    public static readonly Item Mouse = new(MouseId, MouseName, MouseValue);

    // Orders
    public const string OrderId = "ORD123456";
    public static readonly Order AnOrder = new(
        OrderId, 
        CreationDate, 
        CustomerName, 
        CustomerAddress,
        new List<Item> { ComputerMonitor });
}