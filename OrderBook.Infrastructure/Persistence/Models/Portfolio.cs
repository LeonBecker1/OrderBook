using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence.Models;

public partial class Portfolio
{
    [Key]
    [Column("Portfolio_ID")]
    public int PortfolioId { get; set; }
    [Column("User_")]
    public int User { get; set; }
    public int Stock { get; set; }

    [ForeignKey("Stock")]
    [InverseProperty("Portfolios")]
    public virtual Stock StockNavigation { get; set; } = null!;
    [ForeignKey("User")]
    [InverseProperty("Portfolios")]
    public virtual User UserNavigation { get; set; } = null!;
}
