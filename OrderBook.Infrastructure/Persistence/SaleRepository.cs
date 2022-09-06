using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Domain.Entities;
using OrderBook.Application.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence;

public class SaleRepository : Repository<Sale>, ISaleRepository
{
    private readonly DbContext _context = null!;

    public SaleRepository(DbContext context) : base(context)
    {
    }


}
