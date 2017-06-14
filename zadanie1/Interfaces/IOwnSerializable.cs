using System.Runtime.Serialization;
using Library.Serializers;

namespace Library.Interfaces
{
    public interface IOwnSerializable
    {
        string Serialize(ObjectIDGenerator idGenerator);

        bool Deserialize(string[] data, SerializeHelper helper);
    }
}
