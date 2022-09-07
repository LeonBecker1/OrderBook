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

<<<<<<< HEAD

=======
    [ForeignKey("PortfolioFK")]
>>>>>>> 0cb5a0790e60701dd6266b032bae49203292a4c4
    public ICollection<PositionModel>? Positions { get; set; }

}
