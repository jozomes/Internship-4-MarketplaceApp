using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Presentation
{
    public class HelperFunctions
    {
        public string GetNonNullString()
        {
            string input;
            do
            {

                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input)); // Repeat if the input is null, empty, or only whitespace

            return input.Trim();
        }
        public bool IsValidGuid(string input)
        {
            // Check if the input is a valid GUID
            return Guid.TryParse(input, out _);
        }

        public int GetValidInput(int[] validNumbers)
        {
            
            while (true)
            {
                
                if (int.TryParse(Console.ReadLine().Trim(), out int userInput))
                {
                    
                    foreach (int valid in validNumbers)
                    {
                        if (userInput == valid)
                        {
                            return userInput; 
                        }
                    }

                    Console.WriteLine("The number is not in the valid range. Try again.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }
        public double GetBalanceGreaterThan100()
        {
            Console.WriteLine("Enter you starting balance (must be larger than 100)");
            while (true)
            {
                
                if (double.TryParse(Console.ReadLine().Trim(), out double userInput))
                {
                    if (userInput > 100)
                    {
                        return userInput; // Return the value if it's greater than 100
                    }
                    else
                    {
                        Console.WriteLine("The number is not greater than 100. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid double value.");
                }
            }
        }

    }
}
