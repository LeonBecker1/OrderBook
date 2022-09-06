using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Application.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence;

public class UnitofWork : IUnitofWork
{
    private readonly DbContext _context = null!;

    public UnitofWork(DbContext context)
    {
        _context = context;

        Orders      = new OrderRepository(_context);
        Users       = new UserRepository(_context);
        Stocks      = new StockRepository(_context);
        Portfolios  = new PortfolioRepository(_context);
    }

    public IOrderRepository Orders { get; private set; }    

    public IUserRepository Users   { get; private set; }

    public IStockRepository Stocks { get; private set; }

    public IPortfolioRepository Portfolios { get; private set; }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
