using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models;
using Marketplace.Data.Models.Enums;

namespace Marketplace.Data
{
    public class Seeder
    {
        Buyer buyer1 = new Buyer("Jozo", "jmestrovi@pmfst.hr", 100);
        Buyer buyer2 = new Buyer("Mate", "mgadza@pmfst.hr", 250);
        public List<Buyer> buyers = new List<Buyer>();
        List<Seller> sellers = new List<Seller>();
        List<Product> products = new List<Product>();

       



    }
}
