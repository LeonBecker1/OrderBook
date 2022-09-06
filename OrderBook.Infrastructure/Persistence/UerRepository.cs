using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderBook.Application.Persistence;
using OrderBook.Domain.Entities;
using OrderBook.Infrastructure.Persistence.Models;

namespace OrderBook.Infrastructure.Persistence;

public class UserRepository : Repository<User>, IUserRepository

{
    private readonly DbContext _context = null!;

    public UserRepository(DbContext context) : base(context)
    {
    }

    
    public async Task<User> AddNewUser(User user)
    {   
        PortfolioModel portfolioModel = new PortfolioModel(user.UserId);
        UserModel userModel = new UserModel(user.UserId, user.UserName, user.Balance, user.Password, null, portfolioModel);

        await _context.Set<UserModel>().AddAsync(userModel);

        return user;
    } 
}
