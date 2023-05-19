using OrdersWebApi.Products;

namespace OrdersWebApi.Tests;

public static class ProductDefaultValues {
    public const string ComputerMonitorId = "1c93009e-101f-4f4b-bf6b-a1c1d486dd03";
    public static Guid ComputerMonitorGuid = Guid.Parse("1c93009e-101f-4f4b-bf6b-a1c1d486dd03");
    private const string ComputerMonitorName = "Computer Monitor";
    private const int ComputerMonitorValue = 100;
    public static readonly Product ComputerMonitor = new(
        ComputerMonitorId,
        "MON0000001",
        "MON",
        ComputerMonitorName,
        "A DELL Computer Monitor",
        "DELL Inc.",
        "DLL123456789",
        ComputerMonitorValue);
    
    public static Guid KeyboardGuid = Guid.Parse("08083948-2d0d-4808-b0a8-fbd9d6ad4388");
    public const string KeyboardId = "08083948-2d0d-4808-b0a8-fbd9d6ad4388";
    private const string KeyboardName = "Keyboard";
    private const int KeyboardValue = 20;
    public static readonly Product Keyboard = new(
        KeyboardId,
        "KEY0000001",
        "KEY",
        KeyboardName,
        "A Razer keyboard",
        "Razer",
        "DLL123456789",
        KeyboardValue);
    
    public static Guid MouseGuid = Guid.Parse("5e0b445b-1eeb-41c0-86cb-dd097c27d41e");
    public const string MouseId = "5e0b445b-1eeb-41c0-86cb-dd097c27d41e";
    private const string MouseName = "Mouse";
    private const int MouseValue = 15;
    public static readonly Product Mouse = new(
        MouseId,
        "MOU0000001",
        "MOU",
        MouseName,
        "A Logitech Mouse",
        "Logitech Inc.",
        "DLL123456789",
        MouseValue);
}