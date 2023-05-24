using OrdersWebApi.Users.Queries;

namespace OrdersWebApi.Bills.Queries;

public record ReadBillDto(
    string Company,
    string CompanyAddress,
    ReadUserDto Customer,
    IEnumerable<BillRow> Items,
    int Total
);