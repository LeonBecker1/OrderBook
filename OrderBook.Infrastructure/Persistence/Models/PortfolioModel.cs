using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence.Models;

public partial class PortfolioModel
{

    /* public PortfolioModel(int portfolioId, UserModel user, ICollection<PositionModel> positions)
    {
        PortfolioId = portfolioId;
        User        = user;
        Positions   = positions;
    } */

    [Key]
    [Column("Portfolio_Id")]
    public int PortfolioId { get; set; }

    public ICollection<PositionModel>? Positions { get; set; }
}
