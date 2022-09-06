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

namespace OrderBook.Infrastructure;

public static class DependenyInjector
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<DbContext, OrderBookDBContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPortfolioRepository, PortfolioRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<IAuthenticationservice, AuthenticationService>();
        services.AddScoped<IPasswordverifyer, PasswordVerifyer>();
        return services;
    }

}