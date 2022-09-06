using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence.Models;

public partial class OrderModel
{
    
    public OrderModel(int orderId, bool isBuyOrder, decimal price, uint quantity, StockModel underlying, UserModel issuer)
    {
        OrderId     = orderId;
        IsBuyOrder  = isBuyOrder;
        Price       = price;
        Quantity    = quantity;
        Underlying  = underlying;
        Issuer      = issuer;
    } 

    [Key]
    [Column("Order_Id")]
    public int OrderId { get; set; }

    [Required]
    [Column("Is_Buy_Order", TypeName = "BIT")]
    public bool IsBuyOrder { get; set; }

    [Required]
    [Column("Price", TypeName = "decimal(6,2)")]
    public decimal Price { get; set; }

    [Required]
    [Column("Quantity")]
    public uint Quantity { get; set; }


    [Required]
    [Column("Issuer")]
    public UserModel Issuer { get; set; } = null!;

    [Required]
    [Column("Underlying")]
    public StockModel Underlying { get; set; } = null!;
}
