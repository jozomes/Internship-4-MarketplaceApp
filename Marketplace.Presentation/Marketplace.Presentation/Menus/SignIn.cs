using Marketplace.Data.Models;
using Marketplace.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Presentation.Menus
{
    public class SignIn
    {
        private readonly UserRepository _userRepository = new UserRepository();
        private readonly ProductRepository _productRepository = new ProductRepository();
        private readonly HelperFunctions helperFunctions = new HelperFunctions();

        public User LogInUser()
        {
            User targetUser;
            while (true)
            {
                Console.Clear();
                string email = helperFunctions.GetNonNullString();
                var user = _userRepository.LoginCheck(email);
                if (user == null)
                {
                    Console.WriteLine("You have inputted the wrong email, try again.");
                    Console.ReadKey();
                    continue;
                }
                targetUser = user;
                Console.WriteLine($"Entering {user.Name}'s account, press any key to continue.");
                Console.ReadKey();
                break;
            }
            return targetUser;

        }
    }
}
