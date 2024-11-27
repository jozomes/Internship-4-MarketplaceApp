using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models.Enums;
namespace Marketplace.Data.Models
{
    public class Product
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Seller Seller { get; set; }
        public bool IsSold { get; private set; }
        public (int,double) averageReview { get; set; }
        public ProductCategory Category { get; set; }
        public Product(string name, string desc, double price, Seller seller, ProductCategory category) { 
            Id = Guid.NewGuid();
            Name = name;
            Description = desc;
            Price = price;
            Seller = seller;
            IsSold = false;
            averageReview = (0, 0);
            Category = category;
        }

        public void ProductSold() {
            if (IsSold) return;
            else IsSold = true;
        }
        public void ProductReturned() {
            if (!IsSold) return;
            else IsSold = false;
        }



    }

}
