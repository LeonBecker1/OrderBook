using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderBook.Infrastructure.Persistence.Models;

public class StockModel
{
    public StockModel(int stockId, string abreviation)
    {
        StockId     = stockId;
        Abreviation = abreviation;
    } 

    [Key]
    [Column("Stock_Id")]
    public int StockId { get; set; }


    [Column("Abreviation", TypeName = "Varchar(8)")]
    public string Abreviation { get; set; } = null!;

}
