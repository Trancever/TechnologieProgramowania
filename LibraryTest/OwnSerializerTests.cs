using Library.Interfaces;
using Library.Model;
using Library.Serializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTest
{
    [TestClass]
    public class OwnSerializerTests
    {
        private static readonly string FILENAME = "DataContextSerializedData.txt";

        [TestMethod]
        public void SameDataAfterDeserializing()
        {
            IDataFiller filler = new DataFillerImpl();
            DataRepository dataRepo = new DataRepository(filler);

            dataRepo.setDataContext();
            var dataCtxOriginal = dataRepo.getDataContext();
            OwnSerializer.Serialize(dataCtxOriginal, FILENAME);

            var dataCtxDeserialized = OwnSerializer.Deserialize(FILENAME);

            Assert.AreEqual(dataCtxOriginal.EventsCatalog[1].Person.LastName, dataCtxDeserialized.EventsCatalog[1].Person.LastName);
        }

        [TestMethod]
        public void SerializeReferenceTest()
        {
            IDataFiller filler = new DataFillerImpl();
            DataRepository repo = new DataRepository(filler);
            repo.setDataContext();
            OwnSerializer.Serialize(repo.getDataContext(), FILENAME);
            var originalDataCtx = repo.getDataContext();
            Assert.IsTrue(originalDataCtx.StatesCatalog[0].Item == originalDataCtx.ItemsCatalog[originalDataCtx.StatesCatalog[0].Item.Id]);

            var deserializedDataCtx = OwnSerializer.Deserialize(FILENAME);

            Assert.IsTrue(deserializedDataCtx.StatesCatalog[0].Item == deserializedDataCtx.ItemsCatalog[originalDataCtx.StatesCatalog[0].Item.Id]);
        }
    }
}
