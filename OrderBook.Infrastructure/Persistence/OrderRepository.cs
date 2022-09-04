using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Application.Persistence;
using OrderBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly DbContext _context = null!;
    public OrderRepository(DbContext context) : base(context)
    {
    }
}
