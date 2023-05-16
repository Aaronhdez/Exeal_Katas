using MediatR;
using OrdersWebApi.Orders;

namespace OrdersWebApi.Bills.Queries; 

public class GetBillByOrderIdQueryHandler : IRequestHandler<GetBillByOrderIdQuery, ReadBillDto> {
    
    private readonly IOrderRepository _ordersRepository;

    public GetBillByOrderIdQueryHandler(IOrderRepository ordersRepository) {
        _ordersRepository = ordersRepository;
    }
    
    public Task<ReadBillDto> Handle(GetBillByOrderIdQuery request, CancellationToken cancellationToken) {
        //Recuperar el pedido
        var order = _ordersRepository.GetById(request.Id).Result;
        
        //Recuperar los productos resumidos
        var itemsAssociated = new Dictionary<Product,int>();
        foreach (var item in order.Products) {
            if (itemsAssociated.ContainsKey(item)) {
                itemsAssociated[item] += 1;
            }
            else { 
                itemsAssociated.Add(item,1);
            }
        }
        //Crear el DTO
        var bill = new ReadBillDto {
            Company = "Computer Stuff Inc.",
            CompanyAddress = "A company Address",
            Customer = order.Customer,
            CustomerAddress = order.Address,
            Items = GetItemsAsList(itemsAssociated, out var total),
            Total = total
        };
        return Task.FromResult(bill);
    }

    private IEnumerable<BillRow> GetItemsAsList(Dictionary<Product, int> itemsAssociated, out int total) {
        var summarizedProducts = new List<BillRow>();
        total = 0;
        foreach (var item in itemsAssociated) {
            var currentItemValue = item.Value * item.Key.Value;
            summarizedProducts.Add(new BillRow {
                Concept = item.Value + " x "+item.Key.Name+"",
                Value = currentItemValue,
            });
            total += (int) currentItemValue;
        }
        return summarizedProducts;
    }
}