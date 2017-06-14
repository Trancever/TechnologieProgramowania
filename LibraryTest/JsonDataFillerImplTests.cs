using Library.Interfaces;
using Library.Serializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTest
{
    [TestClass()]
    public class JsonDataFillerImplTests
    {

        IDataFiller DataFiller;

        [TestMethod()]
        public void getEventsListSizeTest()
        {
            Assert.AreEqual(DataFiller.GetEventsList().Count, 2);
        }

        [TestMethod()]
        public void getItemsListSizeTest()
        {
            Assert.AreEqual(DataFiller.GetItemsList().Count, 3);
        }

        [TestMethod()]
        public void getPeopleListSizeTest()
        {
            Assert.AreEqual(DataFiller.GetPeopleList().Count, 2);
        }

        [TestMethod()]
        public void getStatesDescriptionListSizeTest()
        {
            Assert.AreEqual(DataFiller.GetStatesList().Count, 3);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            this.DataFiller = new JsonDataFillerImpl();
        }
    }
}