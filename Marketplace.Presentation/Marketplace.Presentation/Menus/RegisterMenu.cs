using Marketplace.Data.Models;
using Marketplace.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Presentation.Menus
{
    public class RegisterMenu
    {
        private readonly UserRepository _userRepository = new UserRepository();
        private readonly ProductRepository _productRepository = new ProductRepository();
        private readonly HelperFunctions helperFunctions = new HelperFunctions();
        public void ChooseWhichUser() { 
            Console.Clear();
            string message = """
                Choose as which user you are trying to register as:
                1 - Buyer
                2 - Seller
                0 - Exit
                """;
            Console.WriteLine(message);
            int choice = helperFunctions.GetValidInput([1, 2, 0]);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter your name: ");
                    string name = helperFunctions.GetNonNullString();
                    Console.WriteLine("Enter your email: ");
                    string email = helperFunctions.GetNonNullString();
                    var user = _userRepository.LoginCheck(email);
                    if (user == null) { 

                    }
                    else
                    {
                        Console.WriteLine("User with that email has already been registered.");
                    }
                    double balance = helperFunctions.GetBalanceGreaterThan100();
                    Console.WriteLine(_userRepository.registerBuyer(name, email, balance));
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;
                case 2:
                    break;
                case 0:
                    break;
            }
        }
    }
}
