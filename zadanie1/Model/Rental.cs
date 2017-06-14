using System;
using System.Globalization;
using System.Runtime.Serialization;
using Library.Serializers;

namespace Library.Model
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
            data += this.HireDate.ToString("MM.dd.yyyy") + ",";
            data += this.ReturnDate.GetValueOrDefault().ToString("MM.dd.yyyy");

            return data;
        }

        public override bool Deserialize(string[] data, SerializeHelper helper)
        {
            if (this.GetType().GetProperties().Length != data.Length - 2) return false;
            try
            {
                this.StateDescription = helper.StatesDictionary[data[2]];
                this.Person = helper.PeopleDictionary[data[3]];
                this.HireDate = DateTime.ParseExact(data[4], "M.d.yyyy", CultureInfo.InvariantCulture);
                this.ReturnDate = DateTime.ParseExact(data[5], "M.d.yyyy", CultureInfo.InvariantCulture);
                if (this.ReturnDate.GetValueOrDefault().Year == 1)
                {
                    this.ReturnDate = null;
                }
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
