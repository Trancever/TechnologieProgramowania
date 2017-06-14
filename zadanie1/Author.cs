using System.Runtime.Serialization;

namespace Library
{
    [DataContract]
    public class Author : Person
    {
        public Author(string firstName, string lastName, int age, string address) : base(firstName, lastName, age, address)
        {

        }

        public Author() : base()
        {
        }

        public override string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";
            data += this.GetType().FullName + ",";
            data += idGenerator.GetId(this, out bool firstTime) + ",";
            data += this.FirstName + ",";
            data += this.LastName + ",";
            data += this.Age.ToString() + ",";
            data += this.Address;
            return data;
        }

        public override void Deserialize(string[] data, SerializeHelper helper)
        {
            this.FirstName = data[2];
            this.LastName = data[3];
            this.Age = int.Parse(data[4]);
            this.Address = data[5];
        }
    }
}
