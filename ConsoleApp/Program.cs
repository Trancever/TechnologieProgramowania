using System;
using Library.Interfaces;
using Library.Model;
using Library.Serializers;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Author author = new Author("Adam", "Mickiewicz",50, "Warszawa");
            Person person = new Person("Antek", "Nowak", 15, "Krakow");
            Book book1 = new Book("Dziady", author, 200, "PWN");
            Book book2 = new Book("Przedwiosnie", author, 250, "Sowa");
            BookDescription bookDscp1 = new BookDescription(book1, "dziwna ksiazka", DateTime.Now, Purpose.All, Kind.Fantasy);
            BookDescription bookDscp2 = new BookDescription(book2, "fajne", DateTime.Now, Purpose.Teenagers, Kind.Moral);
            Rental rental1 = new Rental(bookDscp1, person, DateTime.Now);
            Rental rental2 = new Rental(bookDscp1, person, DateTime.Now);
            Rental rental3 = new Rental(bookDscp2, person, DateTime.Now);

            DataContext dataCtx = new DataContext();

            dataCtx.PeopleCatalog.Add(author);
            dataCtx.PeopleCatalog.Add(person);
            dataCtx.ItemsCatalog.Add(book1.Id,book1);
            dataCtx.ItemsCatalog.Add(book2.Id, book2);
            dataCtx.StatesCatalog.Add(bookDscp1);
            dataCtx.StatesCatalog.Add(bookDscp2);
            dataCtx.EventsCatalog.Add(rental1);
            dataCtx.EventsCatalog.Add(rental2);
            dataCtx.EventsCatalog.Add(rental3);

            OwnSerializer.Serialize(dataCtx, "DataCtxSerialized.data");

            DataContext newDataCtx = OwnSerializer.Deserialize("DataCtxSerialized.data");
        }
    }
}
