using Marketplace.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data.Models
{
    public class Promocode
    {
        public string Code { get;}
        public ProductCategory Category { get;}
        public double DiscountPercentage { get;}
        public DateTime ExpiryDate { get;}
        public string Discount { get; set; }

        public Promocode(string code, ProductCategory category, double discountPercentage, DateTime expiryDate, string discount)
        {
            Code = code;
            Category = category;
            DiscountPercentage = discountPercentage;
            ExpiryDate = expiryDate;
            Discount = discount;
        }
    }
}
