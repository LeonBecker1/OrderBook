﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Infrastructure.Authentication;

public interface IPasswordverifyer
{
    bool passWordIsValid(byte[] password);
}
