using System;
using System.Runtime.Serialization;
using zadanie1;

namespace Library
{
    [DataContract]
    [KnownType(typeof(Reader))]
    public class Person : IOwnSerializable
    {
        public Person(string firstName, string lastName, int age, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
        }

        public Person() : base()
        {
        }

        [DataMember]
        public string FirstName { get; protected set; }
        [DataMember]
        public string LastName {get; protected set; }
        [DataMember]
        public int Age {get; protected set; }
        [DataMember]
        public string Address {get; protected set; }

        public virtual string Serialize(ObjectIDGenerator idGenerator)
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

        public virtual void Deserialize(string[] data, SerializeHelper helper)
        {
            this.FirstName = data[2];
            this.LastName = data[3];
            this.Age = int.Parse(data[4]);
            this.Address = data[5];
        }
    }
}
