using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.Interfaces;
using Library.Model;

namespace Library.Serializers
{
    public class LargeDataFillerImpl : IDataFiller
    {
        public LargeDataFillerImpl()
        {
            people = new List<Person>();
            items = new Dictionary<string, Item>();
            states = new List<StateDescription>();
            events = new ObservableCollection<Event>();

            for (int i = 0; i < 10; i++)
            {
                Author author = new Author(randomString(), randomString(), random.Next(100), randomString());
                Reader reader = new Reader(randomString(), randomString(), random.Next(100), randomString());

                people.Add(author);
                people.Add(reader);

                Book book = new Book(randomString(), author, random.Next(1000), randomString());
                items.Add(book.Id, book);

                BookDescription state = new BookDescription(book, randomString(), new DateTime(random.Next(1500, 2000), random.Next(1, 12), random.Next(1, 27)), Purpose.All, Kind.Criminal);
                states.Add(state);

                events.Add(new Rental(state, reader, DateTime.Now));
            }
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

        private string randomString()
        {
            char[] charts = new char[20];
            int setLength = allowedCharts.Length;
            int length = random.Next(1, 21);

            for (int i = 0; i < length; i++)
            {
                charts[i] = allowedCharts[random.Next(setLength)];
            }
            return new string(charts, 0, length);
        }
        
        const string allowedCharts = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()";
        private Random random = new Random();

        private Dictionary<string, Item> items;
        private List<Person> people;
        private ObservableCollection<Event> events;
        private List<StateDescription> states;
    }
}
