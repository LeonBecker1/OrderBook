using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Domain.Entities;

public class Portfolio
{
    public int PortfolioId { get; set; }
    public User User { get; set; } = null!;
    public List<Position>? Positions { get; set; }
}
