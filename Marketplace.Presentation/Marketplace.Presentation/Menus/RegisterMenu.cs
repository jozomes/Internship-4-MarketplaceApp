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
        private readonly MainMenu mainMenu = new MainMenu();
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
                    string nameBuyer = helperFunctions.GetNonNullString();
                    Console.WriteLine("Enter your email: ");
                    string emailBuyer = helperFunctions.GetNonNullString();
                    var userBuyer = _userRepository.LoginCheck(emailBuyer);
                    if (userBuyer != null)
                    {
                        Console.WriteLine("User with that email has already been registered, maybe you want to sign in?");
                        mainMenu.DisplayMainMenu();
                    }
                    double balance = helperFunctions.GetBalanceGreaterThan100();
                    Console.WriteLine(_userRepository.registerBuyer(nameBuyer, emailBuyer, balance));
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Enter your name: ");
                    string nameSeller = helperFunctions.GetNonNullString();
                    Console.WriteLine("Enter your email: ");
                    string emailSeller  = helperFunctions.GetNonNullString();
                    var userSeller = _userRepository.LoginCheck(emailSeller);
                    if (userSeller != null)
                    {
                        Console.WriteLine("User with that email has already been registered, maybe you want to sign in?");
                        Console.ReadKey();
                        mainMenu.DisplayMainMenu();
                    }
                    Console.WriteLine(_userRepository.registerSeller(nameSeller, emailSeller));
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;
                case 0:
                    mainMenu.DisplayMainMenu();
                    break;
            }
        }
    }
}
