using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Domain.Entities;

public class User
{

    public User(int userId, string userName, byte[] password, decimal balance, List<Order>? orders, Portfolio portfolio, List<Position>? positions)
    {
        UserId = userId;
        UserName = userName;
        Password = password;
        Balance = balance;
        Orders = orders;
        Portfolio = portfolio;
        Positions = positions;
    }

    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public byte[] Password { get; set; } = null!;
    public decimal Balance { get; set; }
    public List<Order>? Orders { get; set; }
    public Portfolio Portfolio { get; set; } = null!;
    public List<Position>? Positions { get; set; }

}
