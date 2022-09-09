using OrderBook.Application.Persistence;
using OrderBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Application.Services.OrderPlacementService;

public class OrderPlacementService : IOrderPlacementService
{

    private readonly IUnitofWork _unitofWork;

    public OrderPlacementService(IUnitofWork unitofWork)
    {
        _unitofWork = unitofWork;
    }

    public async Task<Order> PlaceOrder(Order order)
    {
        return await _unitofWork.Orders.AddOrder(order);
    }
}
