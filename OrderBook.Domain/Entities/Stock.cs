using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Domain.Entities;

public class Stock
{
    public Stock(int stockId, string abreviation)
    {
        StockId     = stockId;
        Abreviation = abreviation;
    }

    public int StockId { get; set; }
    public string Abreviation { get; set; } = null!;

}
