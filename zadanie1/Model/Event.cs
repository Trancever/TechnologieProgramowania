using System;
using System.Globalization;
using System.Runtime.Serialization;
using Library.Interfaces;
using Library.Serializers;

namespace Library.Model
{
    [DataContract]
    [KnownType(typeof(Rental))]
    public class Event : IOwnSerializable
    {
        public Event(StateDescription stateDescription, Person person, DateTime hireDate)
        {
            StateDescription = stateDescription;
            Person = person;
            HireDate = hireDate;
        }
        public Event() { }
        [DataMember]
        public StateDescription StateDescription { get; protected set; }
        [DataMember]
        public Person Person { get; protected set; }
        [DataMember]
        public DateTime HireDate { get; protected set; }

        public virtual string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";

            data += this.GetType().FullName + ",";
            data += idGenerator.GetId(this, out bool firstTime) + ",";
            data += idGenerator.GetId(StateDescription, out firstTime) + ",";
            data += idGenerator.GetId(Person, out firstTime) + ",";
            data += this.HireDate.ToString("MM.dd.yyyy");

            return data;
        }

        public virtual bool Deserialize(string[] data, SerializeHelper helper)
        {
            if (this.GetType().GetProperties().Length != data.Length - 2) return false;
            try
            {
                this.StateDescription = helper.StatesDictionary[data[2]];
                this.Person = helper.PeopleDictionary[data[3]];
                this.HireDate = DateTime.ParseExact(data[4], "M.d.yyyy", CultureInfo.InvariantCulture);
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
