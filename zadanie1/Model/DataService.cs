using System;
using System.Collections.Generic;

namespace Library.Model
{
    public class DataService
    {
        public DataService(DataRepository dataRepository)
        {
            DataRepository = dataRepository;
        }
        
        public List<Item> getAllItems()
        {
            return DataRepository.getAllItems();
        }

        public List<Person> getAllPeople()
        {
            return DataRepository.getAllPeople();
        }

        public List<StateDescription> getAllStateDescriptions()
        {
            return DataRepository.getAllStateDescriptions();
        }

        public List<Event> getAllEvents()
        {
            return DataRepository.getAllEvents();
        }

        public void addItem(Item item)
        {
            DataRepository.AddItem(item);
        }

        public void addPerson(Person person)
        {
            DataRepository.addPerson(person);
        }

        public void addStateDescription(StateDescription state)
        {
            DataRepository.addStateDescription(state);
        }

        public void addEvent(Event ev)
        {
            DataRepository.addEvent(ev);
        }

        public void removeItem(string key)
        {
            DataRepository.removeItem(key);
        }

        public void removePerson(int Id)
        {
            DataRepository.removePerson(Id);
        }

        public void removeStateDescription(int Id)
        {
            DataRepository.removeStateDescription(Id);
        }

        public void removeEvent(int Id)
        {
            DataRepository.removeEvent(Id);
        }

        public void updatePerson(int Id, Person person)
        {
            DataRepository.updatePerson(Id, person);
        }

        public void updateItem(string key, Item item)
        {
            DataRepository.updateItem(key, item);
        }

        public void updateStateDescription(int Id, StateDescription state)
        {
            DataRepository.updateStateDescription(Id, state);
        }

        public void updateEvent(int Id, Event ev)
        {
            DataRepository.updateEvent(Id, ev);
        }

        public List<Event> getAllEventsByPerson(Person person)
        {
            List<Event> tmp = DataRepository.getAllEvents();
            List<Event> res = new List<Event>();

            foreach (Event ev in tmp)
            {
                if (ev.Person == person)
                {
                    res.Add(ev);
                }
            }
            return res;
        }

        public List<Event> getAllEventsByStateDescription(StateDescription state)
        {
            List<Event> tmp = DataRepository.getAllEvents();
            List<Event> res = new List<Event>();

            foreach (Event ev in tmp)
            {
                if (ev.StateDescription == state)
                {
                    res.Add(ev);
                }
            }
            return res;
        }

        public List<Event> getAllEventsByDate(DateTime from, DateTime to)
        {
            List<Event> tmp = DataRepository.getAllEvents();
            List<Event> res = new List<Event>();

            foreach (Event ev in tmp)
            {
                if (ev.HireDate >= from && ev.HireDate <= to)
                {
                    res.Add(ev);
                }
            }
            return res;
        }

        public List<Event> getConnectedEvents(Event ev)
        {
            List<Event> tmp = DataRepository.getAllEvents();
            List<Event> res = new List<Event>();

            foreach (Event ev2 in tmp)
            {
                if (ev.Person == ev2.Person && ev.StateDescription.Item == ev2.StateDescription.Item)
                {
                    res.Add(ev2);
                }
            }
            return res;
        }

        public List<Person> getAllPeopleByFirstName(string name)
        {
            List<Person> tmp = DataRepository.getAllPeople();
            List<Person> res = new List<Person>();

            foreach (Person person in tmp)
            {
                if (person.FirstName == name)
                {
                    res.Add(person);
                }
            }
            return res;
        }

        public List<Person> getAllPeopleByLastName(string name)
        {
            List<Person> tmp = DataRepository.getAllPeople();
            List<Person> res = new List<Person>();

            foreach (Person person in tmp)
            {
                if (person.LastName == name)
                {
                    res.Add(person);
                }
            }
            return res;
        }

        public List<Person> getAllPeopleByAge(int age)
        {
            List<Person> tmp = DataRepository.getAllPeople();
            List<Person> res = new List<Person>();

            foreach (Person person in tmp)
            {
                if (person.Age == age)
                {
                    res.Add(person);
                }
            }
            return res;
        }

        public List<Person> getAllPeopleByAddress(string address)
        {
            List<Person> tmp = DataRepository.getAllPeople();
            List<Person> res = new List<Person>();

            foreach (Person person in tmp)
            {
                if (person.Address == address)
                {
                    res.Add(person);
                }
            }
            return res;
        }

        public List<Item> getAllItemsById(string Id)
        {
            List<Item> tmp = DataRepository.getAllItems();
            List<Item> res = new List<Item>();

            foreach (Item item in tmp)
            {
                if (item.Id == Id)
                {
                    res.Add(item);
                }
            }
            return res;
        }

        public List<StateDescription> getAllStatesByItem(Item item)
        {
            List<StateDescription> tmp = DataRepository.getAllStateDescriptions();
            List<StateDescription> res = new List<StateDescription>();

            foreach (StateDescription state in tmp)
            {
                if (state.Item == item)
                {
                    res.Add(state);
                }
            }
            return res;
        }

        public void addStateDescriptionByItem(Item item)
        {
            StateDescription tmp = new StateDescription(item);
            DataRepository.addStateDescription(tmp);
        }

        public void addEventByStateAndPerson(StateDescription state, Person person)
        {
            Event tmp = new Event(state, person, DateTime.Now);
            DataRepository.addEvent(tmp);
        }

        public void addEventByItemAndPerson(Item item, Person person)
        {
            StateDescription state = new StateDescription(item);
            Event tmp = new Event(state, person, DateTime.Now);
            DataRepository.addEvent(tmp);
        }

        private DataRepository DataRepository;
    }
}
