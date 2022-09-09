using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence.Models;

public partial class PortfolioModel
{

   public PortfolioModel(int portfolioId, ICollection<PositionModel>? positions)
    {
        PortfolioId = portfolioId;
        Positions   = positions;
    }

    [Key]
    [Column("Portfolio_Id")]
    public int PortfolioId { get; set; }


    [ForeignKey("PortfolioFK")]
    public ICollection<PositionModel>? Positions { get; set; }

}
