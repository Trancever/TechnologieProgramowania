using System;
using System.Runtime.Serialization;
using zadanie1;

namespace Library
{
    [DataContract]
    [KnownType(typeof(Book))]
    public class Item : IOwnSerializable
    {
        public Item()
        {
            Id = Guid.NewGuid().ToString();
        }

        [DataMember]
        public string Id { get; protected set; }

        public virtual string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";
            data += this.GetType().FullName + ",";
            data += idGenerator.GetId(this, out bool firstTime) + ",";
            data += Id;
            return data;
        }

        public virtual void Deserialize(string[] data, SerializeHelper helper)
        {
            this.Id = data[2];
        }
    }
}
