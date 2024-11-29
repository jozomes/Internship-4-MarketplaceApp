using Marketplace.Data.Models;
using Marketplace.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Presentation.Menus
{
    public class SellerMenu
    {
        public async void SellerDropDownMenu(Seller seller)
        {
            UserRepository userRepository = new UserRepository();
            ProductRepository productRepository = new ProductRepository();
            HelperFunctions helperFunctions = new HelperFunctions();
            MainMenu mainMenu = new MainMenu();
            Console.Clear();
            string message = """
                Please choose one of the following:
                1 - Add a new product for sale
                2 - Look at all your owned products
                3 - Summary of all income
                4 - How many products have you sold by each category
                5 - Summary of income based on date
                6 - Log Out
                """;
            Console.WriteLine(message);
            while (true)
            {
                Console.WriteLine("Enter the number to access the desired menu: ");
                int choice = helperFunctions.GetValidInput([1, 2, 3, 4, 5, 6]);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the name of the new product");
                        string newProductName = helperFunctions.GetNonNullString();
                        Console.WriteLine("Enter the descripion of the new product");
                        string newProductDesc = helperFunctions.GetNonNullString();
                        Console.WriteLine("Enter the price");
                        double newPrice = helperFunctions.GetPriceGreaterThan0();
                        productRepository.ChooseCategory();
                        int categoryInput = helperFunctions.GetValidInput([1, 2, 3, 4, 5, 6, 7]);
                        Product newProduct = productRepository.NewProduct(seller,newProductName,newProductDesc,newPrice );
                        productRepository.AssignCategory(newProduct, categoryInput);
                        Console.WriteLine("Product entered successfully, press any key to continue");
                        Console.ReadKey();
                        SellerDropDownMenu(seller);
                        break;
                    case 2:
                        Console.WriteLine($"All owned products of {seller.Name}:");
                        string owned = userRepository.AllOwnedProductesOfSeller(seller);
                        if (owned == string.Empty) Console.WriteLine("Seller has no products in the marketplace");
                        else Console.WriteLine(owned);
                        Console.ReadKey();
                        SellerDropDownMenu(seller);
                        break;
                    case 3:
                        Console.WriteLine($"Seller {seller.Name} has made {userRepository.AllSoldProducts(seller)} from selling so far");
                        Console.ReadKey();
                        SellerDropDownMenu(seller);
                        break;
                    case 4:
                        Console.WriteLine("Choose which category to show sold prodcuts");
                        productRepository.ChooseCategory();
                        int choiceFilter = helperFunctions.GetValidInput([1,2,3,4,5,6,7]);
                        string summary = string.Empty;
                        switch (choiceFilter)
                        {
                            case 1:
                                summary = userRepository.AllSoldProductsOfSellerByCategory(seller, Data.Models.Enums.ProductCategory.Electronics);
                                break;
                            case 2:
                                summary = userRepository.AllSoldProductsOfSellerByCategory(seller, Data.Models.Enums.ProductCategory.Clothes);
                                break;
                            case 3:
                                summary = userRepository.AllSoldProductsOfSellerByCategory(seller, Data.Models.Enums.ProductCategory.Books);
                                break;
                            case 4:
                                summary = userRepository.AllSoldProductsOfSellerByCategory(seller, Data.Models.Enums.ProductCategory.Sports);
                                break;
                            case 5:
                                summary = userRepository.AllSoldProductsOfSellerByCategory(seller, Data.Models.Enums.ProductCategory.Beauty);
                                break;
                            case 6:
                                summary = userRepository.AllSoldProductsOfSellerByCategory(seller, Data.Models.Enums.ProductCategory.Health);
                                break;
                            case 7:
                                summary = userRepository.AllSoldProductsOfSellerByCategory(seller, Data.Models.Enums.ProductCategory.Groceries);
                                break;
                        }
                        if (summary == string.Empty) Console.WriteLine("Seller has no sold products in that category");
                        else Console.WriteLine(summary);
                        Console.ReadKey();
                        SellerDropDownMenu(seller);

                        break;
                    case 5:
                        Console.WriteLine("Choose which timeline you want to show: ");
                        string chooseFormat = """
                            1 - Last month
                            2 - Last 6 months
                            3 - Last year
                            """;
                        Console.WriteLine(chooseFormat);
                        int formatchoice = helperFunctions.GetValidInput([1, 2, 3]);
                        string timeSummary = string.Empty;
                        switch (formatchoice)
                        {
                            case 1:
                                timeSummary = productRepository.LastMonth(seller);
                                break;
                            case 2:
                                timeSummary = productRepository.LastSixMonths(seller);
                                break;
                            case 3:
                                timeSummary = productRepository.LastYear(seller);
                                break;

                        }
                        if (timeSummary == string.Empty) Console.WriteLine("Seller has no sold products in that category");
                        else Console.WriteLine(timeSummary);
                        Console.ReadKey();
                        SellerDropDownMenu(seller);
                        break;
                    case 6:
                        mainMenu.DisplayMainMenu();
                        break;
                }

            }
        }
    }
}
