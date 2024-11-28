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
            Console.Clear();
            string message = """
                
                Please choose one of the following: 

                    1 - Sign in with existing user email
                                    or
                    2 - Register a new user
                                    or
                    0 - Exit the app
                """;
            Console.WriteLine(message);
            int choice = helperFunctions.GetValidInput([1, 2, 0]);
            User loggedin = null;
            switch (choice)
            {
                case 1:
                    signmenu.LogInUser();
                    break;
                case 2:
                    registerMenu.ChooseWhichUser();
                    DisplayMainMenu();
                    break;
                case 0:
                    Console.WriteLine("Thank you for visiting");
                    Console.ReadKey();
                    break;
            }

        }
    }
}
