using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.Interfaces;
using Library.Model;
using Newtonsoft.Json;

namespace Library.Serializers
{
    public class JsonDataFillerImpl : IDataFiller
    {
        public ObservableCollection<Event> GetEventsList()
        {
            try
            {
                string jsonData = System.IO.File.ReadAllText(@"jsonData\eventsData.json");
                var eventsList = JsonConvert.DeserializeObject<ObservableCollection<Event>>(jsonData);
                return eventsList;
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("eventsData.json file not found. Returning empty list.");
                return new ObservableCollection<Event>();
            }
            catch (JsonSerializationException e)
            {
                Console.WriteLine("Error while deserializing eventsData.json file. Returning empty list.");
                return new ObservableCollection<Event>();
            }
        }

        public Dictionary<string, Item> GetItemsList()
        {
            try
            {
                string jsonData = System.IO.File.ReadAllText(@"jsonData\itemsData.json");
                var itemsList = JsonConvert.DeserializeObject<Dictionary<string, Item>>(jsonData);
                return itemsList;
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("itemsData.json file not found. Returning empty list.");
                return new Dictionary<string, Item>();
            }
            catch (JsonSerializationException e)
            {
                Console.WriteLine("Error while deserializing itemsData.json file. Returning empty list.");
                return new Dictionary<string, Item>();
            }
        }

        public List<Person> GetPeopleList()
        {
            try
            {
                string jsonData = System.IO.File.ReadAllText(@"jsonData\peopleData.json");
                var peopleList = JsonConvert.DeserializeObject<List<Person>>(jsonData);
                return peopleList;
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("peopleData.json file not found. Returning empty list.");
                return new List<Person>();
            }
            catch (JsonSerializationException e)
            {
                Console.WriteLine("Error while deserializing peopleData.json file. Returning empty list.");
                return new List<Person>();
            }
        }

        public List<StateDescription> GetStatesList()
        {
            try
            {
                string jsonData = System.IO.File.ReadAllText(@"jsonData\statesData.json");
                var statesList = JsonConvert.DeserializeObject<List<StateDescription>>(jsonData);
                return statesList;
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("statesData.json file not found. Returning empty list.");
                return new List<StateDescription>();
            }
            catch (JsonSerializationException e)
            {
                Console.WriteLine("Error while deserializing statesData.json file. Returning empty list.");
                return new List<StateDescription>();
            }
        }
    }
}
