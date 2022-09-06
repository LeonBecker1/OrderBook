﻿using System;
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
    
    public async Task<Position> AddPosition(Position position)
    {
        PortfolioModel portfolioModel = _context.Set<PortfolioModel>().Find(position.Portfolio.PortfolioId)!;
        StockModel stockModel = _context.Set<StockModel>().Find(position.Stock.StockId)!;
        PositionModel positionModel = new PositionModel(position.PositionId, position.Quantity, stockModel, portfolioModel);

        _context.Set<PositionModel>().Add(positionModel);
        await _context.SaveChangesAsync();
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

    public async Task<Position> RemovePosition(Position position)
    {
        PositionModel positionModel = _context.Set<PositionModel>().Find(position.PositionId)!;
        _context.Set<PositionModel>().Remove(positionModel);

        await _context.SaveChangesAsync();
        return position;
    } 

}
