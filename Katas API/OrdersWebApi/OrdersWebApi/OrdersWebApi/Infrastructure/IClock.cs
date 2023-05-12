namespace OrdersWebApi.Infrastructure;

public interface IClock {
    DateTime Timestamp();
}