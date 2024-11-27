using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models;
using Marketplace.Data.Models.Enums;

namespace Marketplace.Data
{
    public static class Seeder
    {
        private static Buyer buyer1 = new Buyer("Jozo", "jmestrovi@pmfst.hr", 100);
        private static Buyer buyer2 = new Buyer("Mate", "mgadza@pmfst.hr", 250);

        public static void AddStartElements() { 
            MarketPlace.users.Add(buyer1);
            MarketPlace.users.Add(buyer2);
        }



    }
}
