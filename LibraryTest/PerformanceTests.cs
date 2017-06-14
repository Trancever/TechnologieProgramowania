using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;
using Library.Interfaces;
using Library.Model;
using Library.Serializers;

namespace LibraryTest
{
    [TestClass]
    public class PerformanceTests
    {
        [TestMethod]
        public void performanceTest()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            var watch = new Stopwatch();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            watch.Start();
            dataFiller1 = new LargeDataFillerImpl();
            dataFiller1.GetPeopleList();
            dataFiller1.GetItemsList();
            dataFiller1.GetStatesList();
            dataFiller1.GetEventsList();
            watch.Stop();

            Console.WriteLine("LargeDataFiller time = {0}",watch.Elapsed.TotalMilliseconds);

            watch.Reset();

            watch.Start();
            dataFiller2 = new LargeJsonDataFillerImpl();
            dataFiller2.GetPeopleList();
            dataFiller2.GetItemsList();
            dataFiller2.GetStatesList();
            dataFiller2.GetEventsList();
            watch.Stop();

            Console.WriteLine("LargeJsonDataFiller time = {0}", watch.Elapsed.TotalMilliseconds);

            watch.Reset();

            watch.Start();
            XMLObjectSerializer<DataContext>.Deserialize("XmlData/DataContextData.xml");
            watch.Stop();

            Console.WriteLine("XmlSerializer time = {0}", watch.Elapsed.TotalMilliseconds);

            watch.Reset();

            watch.Start();
            OwnSerializer.Deserialize("OwnSerializerData/SerializedData.data");
            watch.Stop();

            Console.WriteLine("OwnSerializer time = {0}", watch.Elapsed.TotalMilliseconds);
        }

        IDataFiller dataFiller1, dataFiller2;
    }
}
