using System.Runtime.Serialization;
using zadanie1;

namespace Library
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

        public virtual void Deserialize(string[] data, SerializeHelper helper)
        {
            this.Item = helper.ItemsDictionary[data[2]];
        }
    }
}
