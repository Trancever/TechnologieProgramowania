using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

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
        [ExpectedException(typeof(KeyNotFoundException), "Wrong id of book which we want to get from collection.")]
        public void getBookTestWithWrongId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.getBook(1);
        }

        [TestMethod]
        public void getBookWithGoodId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Book book = new Book("", "");
            dataRepository.AddBook(book);
            Assert.AreEqual<Book>(book, dataRepository.getBook(1));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong id of book which we want to remove from collection.")]
        public void removeBookWithWrongId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.removeBook(0);
        }

        [TestMethod]
        public void removeBookWithGoodId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.AddBook(new Book("", ""));
            Assert.AreEqual<int>(1, dataRepository.getAllBooks().Count);
            dataRepository.removeBook(1);
            Assert.AreEqual<int>(0, dataRepository.getAllBooks().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong id of book which we want to remove from collection.")]
        public void updateBookWithWrongId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.AddBook(new Book("", ""));
            dataRepository.updateBook(5, new Book("", ""));
        }

        [TestMethod]
        public void updateBookWithGoodId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.AddBook(new Book("", ""));
            dataRepository.AddBook(new Book("", ""));
            dataRepository.updateBook(2, new Book("", ""));
            Assert.AreEqual<long>(3, dataRepository.getBook(2).Id);
        }

        private DataRepository CreateDataRepository()
        {
            return new DataRepository(
                this.mockDataFiller.Object);
        }
    }
}