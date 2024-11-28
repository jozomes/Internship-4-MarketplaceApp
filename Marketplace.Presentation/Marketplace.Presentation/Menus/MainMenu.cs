using Marketplace.Data.Models;
using Marketplace.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Marketplace.Presentation.Menus
{
    public class MainMenu
    {
        public void DisplayMainMenu() {
            UserRepository userRepository = new UserRepository();
            HelperFunctions helperFunctions = new HelperFunctions();
            RegisterMenu registerMenu = new RegisterMenu();
            SignIn signmenu = new SignIn();
            string message = """
                
                Please choose one of the following: 

                    1 - Sign in with existing user email
                                    or
                    2 - Register a new user
                """;
            Console.WriteLine(message);
            int choice = helperFunctions.GetValidInput([1, 2]);
            User loggedin = null;
            switch (choice)
            {
                case 1:
                    loggedin = signmenu.LogInUser();
                    break;
                case 2:
                    registerMenu.ChooseWhichUser();
                    DisplayMainMenu();
                    break;
            }

            if (loggedin is Buyer)
            {
                Console.WriteLine("We got ourselves a buyer");
            }
            else {
                Console.WriteLine("We got ourselves a seller");
            }
        }
    }
}
