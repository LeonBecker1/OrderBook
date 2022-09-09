using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Domain.Entities;

namespace OrderBook.Application.Services.OrderPlacementService;

public interface IOrderPlacementService
{
    Task<Order> PlaceOrder(Order order);
}
