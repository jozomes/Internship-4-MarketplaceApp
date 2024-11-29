using Marketplace.Data;
using Marketplace.Data.Models;
using Marketplace.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain.Repositories
{
    public class UserRepository
    {
        public string AllUsers() {
            string s = string.Empty;
            foreach (var item in MarketPlace.users)
            {
                s += item.Name+"\n";
            }
            return s;
        }

        public User LoginCheck(string email) {
            User user = null;
            foreach (var item in MarketPlace.users)
            {
                if (email.Trim() == item.Email)
                {
                    user = item;
                    return user;
                }
            }
            return user;
        }
        public string IsNullUser(User user) {
            if (user != null)
            {
                return "Found the user with the email: " + user.Email;
            }
            else return "User with that email has not been found.";
        }

        public string registerBuyer(string name, string email, double balance) {
            Buyer newBuyer = new Buyer(name,email,balance);
            MarketPlace.users.Add(newBuyer);
            return $"Buyer {email} has been successfully registered to the system. Starting balance is {balance} euros";
        }

        public string registerSeller(string name, string email) {
            Seller newSeller = new Seller(name,email);
            MarketPlace.users.Add(newSeller);
            return $"Seller {email} has been successfully registered to the system";
        }

        public string AllOwnedProductesOfSeller(Seller seller) {
            string s = string.Empty; ;
            foreach (var item in seller.AllProducts)
            {
                if (item.IsSold == false) s += $"{item.Name} {item.Description} {item.Price} {item.Category} OnSale \n";
                else s += $"{item.Name} {item.Description} {item.Price} {item.Category} Sold \n";
            }
            return s;
        }

        public double AllSoldProducts(Seller seller) {
            double sum = 0;
            foreach (var item in MarketPlace.products)
            {
                if (item.Seller == seller && item.IsSold == true)
                {
                        sum += item.Price * 0.95; //Commision of marketplace
                }
            }
            return sum;

        }
        public string AllSoldProductsOfSellerByCategory(Seller seller, ProductCategory category) {
            string s = string.Empty;
            foreach (var item in MarketPlace.products)
            {
                if (item.Seller == seller && item.Category == category && item.IsSold == true)
                {
                    s += $"{item.Name} - {item.Description} - {item.Price} \n";      
                }
            }
            return s;
        }

       
    }
}
