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

    public SaleModel(int saleId, DateTime executionTime, StockModel underlying, UserModel buyer, int buyerFk, UserModel seller, int sellerFk)
    {
        SaleId          = saleId;
        ExecutionTime   = executionTime;
        Underlying      = underlying;
        Buyer           = buyer;
        BuyerFk         = buyerFk;
        Seller          = seller;
        SellerFk        = sellerFk;
    }

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

    [ForeignKey("Buyer")]
    public int BuyerFk { get; set; }

    [Required]
    public UserModel Seller { get; set; } = null!;

    [ForeignKey("Seller")]
    public int SellerFk { get; set; }
}
