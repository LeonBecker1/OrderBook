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

    
    public async Task<User> AddUser(User user)
    {
        List<PositionModel> positions = new List<PositionModel>();
        PortfolioModel portfolioModel = new PortfolioModel(user.UserId, positions);
        UserModel           userModel = new UserModel(user.UserId, user.UserName, user.Balance, user.Password, null!,
                                                      portfolioModel, portfolioModel.PortfolioId);

        await _context.Set<UserModel>().AddAsync(userModel);

        return user;
    }

    public async Task<User> EditBalance(User user)
    {
        UserModel userModel = _context.Set<UserModel>().Find(user.UserId)!;
        _context.Set<UserModel>().Remove(userModel);

        userModel.Balance = user.Balance;
        _context.Set<UserModel>().Add(userModel);

        await _context.SaveChangesAsync();
        return user;
    }
}
