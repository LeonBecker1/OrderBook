using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence.Models;

public partial class PortfolioModel
{

    public PortfolioModel(int portfolioId)
    {
        PortfolioId = portfolioId;
    }

  

    [Key]
    [Column("Portfolio_Id")]
    public int PortfolioId { get; set; }

}
