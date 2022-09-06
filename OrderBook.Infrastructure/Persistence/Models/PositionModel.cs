using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence.Models;

public class PositionModel
{
    [Key]
    [Column("Position_Id")]
    public int PositionId { get; set; }

    [Required]
    [Column("Quantity")]
    public uint Quantity { get; set; }

    [Required]
    [Column("Stock")]
    public StockModel Stock { get; set; } = null!;


}
