using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests;

public static class TestDefaultValues {
    public static DateTime CreationDateTime = new(2023, 04, 24);
    public static readonly string CreationDate = CreationDateTime.ToString("dd/MM/yyyy");

    // Users
    public const string CompanyName = "Computer Stuff Inc.";
    public const string CompanyAddress = "A company Address";
    public const string CustomerAddress = "A Simple Address, 123";
    public const string CustomerName = "John Doe";

    // Products
    public static Guid ComputerMonitorGuid = Guid.Parse("1c93009e-101f-4f4b-bf6b-a1c1d486dd03");
    public const string ComputerMonitorId = "1c93009e-101f-4f4b-bf6b-a1c1d486dd03";
    private const string ComputerMonitorName = "Computer Monitor";
    private const int ComputerMonitorValue = 100;
    public static readonly Product ComputerMonitor = new(ComputerMonitorId, ComputerMonitorName, ComputerMonitorValue);

    public static Guid KeyboardGuid = Guid.Parse("08083948-2d0d-4808-b0a8-fbd9d6ad4388");
    public const string KeyboardId = "08083948-2d0d-4808-b0a8-fbd9d6ad4388";
    private const string KeyboardName = "Keyboard";
    private const int KeyboardValue = 20;
    public static readonly Product Keyboard = new(KeyboardId, KeyboardName, KeyboardValue);

    public static Guid MouseGuid = Guid.Parse("5e0b445b-1eeb-41c0-86cb-dd097c27d41e");
    public const string MouseId = "5e0b445b-1eeb-41c0-86cb-dd097c27d41e";
    private const string MouseName = "Mouse";
    private const int MouseValue = 15;
    public static readonly Product Mouse = new(MouseId, MouseName, MouseValue);

    // Orders
    public static Guid OrderGuid = Guid.Parse("b323d8aa-2af3-4bbb-89e8-521d993cafee");
    public const string OrderId = "b323d8aa-2af3-4bbb-89e8-521d993cafee";
    public static readonly Order AnOrder = new(
        OrderId, 
        CreationDate, 
        CustomerName, 
        CustomerAddress,
        new List<Product> { ComputerMonitor });

}