using System;
using System.Reflection;
using System.Runtime.Serialization;
using Library.Serializers;

namespace Library.Model
{
    [DataContract]
    public class Book : Item
    {

        public Book(string name, Author author, int pages, string publishingHouse) : base()
        {
            Name = name;
            Author = author;
            Pages = pages;
            PublishingHouse = publishingHouse;
        }

        public Book() : base()
        {
            
        }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Author Author { get; set; }
        [DataMember]
        public int Pages { get; set; }
        [DataMember]
        public string PublishingHouse { get; set; }

        public override string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";

            data += this.GetType().FullName + ",";
            data += idGenerator.GetId(this, out bool firstTime) + ",";
            data += this.Id + ",";
            data += this.Name + ",";
            data += idGenerator.GetId(Author, out firstTime).ToString() + ",";
            data += this.Pages.ToString() + ",";
            data += this.PublishingHouse;
            return data;
        }

        public override bool Deserialize(string[] data, SerializeHelper helper)
        {
            if (this.GetType().GetProperties().Length != data.Length - 2) return false;
            try
            {
                this.Id = data[2];
                this.Name = data[3];
                this.Author = (Author) helper.PeopleDictionary[data[4]];
                this.Pages = int.Parse(data[5]);
                this.PublishingHouse = data[6];
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }
    }
}
