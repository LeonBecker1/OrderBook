using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Application.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence;

public class Repository<Tentity> : IRepository<Tentity> where Tentity : class
{

    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    
}
