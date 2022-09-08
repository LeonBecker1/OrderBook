using OrderBook.Application.Persistence;
using OrderBook.Domain.Entities;
using System;   
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        MatchandExecuteOrders(buyOrders, sellOrders);        
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

    private void MatchandExecuteOrders(List<Order> buyOrders, List<Order> sellOrders)
    {
        while (buyOrders[0].Price >= sellOrders[0].Price)
        {
            decimal buyerDelta = buyOrders[0].Price;
            decimal sellerDelta = sellOrders[0].Price;

            if (buyOrders[0].Quantity > sellOrders[0].Quantity)
            {
                _unitofWork.Orders.EditOrder(buyOrders[0],
                                             buyOrders[0].Quantity - sellOrders[0].Quantity);

                buyOrders[0].Quantity -= sellOrders[0].Quantity;

                _unitofWork.Orders.DeleteOrder(sellOrders[0]);

                buyerDelta *= sellOrders[0].Quantity;
                sellerDelta *= sellOrders[0].Quantity;
            }

            else if (buyOrders[0].Quantity < sellOrders[0].Quantity)
            {
                _unitofWork.Orders.EditOrder(sellOrders[0],
                                             sellOrders[0].Quantity - buyOrders[0].Quantity);

                sellOrders[0].Quantity -= buyOrders[0].Quantity;

                _unitofWork.Orders.DeleteOrder(buyOrders[0]);

                buyerDelta *= buyOrders[0].Quantity;
                sellerDelta *= buyOrders[0].Quantity;
            }

            User buyer = buyOrders[0].Issuer;
            buyer.Balance -= buyerDelta;
            User seller = sellOrders[0].Issuer;
            seller.Balance -= sellerDelta;

            _unitofWork.Users.EditBalance(buyer);
            _unitofWork.Users.EditBalance(seller);

            Sale sale = new Sale(0, DateTime.UtcNow, buyOrders[0].Underlying, buyer, seller);
            _unitofWork.Sales.AddSale(sale);
        }
    }
}
