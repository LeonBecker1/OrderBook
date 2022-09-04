using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderBook.Application.Persistence;
using OrderBook.Domain.Entities;

namespace OrderBook.Infrastructure.Persistence;

public class UerRepository : Repository<User>, IUserRepository

{
    private readonly DbContext _context = null!;

    public UerRepository(DbContext context) : base(context)
    {
    }
}
