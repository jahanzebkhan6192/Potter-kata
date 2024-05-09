using Potter_kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Potter_kata.Discounts
{

    public static class DiscountCatalog
    {
        public const int ONE_BOOKS_REQUIRED = 1;
        public const int TWO_BOOKS_REQUIRED = 2;
        public const int THREE_BOOKS_REQUIRED = 3;
        public const int FOUR_BOOKS_REQUIRED = 4;
        public const int FIVE_BOOKS_REQUIRED = 5;

        public const double NONE = 1.0;
        public const double FIVE_PERCENT = 0.95;
        public const double TEN_PERCENT = 0.90;
        public const double TWENTY_PERCENT = 0.8;
        public const double TWENTY_FIVE_PERCENT = 0.75;


        // A list of discounts that can be applied to an order with books required
        public static readonly Dictionary<int, double> Catalogue = new Dictionary<int, double>
        {
            {ONE_BOOKS_REQUIRED, NONE},
            {TWO_BOOKS_REQUIRED, FIVE_PERCENT},
            {THREE_BOOKS_REQUIRED, TEN_PERCENT},
            {FOUR_BOOKS_REQUIRED, TWENTY_PERCENT},
            {FIVE_BOOKS_REQUIRED, TWENTY_FIVE_PERCENT}
        };

    }


}
