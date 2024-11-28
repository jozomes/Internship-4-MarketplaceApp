using Marketplace.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
