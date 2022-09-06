using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderBook.Infrastructure.Persistence.Models;

namespace OrderBook.Infrastructure.Persistence;

public class OrderBookDBContext : DbContext
{
    public DbSet<OrderModel> Orders { get; set; } = null!;

    public DbSet<UserModel>  Users  { get; set; } = null!;

    public DbSet<StockModel> Stocks { get; set; } = null!;

    public DbSet<SaleModel> Sales   { get; set; } = null!;

    public DbSet<PortfolioModel> Portfolios { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Data Source=LEON-PC\SQLEXPRESS; Initial Catalog=OrderBookDB;Integrated Security=True;");
    }

}
