using System;
using System.Runtime.Serialization;
using Library.Serializers;


namespace Library.Model
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

        public override bool Deserialize(string[] data, SerializeHelper helper)
        {
            if (this.GetType().GetProperties().Length != data.Length - 2) return false;
            try
            {
                this.FirstName = data[2];
                this.LastName = data[3];
                this.Age = int.Parse(data[4]);
                this.Address = data[5];
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
