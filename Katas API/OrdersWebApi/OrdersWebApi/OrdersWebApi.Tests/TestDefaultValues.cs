using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests.Acceptance;

public static class TestDefaultValues {
    public const string OrderId = "ORD123456";
    public const string OtherOrderId = "ORD123458";
    public const string CustomerAddress = "A Simple Address, 123";
    public const string CustomerName = "John Doe";
    public const string CreationDate = "24/04/2023";
    public const string ComputerMonitorId = "PROD000001";
    public static readonly Item ComputerMonitor = new(ComputerMonitorId, "Computer Monitor", 100);
    public static readonly Item Keyboard = new("PROD000002", "Keyboard", 20);
    public static readonly Item Mouse = new("PROD000003", "Mouse", 15);
}