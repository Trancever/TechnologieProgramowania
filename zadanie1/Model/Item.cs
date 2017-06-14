using System;
using System.Runtime.Serialization;
using Library.Interfaces;
using Library.Serializers;

namespace Library.Model
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

        public virtual bool Deserialize(string[] data, SerializeHelper helper)
        {
            if (this.GetType().GetProperties().Length != data.Length - 2) return false;
            try
            {
                this.Id = data[2];
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
