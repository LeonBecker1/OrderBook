using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence.Models;

public partial class Order
{
    [Key]
    [Column("Order_ID")]
    public int OrderId { get; set; }
    [Column("Is_Buy_Order")]
    public bool IsBuyOrder { get; set; }
    [Column(TypeName = "money")]
    public decimal Price { get; set; }
    public int Underlying { get; set; }
    public int? Issuer { get; set; }

    [ForeignKey("Issuer")]
    [InverseProperty("Orders")]
    public virtual User? IssuerNavigation { get; set; }
    [ForeignKey("Underlying")]
    [InverseProperty("Orders")]
    public virtual Stock UnderlyingNavigation { get; set; } = null!;
}
