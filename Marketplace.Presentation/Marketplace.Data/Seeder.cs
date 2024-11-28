using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models;
using Marketplace.Data.Models.Enums;

namespace Marketplace.Data
{
    public static class Seeder
    {

        public static void AddStartElements() {
            Buyer buyer1 = new Buyer("Jozo", "jmestrovi@pmfst.hr", 100);
            Buyer buyer2 = new Buyer("Mate", "mgadza@pmfst.hr", 250);
            Seller seller1 = new Seller("Šime", "sjadrijev@pmfst.hr");
            Seller seller2 = new Seller("Marin", "mjovanov@pmfst.hr");
            Product product1 = new Product("BasketBall", "A ball to play basketball with", 49.99, seller1, ProductCategory.Sports);
            Product product2 = new Product("Fridge", "High end fridge", 499.99, seller2, ProductCategory.Electronics);
            Product product3 = new Product("Shirt", "High end clothing", 150, seller2, ProductCategory.Clothes);
            Transaction transaction1 = new(product1, seller1, buyer1);
            Transaction transaction2 = new(product2, seller2, buyer2);
            buyer1.BoughtProducts.Add(product1);
            buyer2.BoughtProducts.Add(product2);
            product1.ProductSold();
            product2.ProductSold();
            seller1.AllProducts.Add(product1);
            seller2.AllProducts.Add(product2);
            seller2.AllProducts.Add(product3);
            MarketPlace.users.Add(buyer1);
            MarketPlace.users.Add(buyer2);
            MarketPlace.users.Add(seller1);
            MarketPlace.users.Add(seller2);
            MarketPlace.products.Add(product1);
            MarketPlace.products.Add(product2);
            MarketPlace.products.Add(product3);
            MarketPlace.transactions.Add(transaction1);
            MarketPlace.transactions.Add(transaction2);
        }



    }
}
