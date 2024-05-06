using Potter_kata.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potter_kata.Discounts
{
    public interface IDiscountStrategy
    {        
        double calculatePrice(List<Book> books, int booksRequiredInSeries, double discount);
    }
}
