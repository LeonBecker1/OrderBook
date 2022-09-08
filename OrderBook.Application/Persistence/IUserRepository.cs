using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Domain.Entities;


namespace OrderBook.Application.Persistence;

public interface IUserRepository : IRepository<User>
{
    Task<User> AddUser(User user);
    Task<User> EditBalance(User user);
    byte[] GetUserPassword(string userName);
    bool HasUser(string userName);
}
