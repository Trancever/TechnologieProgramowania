using System.Runtime.Serialization;

namespace Library
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

        public override void Deserialize(string[] data, SerializeHelper helper)
        {
            this.Id = data[2];
            this.Name = data[3];
            this.Author = (Author) helper.PeopleDictionary[data[4]];
            this.Pages = int.Parse(data[5]);
            this.PublishingHouse = data[6];
        }
    }
}
