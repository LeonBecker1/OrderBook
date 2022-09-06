using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace OrderBook.Infrastructure.Persistence.Models;

public class SaleModel
{
    [Key]
    [Column("Sale_Id")]
    public int SaleId { get; set; }

    [Required]
    [Column("Execution_Time", TypeName = "Datetime")]
    public DateTime ExecutionTime { get; set; }

    [Required]
    public StockModel Underlying { get; set; } = null!;

    [Required]
    public UserModel Buyer { get; set; } = null!;

    [Required]
    public UserModel Seller { get; set; } = null!;
}
