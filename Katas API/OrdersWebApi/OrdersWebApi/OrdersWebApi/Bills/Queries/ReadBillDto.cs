namespace OrdersWebApi.Bills.Queries;

public record ReadBillDto(
    string Company,
    string CompanyAddress,
    string Customer,
    string CustomerAddress,
    IEnumerable<BillRow> Items,
    int Total
);