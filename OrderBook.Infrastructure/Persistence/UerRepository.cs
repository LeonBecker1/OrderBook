using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderBook.Application.Persistence;
using OrderBook.Domain.Entities;

namespace OrderBook.Infrastructure.Persistence;

public class UserRepository : Repository<User>, IUserRepository

{
    private readonly DbContext _context = null!;

    public UserRepository(DbContext context) : base(context)
    {
    }
}
