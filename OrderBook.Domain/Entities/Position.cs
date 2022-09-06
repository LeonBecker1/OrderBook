using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Domain.Entities;

public class Position
{
    public int PositionId { get; set; }

    public uint Quantity { get; set; }

    public Stock Stock { get; set; } = null!;

    public Portfolio Portfolio { get; set; } = null!;
}
