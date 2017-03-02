using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DataFillerImpl : IDataFiller
    {
        public Dictionary<long, Book> getBookList()
        {
            Book book1 = new Book("Lord of the rings", "J.R.R.Tolkien");
            Book book2 = new Book("Harry Potter", "J.K.Rowling");
            Book book3 = new Book("Angels and Demons", "Dan Brown");

            Dictionary<long, Book> bookDictionary = new Dictionary<long, Book>();
            bookDictionary.Add(book1.Id, book1);
            Console.WriteLine(book1.Id);
            bookDictionary.Add(book2.Id, book2);
            Console.WriteLine(book2.Id);
            bookDictionary.Add(book3.Id, book3);
            Console.WriteLine(book2.Id);
            return bookDictionary;
        }

        public List<Reader> getReadersList()
        {
            List<Reader> readersList = new List<Reader>();
            readersList.Add(new Reader("Antonio", "Banderas", 50));
            readersList.Add(new Reader("Kevin", "Burnet", 28));

            return readersList;
        }

        public ObservableCollection<Rental> getRentalsList()
        {
            ObservableCollection<Rental> rentalsList = new ObservableCollection<Rental>();
            rentalsList.Add(new Rental(1, 2, DateTime.Now));
            rentalsList.Add(new Rental(2, 3, DateTime.Now));

            return rentalsList;
        }

        public Dictionary<long, StateDescription> getStatesList()
        {
            StateDescription state1 = new StateDescription(1, "This book is about powerful ring.", new DateTime(2000, 11, 15));
            StateDescription state2 = new StateDescription(2, "This book is about wizards.", new DateTime(2005, 08, 11));
            StateDescription state3 = new StateDescription(3, "Very intresting book for adults.", new DateTime(2009, 1, 1));
            Dictionary<long, StateDescription> statesDictionary = new Dictionary<long, StateDescription>();
            statesDictionary.Add(state1.Id, state1);
            statesDictionary.Add(state2.Id, state2);
            statesDictionary.Add(state3.Id, state3);

            return statesDictionary;
        }
    }
}
