using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Library
{
    [DataContract]
    public class Rental : Event
    {
        public Rental(StateDescription stateDescription, Person person, DateTime hireDate) : 
            base(stateDescription, person, hireDate)
        {
            ReturnDate = null;
        }

        public Rental() : base()
        {
        }

        [DataMember]
        public DateTime? ReturnDate { get; set; }

        public override string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";

            data += this.GetType().FullName + ",";
            data += idGenerator.GetId(this, out bool firstTime) + ",";
            data += idGenerator.GetId(StateDescription, out firstTime) + ",";
            data += idGenerator.GetId(Person, out firstTime) + ",";
            data += this.HireDate.ToShortDateString() + ",";
            data += this.ReturnDate.GetValueOrDefault().ToShortDateString();

            return data;
        }

        public override void Deserialize(string[] data, SerializeHelper helper)
        {
            this.StateDescription = helper.StatesDictionary[data[2]];
            this.Person = helper.PeopleDictionary[data[3]];
            this.HireDate = DateTime.ParseExact(data[4], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            this.ReturnDate = DateTime.ParseExact(data[5], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            if (this.ReturnDate.GetValueOrDefault().Year == 1)
            {
                this.ReturnDate = null;
            }
        }
    }
}
