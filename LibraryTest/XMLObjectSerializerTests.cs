using Library.Interfaces;
using Library.Model;
using Library.Serializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTest
{
    [TestClass]
    public class XMLObjectSerializerTests
    {
        private static readonly string FILENAME = "XmlData/DataContextData.xml";

        [TestMethod]
        public void serializeObjectXMLTest()
        {
            IDataFiller filler = new LargeDataFillerImpl();
            DataRepository dataRepo = new DataRepository(filler);
            dataRepo.setDataContext();
            XMLObjectSerializer<DataContext>.Serialize(dataRepo.getDataContext(), FILENAME);
        }

        [TestMethod]
        public void deserializeObjectXMLTest()
        {
            DataContext dataCtx = XMLObjectSerializer<DataContext>.Deserialize(FILENAME);
        }
    }
}
