using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Library.Model
{
    [DataContract]
    [KnownType(typeof(Item))]
    [KnownType(typeof(Event))]
    [KnownType(typeof(StateDescription))]
    [KnownType(typeof(Person))]
    public class DataContext
    {
        public DataContext()
        {
            PeopleCatalog = new List<Person>();
            ItemsCatalog = new Dictionary<string, Item>();
            EventsCatalog = new ObservableCollection<Event>();
            StatesCatalog = new List<StateDescription>();
            
            EventsCatalog.CollectionChanged += EventsCatalog_CollectionChanged;
        }

        private void EventsCatalog_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("New Event added to list.");
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Move)
            {
                Console.WriteLine("Event moved.");
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Event removed");
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                Console.WriteLine("Event replaced");
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
            {
                Console.WriteLine("Collection reseted");
            }
        }

        [DataMember(Order = 1)]
        public List<Person> PeopleCatalog;
        [DataMember(Order = 2)]
        public Dictionary<string, Item> ItemsCatalog;
        [DataMember(Order = 4)]
        public ObservableCollection<Event> EventsCatalog;
        [DataMember(Order = 3)]
        public List<StateDescription> StatesCatalog;
    }
}
