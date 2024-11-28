using Marketplace.Data;
using Marketplace.Data.Models;
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
            Buyer newBuyer = new(name,email,balance);
            MarketPlace.users.Add(newBuyer);
            return $"Buyer {email} has been successfully registered to the system. Starting balance is {balance} euros";
        }
        public string AvailableProductsForSale() {
            string s = "";
            foreach (var item in MarketPlace.products) {
               s += $"id: {item.Id} {item.Name} {item.Price}$ {item.Description} \n";
            }
            return s;
        }
        public bool BuyProduct(Buyer buyer, Product product) {
            if (buyer.Balance >= product.Price) {
                product.ProductSold();
                return true;
            } 
            else return false;

        }
    }
}
