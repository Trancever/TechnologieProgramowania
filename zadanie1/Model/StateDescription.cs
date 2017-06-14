using System;
using System.Runtime.Serialization;
using Library.Interfaces;
using Library.Serializers;


namespace Library.Model
{
    [DataContract]
    [KnownType(typeof(BookDescription))]
    public class StateDescription : IOwnSerializable
    {
        public StateDescription(Item item)
        {
            Item = item;
        }

        public StateDescription() { }

        [DataMember]
        public Item Item { get; protected set; }

        public virtual string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";

            data += this.GetType().FullName + ",";
            data += idGenerator.GetId(this, out bool firstTime) + ",";
            data += idGenerator.GetId(Item, out firstTime).ToString();

            return data;
        }

        public virtual bool Deserialize(string[] data, SerializeHelper helper)
        {
            if (this.GetType().GetProperties().Length != data.Length - 2) return false;
            try
            {
                this.Item = helper.ItemsDictionary[data[2]];
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
