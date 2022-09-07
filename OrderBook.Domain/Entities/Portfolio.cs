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
    public Portfolio(int portfolioId, List<Position>? positions)
    {
        PortfolioId = portfolioId;
        Positions = positions;
    }

    public Portfolio(int portfolioId)
    {
        PortfolioId = portfolioId;
    }

    public int PortfolioId { get; set; }
    public List<Position>? Positions { get; set; }
}
