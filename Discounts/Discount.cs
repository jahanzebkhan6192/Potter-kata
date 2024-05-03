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
            while (books.Where(x => x.Quantity > 0).Count() >= booksRequiredInSeries)
            {
                var thesebooks = books.Where(x => x.Quantity > 0).ToList();
                ApplyDiscount(thesebooks, booksRequiredInSeries, discount);
            }
            return price;
        }

        private void ApplyDiscount(List<Book> books, int booksRequiredInSeries, double discount)
        {            
                price += books.Sum(x => x.SinglePrice) * discount;
                books.TakeWhile(s => s.Quantity > 0).ToList().ForEach(s => s.Quantity -= 1);            
        }
    }
}
