using System;
using System.Globalization;
using System.Runtime.Serialization;
using zadanie1;

namespace Library
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
            data += this.HireDate.ToShortDateString();

            return data;
        }

        public virtual void Deserialize(string[] data, SerializeHelper helper)
        {
            this.StateDescription = helper.StatesDictionary[data[2]];
            this.Person = helper.PeopleDictionary[data[3]];
            this.HireDate = DateTime.ParseExact(data[4], "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }
    }
}
