﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models.Enums;
namespace Marketplace.Data.Models
{
    public static class MarketPlace
    {
        public static List<User > users = new List<User>();
        public static List<Product> products = new List<Product>();
        public static List<Transaction> transactions = new List<Transaction>();

    }
}
