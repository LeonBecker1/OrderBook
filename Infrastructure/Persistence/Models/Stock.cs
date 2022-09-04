using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence.Models;

public partial class Stock
{
    public Stock()
    {
        Orders = new HashSet<Order>();
        Portfolios = new HashSet<Portfolio>();
    }

    [Key]
    [Column("Stock_ID")]
    public int StockId { get; set; }
    [StringLength(8)]
    [Unicode(false)]
    public string Abreviation { get; set; } = null!;

    [InverseProperty("UnderlyingNavigation")]
    public virtual ICollection<Order> Orders { get; set; }
    [InverseProperty("StockNavigation")]
    public virtual ICollection<Portfolio> Portfolios { get; set; }
}
