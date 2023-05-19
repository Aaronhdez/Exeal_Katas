using MediatR;
using OrdersWebApi.Orders;
using OrdersWebApi.Products;

namespace OrdersWebApi.Bills.Queries; 

public class GetBillByOrderIdQueryHandler : IRequestHandler<GetBillByOrderIdQuery, ReadBillDto> {
    
    private readonly IOrderRepository _ordersRepository;

    public GetBillByOrderIdQueryHandler(IOrderRepository ordersRepository) {
        _ordersRepository = ordersRepository;
    }
    
    public Task<ReadBillDto> Handle(GetBillByOrderIdQuery request, CancellationToken cancellationToken) {
        var order = _ordersRepository.GetById(request.Id).Result;
        var itemsAssociated = GetItemsAssociated(order);
        return Task.FromResult(CreateReadBillDto(order, itemsAssociated));
    }

    private static Dictionary<Product, int> GetItemsAssociated(Order order) {
        var itemsAssociated = new Dictionary<Product, int>();
        foreach (var item in order.Products) {
            if (itemsAssociated.ContainsKey(item)) {
                itemsAssociated[item] += 1;
            } else {
                itemsAssociated.Add(item, 1);
            }
        }
        return itemsAssociated;
    }

    private ReadBillDto CreateReadBillDto(Order order, Dictionary<Product, int> itemsAssociated) {
        return new ReadBillDto(
            "Computer Stuff Inc.",
            "A company Address",
            order.Customer,
            order.Address,
            GetItemsAsList(itemsAssociated, out var total),
            total
        );
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