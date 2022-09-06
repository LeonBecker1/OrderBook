using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public byte[] Password { get; set; } = null!;
    public decimal Balance { get; set; }
    public List<Order>? Orders { get; set; }
    public Portfolio Portfolio { get; set; } = null!;

}
