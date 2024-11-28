﻿using Marketplace.Data.Models;
using Marketplace.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Presentation.Menus
{
    public class BuyerMenu
    {
        public void BuyerDropDownMenu(Buyer buyer) { 
            UserRepository userRepository = new UserRepository();
            ProductRepository productRepository = new ProductRepository();
            HelperFunctions helperFunctions = new HelperFunctions();
            MainMenu mainMenu = new MainMenu();
            Console.Clear();
            string message = """
                Please choose one of the following:
                1 - Drop down menu of all products that are for sale
                2 - Buying a product
                3 - Return a previously bought product
                4 - Add a product to your list of favorites
                5 - History of all bought products
                6 - Access your list of favorite products
                7 - Log Out
                """;
            Console.WriteLine(message);
      
            while (true)
            {
                Console.WriteLine("Enter the number to access the desired menu: ");
                int choice = helperFunctions.GetValidInput([1, 2, 3, 4, 5, 6, 7]);
                switch (choice) {
                    
                    case 1:
                        Console.WriteLine(productRepository.AvailableProductsForSale());
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Copy the desired product of ID you are trying to buy.");
                        string id = helperFunctions.GetNonNullString();
                        bool validID = helperFunctions.IsValidGuid(id);
                        switch (validID)
                        {
                            case true:
                                break;
                            case false:
                                Console.WriteLine("Inputted ID is wrong");
                                break;
                        }
                        var product = productRepository.getProductById(Guid.Parse(id));
                        if (product == null) Console.WriteLine("That product doesn't exist");
                        else Console.WriteLine(productRepository.EnoughBalance(buyer, product)); 
                       
                        
                        break;
                    case 3:
                        Console.WriteLine("Enter the id of product you are returning: ");
                        string returnID = helperFunctions.GetNonNullString();
                        bool validReturnID = helperFunctions.IsValidGuid(returnID);
                        switch (validReturnID)
                        {
                            case true:
                                break;
                            case false:
                                Console.WriteLine("Inputted ID is wrong");
                                break;
                        }
                        var returnedProduct = productRepository.getProductById(Guid.Parse(returnID));
                        if (returnedProduct == null) Console.WriteLine("That product doesn't exist");
                        else Console.WriteLine(productRepository.ReturnProduct(buyer, returnedProduct));
                        break;
                    case 4:
                        Console.WriteLine("Enter the id of the product you want to add to the favorites: ");
                        string favoriteID = helperFunctions.GetNonNullString();
                        bool validFavoriteID = helperFunctions.IsValidGuid(favoriteID);
                        switch (validFavoriteID)
                        {
                            case true:
                                break;
                            case false:
                                Console.WriteLine("Inputted ID is wrong");
                                break;
                        }
                        var favoriteProduct = productRepository.getProductById(Guid.Parse(favoriteID));
                        if (favoriteProduct == null)
                            Console.WriteLine("That product doesn't exist");

                        else
                            Console.WriteLine(productRepository.AddToFavorite(buyer, favoriteProduct));
                        break;
                    case 5:
                        Console.WriteLine(productRepository.BoughtProducts(buyer));
                        break;
                    case 6:
                        Console.WriteLine(productRepository.AllFavorites(buyer));
                        break;
                    case 7:
                        mainMenu.DisplayMainMenu();
                        break;
                }
            }

        }
    }
}
