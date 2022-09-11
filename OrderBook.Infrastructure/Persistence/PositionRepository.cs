using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderBook.Domain.Entities;
using OrderBook.Application.Persistence;
using OrderBook.Infrastructure.Persistence.Models;
namespace OrderBook.Infrastructure.Persistence;

public class PositionRepository : Repository<Position>, IPositionRepository
{
    private readonly DbContext _context = null!;

    public PositionRepository(DbContext context) : base(context)
    {

    }
    
    public async Task<Position> AddPosition(Position position, int PortfolioId)
    {
        PortfolioModel  portfolioModel  = _context.Set<PortfolioModel>().Find(PortfolioId)!;
        StockModel      stockModel      = _context.Set<StockModel>().Find(position.Stock.StockId)!;
        PositionModel   positionModel   = new PositionModel(position.PositionId, position.Quantity,
                                                            stockModel, portfolioModel, portfolioModel.PortfolioId);

        await _context.Set<PositionModel>().AddAsync(positionModel);
        return position;
    }

    public async Task<Position> EditPosition(Position position, uint quantity)
    {
        PositionModel positionModel = _context.Set<PositionModel>().Find(position.PositionId)!;
        _context.Set<PositionModel>().Remove(positionModel);
        
        positionModel.Quantity = quantity;
        _context.Set<PositionModel>().Add(positionModel);

        await _context.SaveChangesAsync();
        return position;
    }

    public async Task<Position> DeletePosition(Position position)
    {
        PositionModel positionModel = _context.Set<PositionModel>().Find(position.PositionId)!;
        _context.Set<PositionModel>().Remove(positionModel);

        await _context.SaveChangesAsync();
        return position;
    }  

    public async Task<List<Position>> FindbyPortfolio(Portfolio portfolio)
    {
        List<PositionModel> positions = _context.Set<PositionModel>()
                                                      .Where(p => p.PortfolioFK == portfolio.PortfolioId).ToList();

        List<Position> result = new List<Position>();
        foreach (var position in positions)
        {
            Stock stock = new Stock(position.Stock.StockId, position.Stock.Abreviation);
            result.Add(new Position(position.PositionId, position.Quantity, stock));
        }

        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<List<Position>> FindByUser(string username)
    {
        UserModel userModel = _context.Set<UserModel>().First(u => u.UserName == username);
        PortfolioModel portfolio = _context.Set<PortfolioModel>().First(p => p.PortfolioId == userModel.PortfolioFK);

        List<PositionModel> positions = _context.Set<PositionModel>()
                                                      .Where(p => p.PortfolioFK == portfolio.PortfolioId).ToList();

        List<Position> result = new List<Position>();
        foreach (var position in positions)
        {
            Stock stock = new Stock(position.Stock.StockId, position.Stock.Abreviation);
            result.Add(new Position(position.PositionId, position.Quantity, stock));
        }

        await _context.SaveChangesAsync();

        return result;

    }

}
