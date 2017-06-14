using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library
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
                    object obj = Activator.CreateInstance(type);

                    switch (splittedLine[0])
                    {
                        case "Library.Person":
                            Person person = (Person)obj;
                            person.Deserialize(splittedLine, helper);
                            helper.PeopleDictionary.Add(splittedLine[1], person);
                            dataContext.PeopleCatalog.Add(person);
                            break;

                        case "Library.Reader":
                            Reader reader = (Reader)obj;
                            reader.Deserialize(splittedLine, helper);
                            helper.PeopleDictionary.Add(splittedLine[1], reader);
                            dataContext.PeopleCatalog.Add(reader);
                            break;

                        case "Library.Author":
                            Author author = (Author)obj;
                            author.Deserialize(splittedLine, helper);
                            helper.PeopleDictionary.Add(splittedLine[1], author);
                            dataContext.PeopleCatalog.Add(author);
                            break;

                        case "Library.Item":
                            Item item = (Item)obj;
                            item.Deserialize(splittedLine, helper);
                            helper.ItemsDictionary.Add(splittedLine[1], item);
                            dataContext.ItemsCatalog.Add(item.Id, item);
                            break;

                        case "Library.Book":
                            Book book = (Book)obj;
                            book.Deserialize(splittedLine, helper);
                            helper.ItemsDictionary.Add(splittedLine[1], book);
                            dataContext.ItemsCatalog.Add(book.Id, book);
                            break;

                        case "Library.StateDescription":
                            StateDescription stateDescription = (StateDescription)obj;
                            stateDescription.Deserialize(splittedLine, helper);
                            helper.StatesDictionary.Add(splittedLine[1], stateDescription);
                            dataContext.StatesCatalog.Add(stateDescription);

                            break;

                        case "Library.BookDescription":
                            BookDescription bookDescription = (BookDescription)obj;
                            bookDescription.Deserialize(splittedLine, helper);
                            helper.StatesDictionary.Add(splittedLine[1], bookDescription);
                            dataContext.StatesCatalog.Add(bookDescription);
                            break;

                        case "Library.Event":
                            Event ev = (Event)obj;
                            ev.Deserialize(splittedLine, helper);
                            dataContext.EventsCatalog.Add(ev);
                            break;

                        case "Library.Rental":
                            Rental rental = (Rental)obj;
                            rental.Deserialize(splittedLine, helper);
                            dataContext.EventsCatalog.Add(rental);
                            break;
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
    }
}
