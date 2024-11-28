using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models.Enums;
namespace Marketplace.Data.Models
{
    public class Seller : User
    {
        public List<Product> AllProducts { get; set; }
        public Seller(string name, string email) : base(name, email)
        {
            AllProducts = new List<Product>();
        }
    }

}
