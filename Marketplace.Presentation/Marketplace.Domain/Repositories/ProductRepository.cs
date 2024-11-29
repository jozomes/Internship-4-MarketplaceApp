using Marketplace.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models.Enums;
using Marketplace.Data;
namespace Marketplace.Domain.Repositories
{
    public class ProductRepository
    {
        public string AvailableProductsForSale()
        {
            string s = "";
            foreach (var item in MarketPlace.products)
            {
                if (item.IsSold == false)
                {
                    s += $"id: {item.Id} {item.Name} {item.Price}$ {item.Description} \n";
                }
            }
            return s;
        }
        public Product getProductById(Guid id) {
            Product targeted = null;
            foreach (var item in MarketPlace.products)
            {
                if (item.Id == id)
                {
                    targeted = item;
                    return targeted;

                }
            }
            return targeted;
        }

        public bool CheckIfSold(Product product) {
            if (product.IsSold) return true;
            else return false;

        }
        public string EnoughBalance(Buyer buyer, Product product)
        {
            if (buyer.Balance >= product.Price)
            {
                product.ProductSold();
                buyer.BoughtProducts.Add(product);
                buyer.DeductBalance(product.Price);
                Transaction newTransaction = new Transaction(product, product.Seller,buyer);
                MarketPlace.transactions.Add(newTransaction);
                return "You have bought the product";
            }
            else return "Not enough funds";

        }
        public string ReturnProduct(Buyer buyer, Product product) {
            foreach (var item in buyer.BoughtProducts)
            {
                if (item.Id == product.Id)
                {
                    break;
                }
                return "You cannot return a product you have not bought";
            }
            buyer.BoughtProducts.Remove(product);
            product.ProductReturned();
            buyer.AddBalance(product.Price * 0.8);
            return "Product returned successfully";

        }
        public string AddToFavorite(Buyer buyer, Product product)
        {
            buyer.FavoriteProducts.Add(product);
            return "Successfully added to the list of favorites";
        }

        public string BoughtProducts(Buyer buyer) {
            string s = $"All the bought products of {buyer.Name} \n";
            foreach (var item in buyer.BoughtProducts)
            {
                s += $"{item.Name} {item.Description} {item.Price} {item.Category} + \n";
            }
            return s;
        }
        public string AllFavorites(Buyer buyer) {
            string s = $"All of {buyer.Name}'s favorite products \n";
            foreach (var item in buyer.FavoriteProducts)
            {
                s += $"{item.Name} {item.Description} {item.Price} {item.Category} \n";
            }
            return s;
        }
        public Product NewProduct(Seller seller, string name, string description, double price) {
            Product product = new Product(name,description,price,seller, ProductCategory.Groceries);
            seller.AllProducts.Add(product);
            return product;
        }

        public void ChooseCategory() { 
            string message = """
                1 - Electronics
                2 - Clothing
                3 - Books
                4 - Sports
                5 - Beauty
                6 - Health
                7 - Groceries
                """;
            Console.WriteLine(message);
            Console.WriteLine("Choose one of the following:");

        }
        public void AssignCategory(Product product, int choice) {
            switch (choice)
            {
                case 1:
                    product.Category = ProductCategory.Electronics;
                    break;
                case 2:
                    product.Category = ProductCategory.Clothes;
                    break;
                case 3:
                    product.Category = ProductCategory.Books;
                    break;
                case 4:
                    product.Category = ProductCategory.Sports;
                    break;
                case 5:
                    product.Category = ProductCategory.Beauty;
                    break;
                case 6:
                    product.Category = ProductCategory.Health;
                    break;
                case 7:
                    product.Category = ProductCategory.Groceries;
                    break;
                    
            }
        }

        public string LastMonth(Seller seller) {
            string transactions = string.Empty;
            foreach (var transaction in MarketPlace.transactions)
            {
                if (transaction.Seller == seller)
                {
                    if (transaction.TimeOfSale >= DateTime.Now.AddMonths(-1) && transaction.TimeOfSale <= DateTime.Now)
                    {
                        transactions += $"{transaction.Seller.Name} sold to {transaction.Buyer.Name} and the time was: {transaction.TimeOfSale} \n";
                    }
                }
            }
            return transactions;
        }

        public string LastSixMonths(Seller seller) {
            string transactions = string.Empty;
            foreach (var transaction in MarketPlace.transactions)
            {
                if (transaction.Seller == seller)
                {
                    if (transaction.TimeOfSale >= DateTime.Now.AddMonths(-6) && transaction.TimeOfSale <= DateTime.Now)
                    {
                        transactions += $"{transaction.Seller.Name} sold to {transaction.Buyer.Name} and the time was: {transaction.TimeOfSale} \n";
                    }
                }
            }
            return transactions;
        }
        public string LastYear(Seller seller) {
            string transactions = string.Empty;
            foreach (var transaction in MarketPlace.transactions)
            {
                if (transaction.Seller == seller)
                {
                    if (transaction.TimeOfSale >= DateTime.Now.AddMonths(-12) && transaction.TimeOfSale <= DateTime.Now)
                    {
                        transactions += $"{transaction.Seller.Name} sold to {transaction.Buyer.Name} and the time was: {transaction.TimeOfSale} \n";
                    }
                }
            }
            return transactions;
        }
    }
}
