using Potter_kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potter_kata.Discounts
{
    public class Discount : IDiscountStrategy  
    {
        double price;
        public double calculatePrice(List<Book> books, int booksRequiredInSeries, double discount)
        {
            price = 0;
            // apply discount as long as it is applicable - meets the number of books required
            while (books.Where(x => x.Quantity > 0).Count() >= booksRequiredInSeries)
            {
                // book list the discount needs to be applied to in list
                var thesebooks = books.Where(x => x.Quantity > 0).ToList();
                ApplyDiscount(thesebooks, discount);
            }
            return price;
        }

        // calcuate price after discount and then lessen the count of books by one to those its been applied to in list
        private void ApplyDiscount(List<Book> books, double discount)
        {            
            // sum the price of books in list and apply discount    
            price += books.Sum(x => x.SinglePrice) * discount;
            // lessen count of these books in the list 
            books.TakeWhile(s => s.Quantity > 0).ToList().ForEach(s => s.Quantity -= 1);            
        }
    }
}
