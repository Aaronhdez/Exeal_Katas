using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrdersWebApi.Infrastructure;

namespace OrdersWebApi.Tests;

public class OrdersApi : WebApplicationFactory<Program> {
    private readonly IClock? _clock;
    private readonly IGuidGenerator _idGenerator;

    public OrdersApi(IClock? clock, IGuidGenerator idGenerator) {
        _clock = clock;
        _idGenerator = idGenerator;
    }

    protected override IHost CreateHost(IHostBuilder builder) {
        builder.ConfigureServices(services => {
            services.AddSingleton(_clock);
            services.AddSingleton(_idGenerator);
            //services.AddSingleton<IOrderRepository, InMemoryOrdersRepository>();
            //services.AddScoped<CreateOrderCommand>();
        });

        return base.CreateHost(builder);
    }
}