using Microsoft.Extensions.DependencyInjection;
using OrderBook.Application.Persistence;
using OrderBook.Infrastructure.Persistence;
using OrderBook.Infrastructure.Authentication;
using OrderBook.Application.Services.AuthenticationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderBook.Infrastructure.Options;
using OrderBook.Application.Services.OrderPlacementService;
using OrderBook.Application.Services.MatchingService;

namespace OrderBook.Infrastructure;

public static class DependenyInjector
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
    {
        services.Configure<PasswordOptions>(config.GetSection("PasswordSettings"));
        services.AddScoped<PasswordOptions>();
        services.AddDbContext<OrderBookDBContext>();
        services.AddScoped<DbContext, OrderBookDBContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPortfolioRepository, PortfolioRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<IPasswordverifyer, PasswordVerifyer>();
        services.AddScoped<IAuthenticationservice, AuthenticationService>();
        services.AddScoped<IUnitofWork, UnitofWork>();
        services.AddScoped<IOrderPlacementService, OrderPlacementService>();
        services.AddScoped<IMatchingEngine, MatchingEngine>();
        services.AddScoped<IMatchingService, MatchingService>();


        return services;
    }

}