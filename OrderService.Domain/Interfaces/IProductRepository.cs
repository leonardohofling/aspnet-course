﻿using OrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Interfaces
{
    public interface IProductRepository
    {
        Product GetProduct(string productId);
    }
}
