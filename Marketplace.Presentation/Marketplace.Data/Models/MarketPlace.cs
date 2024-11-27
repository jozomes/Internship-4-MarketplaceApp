using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models.Enums;
namespace Marketplace.Data.Models
{
    public class MarketPlace
    {
        public static List<Buyer> buyers = new List<Buyer>();
        public static List<Seller> sellers = new List<Seller>();
        public static List<Product> products = new List<Product>();
        public static List<Transaction> transactions = new List<Transaction>();

        public MarketPlace()
        {

        }

    }
}
