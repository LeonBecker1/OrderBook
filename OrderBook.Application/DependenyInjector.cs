﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OrderBook.Application.Persistence;

namespace OrderBook.Application;

public static class DependenyInjector
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }

}
