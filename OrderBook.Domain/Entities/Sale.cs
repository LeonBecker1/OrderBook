using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Domain.Entities;

public class Sale
{

   
    public Sale(int saleId, DateTime executionTime, Stock underlying, User buyer, User seller)
    {
        SaleId        = saleId;
        ExecutionTime = executionTime;
        Underlying    = underlying;
        Buyer         = buyer;
        Seller        = seller;
    }

    public int SaleId { get; set; }
    public DateTime ExecutionTime { get; set; }
    public Stock Underlying { get; set; } = null!;
    public User Buyer  { get; set; } = null!;
    public User Seller { get; set; } = null!;
    
}
