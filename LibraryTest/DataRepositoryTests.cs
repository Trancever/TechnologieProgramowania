using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Library.Interfaces;
using Library.Model;

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
        [ExpectedException(typeof(KeyNotFoundException), "Wrong key of book which we want to get from collection.")]
        public void getItemWithWrongKey()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.getItem("");
            Assert.Fail();
        }

        [TestMethod]
        public void getItemWithGoodKey()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Item item = new Book("", null, 0, "");
            dataRepository.AddItem(item);
            Assert.AreEqual<Item>(item, dataRepository.getItem(item.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong key of book which we want to remove from collection.")]
        public void removeItemWithWrongKey()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.removeItem("");
            Assert.Fail();
        }

        [TestMethod]
        public void removeItemWithGoodKey()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Item item = new Book("", null, 0, "");
            dataRepository.AddItem(item);
            Assert.AreEqual<int>(1, dataRepository.getAllItems().Count);
            dataRepository.removeItem(item.Id);
            Assert.AreEqual<int>(0, dataRepository.getAllItems().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong key of book which we want to update from collection.")]
        public void updateItemWithWrongKey()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Item item1 = new Book("", null, 0, "");
            Item item2 = new Book("", null, 0, "");
            dataRepository.AddItem(item1);
            dataRepository.updateItem("osakdokaskda", item2);
            Assert.Fail();
        }

        [TestMethod]
        public void updateItemWithGoodKey()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Item item1 = new Book("", null, 0, "");
            Item item2 = new Book("", null, 0, "");
            dataRepository.AddItem(item1);
            Assert.AreEqual<Item>(item1, dataRepository.getItem(item1.Id));
            dataRepository.updateItem(item1.Id, item2);
            Assert.AreEqual<Item>(item2, dataRepository.getItem(item1.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong ID of person which we want to get from collection.")]
        public void getPersonWithWrongId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.getPerson(1);
            Assert.Fail();
        }

        [TestMethod]
        public void getPersonWithGoodId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Reader reader = new Reader("", "", 0, "");
            dataRepository.addPerson(reader);
            Assert.AreEqual<Person>(reader, dataRepository.getPerson(0));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong ID of person which we want to remove from collection.")]
        public void removePersonWithWrongId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.removePerson(1);
            Assert.Fail();
        }

        [TestMethod]
        public void removePersonWithGoodId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Person reader = new Reader("", "", 0, "");
            dataRepository.addPerson(reader);
            Assert.AreEqual<int>(1, dataRepository.getAllPeople().Count);
            dataRepository.removePerson(0);
            Assert.AreEqual<int>(0, dataRepository.getAllPeople().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong ID of person which we want to update from collection.")]
        public void updatePersonWithWrongId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Person reader1 = new Reader("", "", 0, "");
            Person reader2 = new Reader("", "", 0, "");
            dataRepository.addPerson(reader1);
            dataRepository.updatePerson(1, reader2);
            Assert.Fail();
        }

        [TestMethod]
        public void updatePersonWithGoodId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Person reader1 = new Reader("", "", 0, "");
            Person reader2 = new Reader("", "", 0, "");
            dataRepository.addPerson(reader1);
            Assert.AreEqual<Person>(reader1, dataRepository.getPerson(0));
            dataRepository.updatePerson(0, reader2);
            Assert.AreEqual<Person>(reader2, dataRepository.getPerson(0));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong ID of event which we want to get from collection.")]
        public void getEventWithWrongId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.getEvent(1);
            Assert.Fail();
        }

        [TestMethod]
        public void getEventWithGoodId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Person reader = new Reader("", "", 0, "");
            Item book = new Book("", null, 0, "");
            StateDescription state = new BookDescription(book, "", new DateTime(1990, 1, 1), Purpose.All, Kind.Criminal);
            Event ev = new Rental(state, reader, DateTime.Now);
            dataRepository.addEvent(ev);
            Assert.AreEqual<Event>(ev, dataRepository.getEvent(0));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong ID of event which we want to remove from collection.")]
        public void removeEventWithWrongId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.removeEvent(1);
            Assert.Fail();
        }

        [TestMethod]
        public void removeEventWithGoodId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Person reader = new Reader("", "", 0, "");
            Item book = new Book("", null, 0, "");
            StateDescription state = new BookDescription(book, "", new DateTime(1990, 1, 1), Purpose.All, Kind.Criminal);
            Event ev = new Rental(state, reader, DateTime.Now);

            dataRepository.addEvent(ev); 
            Assert.AreEqual<int>(1, dataRepository.getAllEvents().Count);

            dataRepository.removeEvent(0);
            Assert.AreEqual<int>(0, dataRepository.getAllEvents().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong ID of event which we want to update from collection.")]
        public void updateEventWithWrongId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Person reader = new Reader("", "", 0, "");
            Item book = new Book("", null, 0, "");
            StateDescription state = new BookDescription(book, "", new DateTime(1990, 1, 1), Purpose.All, Kind.Criminal);
            Event ev = new Rental(state, reader, DateTime.Now);
            dataRepository.updateEvent(1, ev);
            Assert.Fail();
        }

        [TestMethod]
        public void updateEventWithGoodId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Person reader1 = new Reader("", "", 0, "");
            Person reader2 = new Reader("", "", 0, "");
            Item book1 = new Book("", null, 0, "");
            Item book2 = new Book("", null, 0, "");
            StateDescription state1 = new BookDescription(book1, "", new DateTime(1990, 1, 1), Purpose.All, Kind.Criminal);
            StateDescription state2 = new BookDescription(book2, "", new DateTime(1990, 1, 1), Purpose.All, Kind.Criminal);
            Event ev1 = new Rental(state1, reader1, DateTime.Now);
            Event ev2 = new Rental(state2, reader2, DateTime.Now);

            dataRepository.addEvent(ev1);
            Assert.AreEqual<Event>(ev1, dataRepository.getEvent(0));
            dataRepository.updateEvent(0, ev2);
            Assert.AreEqual<Event>(ev2, dataRepository.getEvent(0));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong ID of state description which we want to get from collection.")]
        public void getStateWithWrongId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.getStateDescription(1);
            Assert.Fail();
        }

        [TestMethod]
        public void getStateWithGoodId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Person reader = new Reader("", "", 0, "");
            Item book = new Book("", null, 0, "");
            StateDescription state = new BookDescription(book, "", new DateTime(1990, 1, 1), Purpose.All, Kind.Criminal);

            dataRepository.addStateDescription(state);
            Assert.AreEqual<StateDescription>(state, dataRepository.getStateDescription(0));
        }


        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong ID of state description which we want to remove from collection.")]
        public void removeStateWithWrongId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            dataRepository.removeStateDescription(1);
            Assert.Fail();
        }

        [TestMethod]
        public void removeStateWithGoodId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Person reader = new Reader("", "", 0, "");
            Item book = new Book("", null, 0, "");
            StateDescription state = new BookDescription(book, "", new DateTime(1990, 1, 1), Purpose.All, Kind.Criminal);

            dataRepository.addStateDescription(state);
            Assert.AreEqual<int>(1, dataRepository.getAllStateDescriptions().Count);

            dataRepository.removeStateDescription(0);
            Assert.AreEqual<int>(0, dataRepository.getAllStateDescriptions().Count);
        }


        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Wrong ID of state description which we want to update from collection.")]
        public void updateStateWithWrongId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Person reader = new Reader("", "", 0, "");
            Item book = new Book("", null, 0, "");
            StateDescription state = new BookDescription(book, "", new DateTime(1990, 1, 1), Purpose.All, Kind.Criminal);
            dataRepository.updateStateDescription(1, state);
            Assert.Fail();
        }

        [TestMethod]
        public void updateStateWithGoodId()
        {
            DataRepository dataRepository = this.CreateDataRepository();
            Person reader1 = new Reader("", "", 0, "");
            Person reader2 = new Reader("", "", 0, "");
            Item book1 = new Book("", null, 0, "");
            Item book2 = new Book("", null, 0, "");
            StateDescription state1 = new BookDescription(book1, "", new DateTime(1990, 1, 1), Purpose.All, Kind.Criminal);
            StateDescription state2 = new BookDescription(book2, "", new DateTime(1990, 1, 1), Purpose.All, Kind.Criminal);

            dataRepository.addStateDescription(state1);
            Assert.AreEqual<StateDescription>(state1, dataRepository.getStateDescription(0));

            dataRepository.updateStateDescription(0, state2);
            Assert.AreEqual<StateDescription>(state2, dataRepository.getStateDescription(0));
        }


        private DataRepository CreateDataRepository()
        {
            return new DataRepository(this.mockDataFiller.Object);
        }
    }
}