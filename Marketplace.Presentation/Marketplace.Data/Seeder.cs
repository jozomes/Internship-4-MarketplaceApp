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
            Buyer buyer1 = new Buyer("Jozo", "jmestrovi@pmfst.hr", 1000);
            Buyer buyer2 = new Buyer("Mate", "mgadza@pmfst.hr", 250);
            Seller seller1 = new Seller("Šime", "sjadrijev@pmfst.hr");
            Seller seller2 = new Seller("Marin", "mjovanov@pmfst.hr");
            Product product1 = new Product("BasketBall", "A ball to play basketball with", 49.99, seller1, ProductCategory.Sports);
            Product product2 = new Product("Fridge", "High end fridge", 499.99, seller2, ProductCategory.Electronics);
            Product product3 = new Product("Shirt", "High end clothing", 150, seller2, ProductCategory.Clothes);
            Product product4 = new Product("Football", "A durable football for outdoor play", 29.99, seller1, ProductCategory.Sports);
            Product product5 = new Product("Smartphone", "Latest model with cutting-edge features", 899.99, seller2, ProductCategory.Electronics);
            Product product6 = new Product("Jeans", "Comfortable and stylish denim jeans", 75.00, seller1, ProductCategory.Clothes);
            Product product7 = new Product("Tennis Racket", "Lightweight racket for professional play", 79.99, seller1, ProductCategory.Sports);
            Product product8 = new Product("Laptop", "High-performance laptop for gaming and work", 1299.99, seller2, ProductCategory.Electronics);
            Product product9 = new Product("Jacket", "Warm and waterproof winter jacket", 120.00, seller1, ProductCategory.Clothes);
            Transaction transaction1 = new(product1, seller1, buyer1);
            Transaction transaction2 = new(product2, seller2, buyer2);
            Transaction transaction3 = new(product3, seller2, buyer2);
            Transaction transaction4 = new(product4, seller1, buyer2);
            Transaction transaction5 = new(product6, seller1, buyer2);
            Transaction transaction6 = new(product7, seller1, buyer1);
            Transaction transaction7 = new(product9, seller1, buyer1);
            Transaction transaction8 = new(product5, seller2, buyer2, DateTime.Now.AddMonths(-7));
            Transaction transaction9 = new(product8, seller2, buyer2, DateTime.Now.AddMonths(-2));
            Promocode electronics = new Promocode("ELEKTRO10", ProductCategory.Electronics, 0.9, DateTime.Now.AddDays(7), "10%");
            Promocode sports = new Promocode("SPORTY20", ProductCategory.Sports, 0.8, DateTime.Now.AddDays(5), "20%");
            MarketPlace.promocodes.Add(electronics);
            MarketPlace.promocodes.Add(sports);
            buyer1.BoughtProducts.Add(product1);
            buyer2.BoughtProducts.Add(product2);
            product1.ProductSold();
            product2.ProductSold();
            seller1.AllProducts.Add(product1);
            seller2.AllProducts.Add(product2);
            seller2.AllProducts.Add(product3);
            seller2.AllProducts.Add(product5);
            seller2.AllProducts.Add(product8);
            seller1.AllProducts.Add(product4);
            seller1.AllProducts.Add(product6);
            seller1.AllProducts.Add(product7);
            seller1.AllProducts.Add(product9);

            MarketPlace.users.Add(buyer1);
            MarketPlace.users.Add(buyer2);
            MarketPlace.users.Add(seller1);
            MarketPlace.users.Add(seller2);
            MarketPlace.products.Add(product1);
            MarketPlace.products.Add(product2);
            MarketPlace.products.Add(product3);
            MarketPlace.products.Add(product4);
            MarketPlace.products.Add(product5);
            MarketPlace.products.Add(product6);
            MarketPlace.products.Add(product7);
            MarketPlace.products.Add(product8);
            MarketPlace.products.Add(product9);
            MarketPlace.transactions.Add(transaction1);
            MarketPlace.transactions.Add(transaction2);
            MarketPlace.transactions.Add(transaction3);
            MarketPlace.transactions.Add(transaction4);
            MarketPlace.transactions.Add(transaction5);
            MarketPlace.transactions.Add(transaction6);
            MarketPlace.transactions.Add(transaction7);
            MarketPlace.transactions.Add(transaction8);
            MarketPlace.transactions.Add(transaction9);
        }



    }
}
