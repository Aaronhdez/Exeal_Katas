using OrdersWebApi.Bills.Queries;
using OrdersWebApi.Orders;
using OrdersWebApi.Products;

namespace OrdersWebApi.Bills;

public class Bill {
    private string Company { get; }
    private string CompanyAddress { get; }
    private string Customer { get; }
    private string CustomerAddress { get; }
    private IEnumerable<BillRow> Items { get; }
    private int Total { get; }

    public Bill(Order order) {
        Company = "Computer Stuff Inc.";
        CompanyAddress = "A company Address";
        Customer = order.Customer;
        CustomerAddress = order.Address;
        Items = GetItemsAsList(order.GetProductsAssociated(), out var total);
        Total = total;
    }

    public ReadBillDto ToReadDto() {
        return new ReadBillDto(Company, CompanyAddress, Customer, CustomerAddress, Items, Total);
    }

    private IEnumerable<BillRow> GetItemsAsList(Dictionary<Product, int> itemsAssociated, out int total) {
        var summarizedProducts = new List<BillRow>();
        total = 0;
        foreach (var item in itemsAssociated) {
            var currentItemValue = item.Value * item.Key.Value;
            summarizedProducts.Add(new BillRow (
                item.Value + " x "+item.Key.Name+"",
                currentItemValue
            ));
            total += currentItemValue;
        }
        return summarizedProducts;
    }
}