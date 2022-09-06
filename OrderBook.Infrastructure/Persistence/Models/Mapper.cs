using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Domain.Entities;
using OrderBook.Infrastructure.Persistence.Models;

namespace OrderBook.Infrastructure.Persistence.Models;

public class Mapper
{
    /*
    public static OrderModel Map(Order order)
    {
        UserModel userModel   = Map(order.Issuer);
        StockModel stockModel = Map(order.Underlying);

        OrderModel orderModel = new OrderModel(order.OrderId, order.IsBuyOrder, order.Price, order.Underlying.StockId,
                                               order.Issuer.UserId, userModel, stockModel);
        return orderModel;
    }

    public static OrderModel Map(Order order, User user)
    {
        OrderModel orderModel = new OrderModel(order.OrderId, order.IsBuyOrder, order.Price, order.Underlying.StockId,
                                               order.Issuer.UserId, user, Map(order.Underlying));
        return orderModel;
    }

    public static UserModel Map(User user)
    {
        UserModel userModel = new UserModel(user.)
    }

    public static StockModel Map(Stock stock)
    {
        StockModel stockModel = new StockModel(stock.StockId, stock.Abreviation, )
    }

    public static PortfolioModel Map(Portfolio portfolio)
    {

    } */
     
}
