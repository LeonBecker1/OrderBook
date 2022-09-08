using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Domain.Entities;

namespace OrderBook.Application.Persistence;

public interface IPositionRepository : IRepository<Position>
{
    Task<Position> AddPosition(Position position, int portfolioId);
    Task<Position> EditPosition(Position position, uint quantity);
    Task<Position> DeletePosition(Position position);
}
