﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBook.Domain.Entities;

namespace OrderBook.Application.Persistence;

public interface IPositionRepository : IRepository<Position>
{
}
