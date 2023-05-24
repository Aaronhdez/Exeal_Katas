using OrdersWebApi.Bills;
using OrdersWebApi.Bills.Queries;
using OrdersWebApi.Tests.Users;
using OrdersWebApi.TestUtils;
using OrdersWebApi.TestUtils.Users;
using OrdersWebApi.Users.Queries;

namespace OrdersWebApi.Tests.Bills;

public class BillsMother {
    public static ReadBillDto ATestBill() {
        return new ReadBillDto(
            UserDefaultValues.CompanyName,
            UserDefaultValues.CompanyAddress,
            new ReadUserDto(UserDefaultValues.CustomerId, UserDefaultValues.CustomerName, UserDefaultValues.CustomerAddress),
            new List<BillRow> {
                new("1 x Computer Monitor", 100)
            },
            100
        );
    }
}