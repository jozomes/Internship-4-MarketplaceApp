using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Data.Models.Enums;
namespace Marketplace.Data.Models
{
    public class Transaction
    {
        public Guid Id { get;}
        public Seller Seller { get; }
        public Buyer Buyer { get; }
        public DateTime TimeOfSale { get;}

        public Transaction(Product product, Seller seller, Buyer buyer) {
            Id = product.Id;
            Seller = seller;
            Buyer = buyer;
            TimeOfSale = DateTime.Now;
        }
        public Transaction(Product product, Seller seller, Buyer buyer, DateTime past) //just so I can check the parameters of income filtered by months
        {
            Id = product.Id;
            Seller = seller;
            Buyer = buyer;
            TimeOfSale = past;
        }

    }
}
