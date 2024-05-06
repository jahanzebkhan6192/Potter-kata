using Potter_kata.Discounts;
using Potter_kata.Models;

namespace Potter_kata.Tests
{
    public class CartTest
    {

        Book book1 = new Book() { Quantity = 1, Name = "1", SinglePrice = 8.0 };
        Book book2 = new Book() { Quantity = 1, Name = "2", SinglePrice = 8.0 };
        Book book3 = new Book() { Quantity = 1, Name = "3", SinglePrice = 8.0 };
        Book book4 = new Book() { Quantity = 1, Name = "4", SinglePrice = 8.0 };
        Book book5 = new Book() { Quantity = 1, Name = "5", SinglePrice = 8.0 };
        Book book1x2 = new Book() { Quantity = 2, Name = "1", SinglePrice = 8.0 };
        Book book3x2 = new Book() { Quantity = 2, Name = "2", SinglePrice = 8.0 };


        IDiscountStrategy _discountStrategy;

        public CartTest()
        {
            _discountStrategy = new Discount();
        }


        [Theory]
        // 1 book
        [InlineData(8, "[ { \"Name\": \"1\", \"singlePrice\": 8.0, \"Quantity\": 1 }, { \"Name\": \"2\", \"singlePrice\": 8.0, \"Quantity\": 0 }, { \"Name\": \"3\", \"singlePrice\": 8.0, \"Quantity\": 0 }, { \"Name\": \"4\", \"singlePrice\": 8.0, \"Quantity\": 0 }, { \"Name\": \"5\", \"singlePrice\": 8.0, \"Quantity\": 0 } ]")]
        // 2 books in series
        [InlineData(2 * 8 * 0.95, "[ { \"Name\": \"1\", \"singlePrice\": 8.0, \"Quantity\": 1 }, { \"Name\": \"2\", \"singlePrice\": 8.0, \"Quantity\": 1 }, { \"Name\": \"3\", \"singlePrice\": 8.0, \"Quantity\": 0 }, { \"Name\": \"4\", \"singlePrice\": 8.0, \"Quantity\": 0 }, { \"Name\": \"5\", \"singlePrice\": 8.0, \"Quantity\": 0 } ]")]
        // 3 books in series
        [InlineData(3 * 8 * 0.9, "[ { \"Name\": \"1\", \"singlePrice\": 8.0, \"Quantity\": 1 }, { \"Name\": \"2\", \"singlePrice\": 8.0, \"Quantity\": 1 }, { \"Name\": \"3\", \"singlePrice\": 8.0, \"Quantity\": 1 }, { \"Name\": \"4\", \"singlePrice\": 8.0, \"Quantity\": 0 }, { \"Name\": \"5\", \"singlePrice\": 8.0, \"Quantity\": 0 } ]")]
        // 5 books in series
        [InlineData(5 * 8 * 0.75, "[ { \"Name\": \"1\", \"singlePrice\": 8.0, \"Quantity\": 1 }, { \"Name\": \"2\", \"singlePrice\": 8.0, \"Quantity\": 1 }, { \"Name\": \"3\", \"singlePrice\": 8.0, \"Quantity\": 1 }, { \"Name\": \"4\", \"singlePrice\": 8.0, \"Quantity\": 1 }, { \"Name\": \"5\", \"singlePrice\": 8.0, \"Quantity\": 1 } ]")]
        // 3 books in series - 2 same and 1 dif
        [InlineData(2 * 8 * 0.95 + 1 * 8, "[ { \"Name\": \"1\", \"singlePrice\": 8.0, \"Quantity\": 2 }, { \"Name\": \"2\", \"singlePrice\": 8.0, \"Quantity\": 1 }, { \"Name\": \"3\", \"singlePrice\": 8.0, \"Quantity\": 0 }, { \"Name\": \"4\", \"singlePrice\": 8.0, \"Quantity\": 0 }, { \"Name\": \"5\", \"singlePrice\": 8.0, \"Quantity\": 0 } ]")]
        // books in series - 2 of each
        [InlineData(2 * 8 * 5 * 0.75, "[ { \"Name\": \"1\", \"singlePrice\": 8.0, \"Quantity\": 2 }, { \"Name\": \"2\", \"singlePrice\": 8.0, \"Quantity\": 2 }, { \"Name\": \"3\", \"singlePrice\": 8.0, \"Quantity\": 2 }, { \"Name\": \"4\", \"singlePrice\": 8.0, \"Quantity\": 2 }, { \"Name\": \"5\", \"singlePrice\": 8.0, \"Quantity\": 2 } ]")]
        public void Prices_Are_Equal(double expected, string json)
        {
            double price = 0;
            var booklist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Book>>(json);
            foreach (KeyValuePair<int, double> Discount in DiscountCatalog.Catalogue.Reverse())
            {

                if (booklist != null)
                    price += _discountStrategy.calculatePrice(booklist, Discount.Key, Discount.Value);
            }

            double actual = price;

            Assert.Equal(expected, actual);
        }
    }
}