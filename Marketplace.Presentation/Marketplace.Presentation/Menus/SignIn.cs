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
        private readonly BuyerMenu buyermenu = new BuyerMenu();
        private readonly SellerMenu sellermenu = new SellerMenu();

        public void LogInUser()
        {
            Console.Clear();
            User targetUser;
            while (true)
            {
                Console.WriteLine("Please enter the email you registered to our site with: ");
                string email = helperFunctions.GetNonNullString();
                var user = _userRepository.LoginCheck(email);
                if (user == null)
                {
                    Console.WriteLine("You have inputted the wrong email, try again.");
                    
                    continue;
                }
                targetUser = user;
                Console.WriteLine($"Entering {user.Name}'s account, press any key to continue.");

                Console.ReadKey();

                break;
            }
            if (targetUser is Buyer)
            {
                Buyer buyer = (Buyer)targetUser;
                buyermenu.BuyerDropDownMenu(buyer);
            }
            else
            {
                Seller seller = (Seller)targetUser;
                sellermenu.SellerDropDownMenu(seller);
            }


        }
    }
}
