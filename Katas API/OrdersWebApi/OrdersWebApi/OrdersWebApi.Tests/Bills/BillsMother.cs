using OrdersWebApi.Bills.Queries;

namespace OrdersWebApi.Tests.Bills;

public class BillsMother {
    public static ReadBillDto ATestBill() {
        return new ReadBillDto (
            TestDefaultValues.CompanyName,
            TestDefaultValues.CompanyAddress,
            TestDefaultValues.CustomerName,
            TestDefaultValues.CustomerAddress,
            new List<BillRow> {
                new("1 x Computer Monitor", 100 )
            },
            100
        );
    }
}