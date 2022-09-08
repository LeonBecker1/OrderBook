using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OrderBook.Application.Persistence;
using OrderBook.Application.Services.MatchingService;

namespace OrderBook.Application;

public static class DependenyInjector
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMatchingEngine, MatchingEngine>();
        services.AddScoped<IMatchingService, MatchingService>();
        return services;
    }

}
