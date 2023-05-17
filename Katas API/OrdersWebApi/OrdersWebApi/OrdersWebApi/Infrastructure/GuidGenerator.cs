namespace OrdersWebApi.Infrastructure;

public class GuidGenerator : IGuidGenerator {
    public Guid NewId() {
        return Guid.NewGuid();
    }
}