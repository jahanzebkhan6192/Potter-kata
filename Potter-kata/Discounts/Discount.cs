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
            //Loop booklist and apply the discount as long as it meets the
            //required number of each book.
            while (books.Where(x => x.Quantity > 0).Count() >= booksRequiredInSeries)
            {
                //The discount needs to be applied to the book list.
                var booksToApplyDiscount = books.Where(x => x.Quantity > 0).ToList();
                ApplyDiscount(booksToApplyDiscount, discount);
            }
            return price;
        }

        //Calcuate price after discount to book list in order
        //After discounting, reduce the quantity of each book in list by one.
        private void ApplyDiscount(List<Book> books, double discount)
        {            
            // sum the price of books in list and apply discount    
            price += books.Sum(x => x.SinglePrice) * discount;
            // lessen count of these books in the list 
            books.TakeWhile(s => s.Quantity > 0).ToList().ForEach(s => s.Quantity -= 1);            
        }
    }
}
