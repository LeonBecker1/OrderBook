using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Application.Persistence;
using OrderBook.Domain.Entities;
using OrderBook.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace OrderBook.Infrastructure.Persistence;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    
    private readonly DbContext _context = null!;
    public OrderRepository(DbContext context) : base(context)
    {
    }
    
    public async Task<Order> AddOrder(Order order)
    {
        UserModel  userModel  = _context.Set<UserModel>().Find(order.Issuer.UserId)!;
        StockModel stockModel = _context.Set<StockModel>().Find(order.Underlying.StockId)!;
        OrderModel orderModel = new OrderModel(order.OrderId, order.IsBuyOrder, order.Price, order.Quantity, stockModel, userModel);

        await _context.Set<OrderModel>().AddAsync(orderModel);
        return order;
    }

    public async Task<Order> RemoveOrder(int orderId)
    {
        OrderModel orderModel = _context.Set<OrderModel>().Find(orderId)!;
        _context.Set<OrderModel>().Remove(orderModel);
        await _context.SaveChangesAsync();

        return null!;
    }

    public async Task<Order> EditOrder(Order order, uint quantity)
    {
        OrderModel orderModel = _context.Set<OrderModel>().Find(order.OrderId)!;
        _context.Set<OrderModel>().Remove(orderModel);

        order.Quantity = quantity;
        _context.Set<OrderModel>().Add(orderModel);

        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<List<Order>> FindByUnderlying(Stock stock)
    {

        StockModel stockModel = _context.Set<StockModel>().Find(stock.StockId)!;

        List<Order> orderList = new List<Order>();
        List<OrderModel> orderModels = _context.Set<OrderModel>().Where(om => om.Underlying == stockModel).ToList();

        foreach(OrderModel orderModel in orderModels)
        {
            orderList.Add(new Order(orderModel.OrderId, orderModel.IsBuyOrder, orderModel.Price, orderModel.Quantity, stock, null!));
        }

        await _context.SaveChangesAsync();
        return orderList;

    }

    public List<Order> FindByUnderlying(String abreviation)
    {
        StockModel stockModel = _context.Set<StockModel>().First(s => s.Abreviation == abreviation);

        Stock stock = new Stock(stockModel.StockId, stockModel.Abreviation);

        List<Order> orderList = new List<Order>();
        List<OrderModel> orderModels = _context.Set<OrderModel>().Where(om => om.Underlying == stockModel).ToList();

        foreach (OrderModel orderModel in orderModels)
        {
            orderList.Add(new Order(orderModel.OrderId, orderModel.IsBuyOrder, orderModel.Price, orderModel.Quantity, stock, null!));
        }

      
        return orderList;
    }

    public List<Order> FindByUser(String username)
    {
        throw new NotImplementedException();
    }

    public async Task<Order> DeleteOrder(Order order)
    {
        OrderModel orderModel = _context.Set<OrderModel>().Find(order.OrderId)!;
        _context.Set<OrderModel>().Remove(orderModel);
        await _context.SaveChangesAsync();

        return order;
    }

    public Task<Order> RemoveOrder(Order order)
    {
        throw new NotImplementedException();
    }
}
