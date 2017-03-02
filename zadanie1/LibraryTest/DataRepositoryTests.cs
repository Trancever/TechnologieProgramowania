using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LibraryTest
{
    [TestClass]
    public class DataRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<IDataFiller> mockDataFiller;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockDataFiller = this.mockRepository.Create<IDataFiller>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void TestMethod1()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Assert.AreEqual(0, dataRepository.getAllBooks().Count);
        }

        private DataRepository CreateDataRepository()
        {
            return new DataRepository(
                this.mockDataFiller.Object);
        }
    }
}