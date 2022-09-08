using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Domain.Entities;

public class Order
{

    public Order(int orderId, bool isBuyOrder, decimal price, uint quantity, Stock underlying, User issuer)
    {
        OrderId     = orderId;
        IsBuyOrder  = isBuyOrder;
        Price       = price;
        Quantity    = quantity;
        Underlying  = underlying;
        Issuer      = issuer;
    }

    public int OrderId { get; set; }
    public bool IsBuyOrder { get; set; }
    public decimal Price { get; set; }
    public uint Quantity { get; set; }
    public Stock Underlying { get; set; } = null!;
    public User Issuer { get; set; } = null!;

}
