using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models.Enums;
namespace Marketplace.Data.Models
{
    public class Buyer : User
    {
       
        public double Balance { get; private set; }
        public List<Product> BoughtProducts { get; set; }
        public List<Product> FavoriteProducts { get; set; }
        public Buyer(string name, string email, double balance) : base(name, email) {
            Balance = balance;
            BoughtProducts = new List<Product>();
            FavoriteProducts = new List<Product>();
        }
                

    }

}
