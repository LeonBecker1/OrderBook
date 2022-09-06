using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Application.Persistence;

public interface IUnitofWork : IDisposable
{
    IOrderRepository Orders { get; }
    IUserRepository Users { get; }
    IStockRepository Stocks { get; }
    IPortfolioRepository Portfolios { get; }
    ISaleRepository Sales { get; }

    int Complete();

}
