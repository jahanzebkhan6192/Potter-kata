// See https://aka.ms/new-console-template for more information

using Potter_kata.Discounts;
using Potter_kata.Models;
Console.WriteLine("Hello, World!");

string json = File.ReadAllText("BookList.json");
var booklist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Book>>(json);
// booklist is a list of all books that can be ordered with their respected price
IDiscountStrategy discountstrategy = new Discount();

do
{
    double price = ProcessOrder(booklist, discountstrategy);

    Console.WriteLine($"The total price is: {price}");
    price = 0;
    Console.WriteLine();

} while (true);


static double ProcessOrder(List<Book>? booklist, IDiscountStrategy discountstrategy)
{
    if (booklist != null && booklist.Any())
    {   
        // Set the quantity of books ordered for each type of book
        foreach (Book book in booklist)
        {
            Console.WriteLine($"Enter the quantity for book volume {book.Name} : ");
            string input = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(input, out int quantity))
            {
                book.Quantity = quantity;
            }
            else
            {
                Console.WriteLine("Invalid inputs are set to 0");
            }
        }
    }
    double price = 0;
    // apply each discount to the order using discount catalog
    foreach (KeyValuePair<int, double> Discount in DiscountCatalog.Catalogue.Reverse())
    {
        if (booklist != null)
            price += discountstrategy.calculatePrice(booklist, Discount.Key, Discount.Value);
    }

    // return the price
    return price;
}