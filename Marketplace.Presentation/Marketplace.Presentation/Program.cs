using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models;
using Marketplace.Domain.Repositories;
namespace DrugoPredavanje
{
    class Program
    {
        static void Main(string[] args)
        {

            UserRepository UserRepo = new UserRepository();
            UserRepo.LoadStart();
            Console.WriteLine(  "Novi unos");
            Console.WriteLine(UserRepo.AllUsers());
        }
    }
}