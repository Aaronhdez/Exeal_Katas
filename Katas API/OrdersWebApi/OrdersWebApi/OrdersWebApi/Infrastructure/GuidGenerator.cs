namespace OrdersWebApi.Infrastructure;

class GuidGenerator : IGuidGenerator {
    public Guid NewId() {
        return Guid.NewGuid();
    }
}