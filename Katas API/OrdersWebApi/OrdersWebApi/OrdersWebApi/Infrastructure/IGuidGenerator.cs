namespace OrdersWebApi.Infrastructure;

public interface IGuidGenerator {
    Guid NewId();
}