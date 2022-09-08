using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using OrderBook.Application.Persistence;
using OrderBook.Domain.Entities;

namespace OrderBook.Application.Services.MatchingService;

public class MatchingService : BackgroundService, IMatchingService
{

    private readonly IUnitofWork _unitofWork;

    private readonly IMatchingEngine _matchingEngine;

    public MatchingService(IUnitofWork unitofWork, IMatchingEngine matchingEngine)
    {
        _unitofWork     = unitofWork;
        _matchingEngine = matchingEngine;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);

            foreach(Stock stock in _unitofWork.Stocks.GetAll().Result)
            {
                List<Order> ordersByUnderlying = await _unitofWork.Orders.FindByUnderlying(stock)!;
                await _matchingEngine.Match(ordersByUnderlying);

            }
        }
    }
}
