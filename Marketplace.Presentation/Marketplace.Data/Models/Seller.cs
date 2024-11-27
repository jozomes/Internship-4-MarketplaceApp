using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models.Enums;
namespace Marketplace.Data.Models
{
    public class Seller
    {
        public Guid ID { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> soldProducts { get; set; }
        public Seller(string name, string email)
        {
            Name = name;
            Email = email;
            Products = new List<Product>();
            soldProducts = new List<Product>();
            ID = Guid.NewGuid();
        }
    }

}
