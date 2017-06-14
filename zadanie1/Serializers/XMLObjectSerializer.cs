using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Library.Serializers
{
    public class XMLObjectSerializer<T>
    {
        public static T Deserialize(string filename)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using (var reader = XmlReader.Create(filename))
            {
                return (T) serializer.ReadObject(reader);
            }
        }

        public static void Serialize(T obj, string filename)
        {
            var serializer = new DataContractSerializer(typeof(T), 
                null,           /* known types */
                Int32.MaxValue, /* maxItemsInObjectGraph */
                false,          /* ignoreExtensionDataObject */
                true,           /* preserveObjectReferences !!! */
                null);          /* dataContractSurrogate */
            var settings = new XmlWriterSettings() {Indent = true};
            using (var writer = XmlWriter.Create(filename, settings))
            {
                serializer.WriteObject(writer, obj);
            }
        }
    }
}
