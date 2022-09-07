using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using OrderBook.Application.Persistence;
using OrderBook.Infrastructure.Persistence.Models;

namespace OrderBook.Infrastructure.Persistence;

public class StockRepository : Repository<Stock>, IStockRepository
{
    private readonly DbContext _context;
    public StockRepository(DbContext context) : base(context)
    {
    }

    public async Task<List<Stock>> GetAll()
    {
        List<StockModel> stockModels = _context.Set<StockModel>().ToList();

        List<Stock> stocks = new List<Stock>();
        
        foreach(StockModel stockModel in stockModels)
        {
            stocks.Add(new Stock(stockModel.StockId, stockModel.Abreviation));
        }

        await _context.SaveChangesAsync();

        return stocks;

    }

}
