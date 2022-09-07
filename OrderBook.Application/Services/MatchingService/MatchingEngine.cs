using OrderBook.Application.Persistence;
using OrderBook.Domain.Entities;
using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderBook.Application.Services.MatchingService;

public class MatchingEngine : IMatchingEngine
{

    public readonly IUnitofWork _unitofWork;

    public MatchingEngine(IUnitofWork unitofWork)
    {
        _unitofWork = unitofWork;
    }

    public void Match(List<Order> orders)
    {

        (List<Order> buyOrders, List<Order> sellOrders) = SortAndSeperateOdersByType(orders);


        while (buyOrders[0].Price >= sellOrders[0].Price)
        {
            if (buyOrders[0].Quantity > sellOrders[0].Quantity)
            {
                _unitofWork.Orders.EditOrder(buyOrders[0],
                                             buyOrders[0].Quantity - sellOrders[0].Quantity);

                buyOrders[0].Quantity -= sellOrders[0].Quantity;

                _unitofWork.Orders.DeleteOrder(sellOrders[0]);
                
            }

            else if (buyOrders[0].Quantity < sellOrders[0].Quantity)
            {
                _unitofWork.Orders.EditOrder(sellOrders[0],
                                             sellOrders[0].Quantity - buyOrders[0].Quantity);

                sellOrders[0].Quantity -= buyOrders[0].Quantity;

                _unitofWork.Orders.DeleteOrder(buyOrders[0]);
            }

            Sale sale = new Sale();
        }
    }

    private (List<Order>, List<Order>) SortAndSeperateOdersByType(List<Order> orders)
    {

        List<Order> buyOrders = new List<Order>();
        List<Order> sellOrders = new List<Order>();

        foreach (Order order in orders)
        {
            if (order.IsBuyOrder)
            {
                buyOrders.Add(order);
            }
            else
            {
                sellOrders.Add(order);
            }

            buyOrders.Sort((x, y) => x.Price.CompareTo(y.Price));

            sellOrders.Sort((x, y) => x.Price.CompareTo(y.Price));
            sellOrders.Reverse();
        }

        return (buyOrders, sellOrders);
    }
}
