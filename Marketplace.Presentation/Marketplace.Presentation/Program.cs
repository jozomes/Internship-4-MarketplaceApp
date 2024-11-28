using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models;
using Marketplace.Domain.Repositories;
using Marketplace.Presentation;
using Marketplace.Presentation.Menus;
namespace DrugoPredavanje
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            Console.WriteLine("Hello dear customer, welcome to our store.");
            mainMenu.DisplayMainMenu();
        }
    }
}