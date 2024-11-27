using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models.Enums;
namespace Marketplace.Data.Models
{
    public class Buyer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Balance { get; private set; }
        public List<Product> BoughtProducts { get; set; }

        public Buyer(string name, string email, double balance) {
            Name = name;
            Email = email;
            Balance = balance;
            BoughtProducts = new List<Product>();
        }

    }

}
