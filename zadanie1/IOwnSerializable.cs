using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace zadanie1
{
    public interface IOwnSerializable
    {
        string Serialize(ObjectIDGenerator idGenerator);

        void Deserialize(string[] data, SerializeHelper helper);
    }
}
