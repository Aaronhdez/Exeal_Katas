namespace OrdersWebApi.Bills.Queries;

public class ReadBillDto {
    public string Company { get; set; }
    public string CompanyAddress { get; set; }
    public string Customer { get; set; }
    public string CustomerAddress { get; set; }
    public IEnumerable<BillRow> Items { get; set; }
    public int Total { get; set; }
}