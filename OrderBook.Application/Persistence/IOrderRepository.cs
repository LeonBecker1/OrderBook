using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Domain.Entities;

namespace OrderBook.Application.Persistence;

public interface IOrderRepository : IRepository<Order>
{

    Task<Order> AddOrder(Order order);
    Task<Order> EditOrder(Order order, uint quantity);
    Task<Order> DeleteOrder(Order order);
    Task<List<Order>> FindByUnderlying(Stock stock);
    List<Order> FindByUnderlying(String abreviation);
    List<Order> FindByUser(String username);
}
