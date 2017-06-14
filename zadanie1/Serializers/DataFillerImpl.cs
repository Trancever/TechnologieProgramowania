using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.Interfaces;
using Library.Model;


namespace Library.Serializers
{
    public class DataFillerImpl : IDataFiller
    {
        public DataFillerImpl()
        {
            people = new List<Person>();
            items = new Dictionary<string, Item>();
            events = new ObservableCollection<Event>();
            states = new List<StateDescription>();

            Author author1 = new Author("John", "Tolkien", 81, "Orania");
            Book book1 = new Book("Lord of the rings - The Fellowship of the Ring", author1, 412, "XYZ");
            Book book2 = new Book("Lord of the rings - The Two Towers", author1, 350, "XYZ");
            Book book3 = new Book("Lord of the rings - The Return of the King", author1, 507, "XYZ");

            BookDescription state1 = new BookDescription(book1, "Story of powerful ring", new DateTime(2000, 1, 12), Purpose.All, Kind.Fantasy);
            BookDescription state2 = new BookDescription(book2, "Story of powerful ring", new DateTime(2002, 12, 5), Purpose.All, Kind.Fantasy);
            BookDescription state3 = new BookDescription(book3, "Story of powerful ring", new DateTime(2003, 6, 22), Purpose.All, Kind.Fantasy);

            Reader person1 = new Reader("Dawid", "Urbaniak", 22, "Brzezna");
            Reader person2 = new Reader("Igor", "Orynski", 22, "Manhatan");

            people.Add(person1);
            people.Add(person2);
            people.Add(author1);

            items.Add(book1.Id, book1);
            items.Add(book2.Id, book2);
            items.Add(book3.Id, book3);

            states.Add(state1);
            states.Add(state2);
            states.Add(state3);

            events.Add(new Rental(state1, person1, DateTime.Now));
            events.Add(new Rental(state2, person1, DateTime.Now));
            events.Add(new Rental(state3, person2, DateTime.Now));
        }

        public Dictionary<string, Item> GetItemsList()
        {
            return items;
        }

        public List<Person> GetPeopleList()
        {
            return people;
        }

        public ObservableCollection<Event> GetEventsList()
        {
            return events;
        }

        public List<StateDescription> GetStatesList()
        {
            return states;
        }

        private Dictionary<string, Item> items;
        private List<Person> people;
        ObservableCollection<Event> events;
        List<StateDescription> states;
    }
}
