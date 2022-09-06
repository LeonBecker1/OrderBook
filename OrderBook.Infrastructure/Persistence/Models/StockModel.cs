using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence.Models;

public class StockModel
{
    /* public StockModel(int stockId, string abreviation, ICollection<OrderModel> orders)
    {
        StockId     = stockId;
        Abreviation = abreviation;
        Orders      = orders;
    } */

    [Key]
    [Column("Stock_Id")]
    public int StockId { get; set; }


    [Column("Abreviation", TypeName = "Varchar(8)")]
    public string Abreviation { get; set; } = null!;

    public ICollection<OrderModel>? Orders { get; set; }
}
