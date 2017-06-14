using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class DataRepository
    {
        public DataRepository(IDataFiller dataFiller)
        {
            DataCtx = new DataContext();
            if(dataFiller == null)
            {
                throw new ArgumentNullException("IDataFiller", "Given argument is null.");
            }
            DataFiller = dataFiller;
        }

        public void setDataContext()
        {
            DataCtx.ItemsCatalog = DataFiller.GetItemsList();
            DataCtx.PeopleCatalog = DataFiller.GetPeopleList();
            DataCtx.EventsCatalog = DataFiller.GetEventsList();
            DataCtx.StatesCatalog = DataFiller.GetStatesList();
        }

        public DataContext getDataContext()
        {
            return DataCtx;
        }
        
        private IDataFiller DataFiller;
        private DataContext DataCtx { get; }


        /*********************************
         *       C.R.U.D. methods        *
         ********************************/


        // Item C.R.U.D. methods

        public void AddItem(Item item)
        {
            DataCtx.ItemsCatalog.Add(item.Id, item);
        }

        public Item getItem(string key)
        {
            Item book;
            if (!DataCtx.ItemsCatalog.TryGetValue(key, out book))
            {
                throw new KeyNotFoundException("BookCatalog does not contain such key - \"" + key + "\"");
            }
            return book;
        }

        public List<Item> getAllItems()
        {
            return DataCtx.ItemsCatalog.Values.ToList();
        }

        public Dictionary<string, Item> getItemsDictionary()
        {
            return DataCtx.ItemsCatalog;
        }

        public void updateItem(string key, Item item)
        {
            if(DataCtx.ItemsCatalog.ContainsKey(key))
            {
                DataCtx.ItemsCatalog[key] = item;
            }
            else
            {
                throw new KeyNotFoundException("BookCatalog does not contain such key - \"" + key + "\"");
            }
        }

        public void removeItem(string key)
        {
            if(!DataCtx.ItemsCatalog.Remove(key))
            {
                throw new KeyNotFoundException("BookCatalog does not contain such key - \"" + key + "\"");
            }
        }


        // Person C.R.U.D. methods

        public void addPerson(Person person)
        {
            DataCtx.PeopleCatalog.Add(person);
        }

        public Person getPerson(int Id)
        {
            if (Id > DataCtx.PeopleCatalog.Count - 1 || Id < 0)
            {
                throw new KeyNotFoundException("PersonCatalog does not contain such ID - \"" + Id + "\"");
            }
            return DataCtx.PeopleCatalog[Id];
        }

        public List<Person> getAllPeople()
        {
            return DataCtx.PeopleCatalog;
        }

        public void updatePerson(int Id, Person person)
        {
            if (Id > DataCtx.PeopleCatalog.Count - 1 || Id < 0)
            {
                throw new KeyNotFoundException("PersonCatalog does not contain such ID - \"" + Id + "\"");
            }
            else
            {
                DataCtx.PeopleCatalog[Id] = person;
            }
        }

        public void removePerson(int Id)
        {
            if (Id > DataCtx.PeopleCatalog.Count - 1 || Id < 0)
            {
                throw new KeyNotFoundException("PersonCatalog does not contain such ID - \"" + Id + "\"");
            }
            else
            {
                DataCtx.PeopleCatalog.RemoveAt(Id);
            }
        }


        // Event C.R.U.D. methods

        public void addEvent(Event ev)
        {
            DataCtx.EventsCatalog.Add(ev);
        }

        public Event getEvent(int Id)
        {
            if (Id > DataCtx.EventsCatalog.Count - 1 || Id < 0)
            {
                throw new KeyNotFoundException("EventsCatalog does not contain such ID - \"" + Id + "\"");
            }
            return DataCtx.EventsCatalog[Id];
        }

        public List<Event> getAllEvents()
        {
            return DataCtx.EventsCatalog.ToList();
        }

        public void updateEvent(int Id, Event ev)
        {
            if (Id > DataCtx.EventsCatalog.Count - 1 || Id < 0)
            {
                throw new KeyNotFoundException("EventsCatalog does not contain such ID - \"" + Id + "\"");
            }
            DataCtx.EventsCatalog[Id] = ev;
        }

        public void removeEvent(int Id)
        {
            if (Id > DataCtx.EventsCatalog.Count - 1 || Id < 0)
            {
                throw new KeyNotFoundException("EventsCatalog does not contain such ID - \"" + Id + "\"");
            }
            DataCtx.EventsCatalog.RemoveAt(Id);
        }


        // StateDescription C.R.U.D. methods

        public void addStateDescription(StateDescription state)
        {
            DataCtx.StatesCatalog.Add(state);
        }

        public StateDescription getStateDescription(int Id)
        {
            if (Id > DataCtx.StatesCatalog.Count - 1 || Id < 0)
            {
                throw new KeyNotFoundException("StatesCatalog does not contain such ID - \"" + Id + "\"");
            }
            return DataCtx.StatesCatalog[Id];
        }

        public List<StateDescription> getAllStateDescriptions()
        {
            return DataCtx.StatesCatalog;
        }

        public void updateStateDescription(int Id, StateDescription state)
        {
            if (Id > DataCtx.StatesCatalog.Count - 1 || Id < 0)
            {
                throw new KeyNotFoundException("StatesCatalog does not contain such ID - \"" + Id + "\"");
            }
            DataCtx.StatesCatalog[Id] = state;
        }

        public void removeStateDescription(int Id)
        {
            if (Id > DataCtx.StatesCatalog.Count - 1 || Id < 0)
            {
                throw new KeyNotFoundException("StatesCatalog does not contain such ID - \"" + Id + "\"");
            }
            DataCtx.StatesCatalog.RemoveAt(Id);
        }
    }
}
