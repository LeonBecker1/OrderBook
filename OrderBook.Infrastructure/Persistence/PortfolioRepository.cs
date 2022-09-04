using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using OrderBook.Application.Persistence;

namespace OrderBook.Infrastructure.Persistence;

public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
{
    public PortfolioRepository(DbContext context) : base(context)
    {
    }
}