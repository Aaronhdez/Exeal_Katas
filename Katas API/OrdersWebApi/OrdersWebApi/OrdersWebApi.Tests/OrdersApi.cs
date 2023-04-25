﻿using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace OrdersWebApi.Tests;

public class OrdersApi : WebApplicationFactory<Program>
{
    private readonly IClock _clock;
    
    public OrdersApi(IClock clock)
    {
        _clock = clock;
    }
    
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            //services.AddSingleton(_clock);
            //services.AddSingleton<IOrderRepository, InMemoryOrdersRepository>();
            //services.AddScoped<CreateOrderCommand>();
        });
    
        return base.CreateHost(builder);
    }
}