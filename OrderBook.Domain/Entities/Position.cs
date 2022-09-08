using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Domain.Entities;

public class Position
{

    public Position(int positionId, uint quantity, Stock stock)
    {
        PositionId = positionId;
        Quantity   = quantity;
        Stock      = stock;
    }

    public int PositionId { get; set; }

    public uint Quantity { get; set; }

    public Stock Stock { get; set; } = null!;

}
