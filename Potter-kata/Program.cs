// See https://aka.ms/new-console-template for more information

using Potter_kata.Discounts;
using Potter_kata.Models;
Console.WriteLine("Hello, World!");

string json = File.ReadAllText("BookList.json");
var booklist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Book>>(json);
IDiscountStrategy applydiscounts = new Discount();

do
{
    double price = NewMethod(booklist, applydiscounts);

    Console.WriteLine($"The total price is: {price}");
    price = 0;
    Console.WriteLine();

} while (true);

static double NewMethod(List<Book>? booklist, IDiscountStrategy applydiscounts)
{
    if (booklist != null && booklist.Any())
    {
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
    foreach (KeyValuePair<int, double> Discount in DiscountCatalog.Catalogue.Reverse())
    {

        if (booklist != null)
            price += applydiscounts.calculatePrice(booklist, Discount.Key, Discount.Value);
    }

    return price;
}