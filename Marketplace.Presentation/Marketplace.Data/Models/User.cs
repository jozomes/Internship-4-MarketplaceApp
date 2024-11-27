using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data.Models
{
    public class User
    {
        public Guid Id { get;}
        public string Name { get; set; }
        public string Email { get; set; }
        public User(string name, string email) {
            Name = name;
            Email = email;
        }
    }
}
