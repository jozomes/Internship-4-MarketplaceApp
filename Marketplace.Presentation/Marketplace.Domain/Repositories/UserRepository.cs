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
        public void LoadStart() {
            Seeder.AddStartElements();
        }
        public string AllUsers() {
            string s = string.Empty;
            foreach (var item in MarketPlace.users)
            {
                s += item.Name+"\n";
            }
            return s;
        }
    }
}
