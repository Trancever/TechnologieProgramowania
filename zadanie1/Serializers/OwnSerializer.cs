using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Library.Model;

namespace Library.Serializers
{
    public class OwnSerializer
    {
        public static void Serialize(DataContext dataContext, string filename)
        {
            string data = "";
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            bool firstTime = false;
            foreach (Person person in dataContext.PeopleCatalog)
            {
                data += person.Serialize(idGenerator) + "\n";
            }

            foreach (Item item in dataContext.ItemsCatalog.Values)
            {
                data += item.Serialize(idGenerator) + "\n";
            }

            foreach (StateDescription state in dataContext.StatesCatalog)
            {
                data += state.Serialize(idGenerator) + "\n";
            }

            foreach (Event ev in dataContext.EventsCatalog)
            {
                data += ev.Serialize(idGenerator) + "\n";
            }

            System.IO.File.WriteAllText(filename, data);
        }

        public static DataContext Deserialize(string filename)
        {
            DataContext dataContext = new DataContext();
            SerializeHelper helper = new SerializeHelper();
            string data = System.IO.File.ReadAllText(filename);

            var dataList = data.Split('\n');
            for (int i = 0; i < dataList.Length; i++)
            {
                if (!string.IsNullOrEmpty(dataList[i]))
                {
                    var splittedLine = dataList[i].Split(',');

                    Type type = Type.GetType(splittedLine[0]);
                    if (type != null)
                    {
                        object obj = Activator.CreateInstance(type);

                        switch (helper.typeDict[type])
                        {
                            case 0:
                                Person person = (Person)obj;
                                if (!person.Deserialize(splittedLine, helper)) break;
                                helper.PeopleDictionary.Add(splittedLine[1], person);
                                dataContext.PeopleCatalog.Add(person);
                                break;

                            case 1:
                                Reader reader = (Reader)obj;
                                if (!reader.Deserialize(splittedLine, helper)) break;
                                helper.PeopleDictionary.Add(splittedLine[1], reader);
                                dataContext.PeopleCatalog.Add(reader);
                                break;

                            case 2:
                                Author author = (Author)obj;
                                if (!author.Deserialize(splittedLine, helper)) break;
                                helper.PeopleDictionary.Add(splittedLine[1], author);
                                dataContext.PeopleCatalog.Add(author);
                                break;

                            case 3:
                                Item item = (Item)obj;
                                if (!item.Deserialize(splittedLine, helper)) break;
                                helper.ItemsDictionary.Add(splittedLine[1], item);
                                dataContext.ItemsCatalog.Add(item.Id, item);
                                break;

                            case 4:
                                Book book = (Book)obj;
                                if (!book.Deserialize(splittedLine, helper)) break;
                                helper.ItemsDictionary.Add(splittedLine[1], book);
                                dataContext.ItemsCatalog.Add(book.Id, book);
                                break;

                            case 5:
                                StateDescription stateDescription = (StateDescription)obj;
                                if (!stateDescription.Deserialize(splittedLine, helper)) break;
                                helper.StatesDictionary.Add(splittedLine[1], stateDescription);
                                dataContext.StatesCatalog.Add(stateDescription);

                                break;

                            case 6:
                                BookDescription bookDescription = (BookDescription)obj;
                                if (!bookDescription.Deserialize(splittedLine, helper)) break;
                                helper.StatesDictionary.Add(splittedLine[1], bookDescription);
                                dataContext.StatesCatalog.Add(bookDescription);
                                break;

                            case 7:
                                Event ev = (Event)obj;
                                if (!ev.Deserialize(splittedLine, helper)) break;
                                dataContext.EventsCatalog.Add(ev);
                                break;

                            case 8:
                                Rental rental = (Rental)obj;
                                if (!rental.Deserialize(splittedLine, helper)) break;
                                dataContext.EventsCatalog.Add(rental);
                                break;
                        }
                    }
                }
            }
            return dataContext;
        }
    }


    public class SerializeHelper
    {
        public Dictionary<string, Person> PeopleDictionary = new Dictionary<string, Person>();
        public Dictionary<string, Item> ItemsDictionary = new Dictionary<string, Item>();
        public Dictionary<string, StateDescription> StatesDictionary = new Dictionary<string, StateDescription>();

        public IDictionary<Type, int> typeDict = new Dictionary<Type, int>
            {
                { typeof(Person), 0 },
                { typeof(Reader), 1 },
                { typeof(Author), 2 },
                { typeof(Item), 3 },
                { typeof(Book), 4 },
                { typeof(StateDescription), 5 },
                { typeof(BookDescription), 6 },
                { typeof(Event), 7 },
                { typeof(Rental), 8 },
            };
    }
}
