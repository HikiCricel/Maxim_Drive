using Maxim_Drive.DriverModel;
using Maxim_Drive.OrderModel;
using Maxim_Drive.SortModel;
using Maxim_Drive.MapModel;
using System;
using System.Linq;
using NUnit.Framework.Legacy;

namespace Maxim_Drive.Tests
{
    [TestFixture]
    public class EdgeCaseTests
    {
        private Order _testOrder;

        // Exactly 5 drivers
        [Test]
        public void AllSorts_Exactly5Drivers_SortsCorrectly()
        {
            _testOrder = new Order(0, 5, 5);

            int mapLenght = 10;
            int mapWidth = 10;

            var map_b = new Map(mapLenght, mapWidth);
            string[,] map = map_b.BuildMap();

            var drivers = new Driver[]
            {
                new Driver(4, 8, 5),
                new Driver(1, 5, 6),
                new Driver(5, 9, 5),
                new Driver(2, 6, 6),
                new Driver(3, 7, 5)
            };

            var eOrder = new int[] { 1, 2, 3, 4, 5 };

            // Testing BubbleSort
            var driversCopy1 = (Driver[])drivers.Clone();
            SortAlgorithms.BubbleSort(driversCopy1, _testOrder);
            var aOrder1 = driversCopy1.Take(5).Select(d => d.Id).ToArray();
            Assert.That(aOrder1, Is.EqualTo(eOrder), "BubbleSort failed for exactly 5 drivers");

            // Testing QuickSort
            var driversCopy2 = (Driver[])drivers.Clone();
            SortAlgorithms.QuickSort(driversCopy2, _testOrder);
            var aOrder2 = driversCopy2.Take(5).Select(d => d.Id).ToArray();
            Assert.That(aOrder2, Is.EqualTo(eOrder), "QuickSort failed for exactly 5 drivers");

            // Testing InsertionSort
            var driversCopy3 = (Driver[])drivers.Clone();
            SortAlgorithms.InsertionSort(driversCopy3, _testOrder);
            var aOrder3 = driversCopy3.Take(5).Select(d => d.Id).ToArray();
            Assert.That(aOrder3, Is.EqualTo(eOrder), "InsertionSort failed for exactly 5 drivers");
        }


        // Drivers at equal distance
        [Test]
        public void AllSorts_DriversAtEqualDistances_SortsCorrectly()
        {
            _testOrder = new Order(0, 5, 5);

            int mapLenght = 10;
            int mapWidth = 10;

            var map_b = new Map(mapLenght, mapWidth);
            string[,] map = map_b.BuildMap();

            var drivers = new Driver[]
            {
                new Driver(1, 5, 6),
                new Driver(2, 5, 4),
                new Driver(3, 4, 5),
                new Driver(4, 6, 5),
                new Driver(5, 6, 6),
                new Driver(6, 7, 6),
                new Driver(7, 6, 7)
            };

            var eOrder = new int[] { 1, 2, 3, 4, 5 };

            // Testing BubbleSort
            var driversCopy1 = (Driver[])drivers.Clone();
            SortAlgorithms.BubbleSort(driversCopy1, _testOrder);
            var firstFiveBubble = driversCopy1.Take(5).Select(d => d.Id).ToArray();
            CollectionAssert.AreEquivalent(eOrder, firstFiveBubble, "BubbleSort failed for equal coordinates");

            // Testing QuickSort
            var driversCopy2 = (Driver[])drivers.Clone();
            SortAlgorithms.QuickSort(driversCopy2, _testOrder);
            var firstFiveQuick = driversCopy2.Take(5).Select(d => d.Id).ToArray();
            CollectionAssert.AreEquivalent(eOrder, firstFiveQuick, "QuickSort failed for extreme coordinates");


            // Testing InsertionSort
            var driversCopy3 = (Driver[])drivers.Clone();
            SortAlgorithms.InsertionSort(driversCopy3, _testOrder);
            var firstFiveInsertion = driversCopy3.Take(5).Select(d => d.Id).ToArray();
            CollectionAssert.AreEquivalent(eOrder, firstFiveInsertion, "InsertionSort failed for extreme coordinates");
        }


        // Map boundaries test
        [Test]
        public void AllSorts_DriversAtExtremeCoords_SortsCorrectly()
        {
            _testOrder = new Order(0, 0, 0);

            int mapLenght = 10;
            int mapWidth = 10;

            var map_b = new Map(mapLenght, mapWidth);
            string[,] map = map_b.BuildMap();

            var drivers = new Driver[]
            {
                new Driver(1, 1, 0),
                new Driver(2, 0, 1),
                new Driver(3, 1, 1),
                new Driver(4, 0, 2),
                new Driver(5, 2, 0),
                new Driver(6, 10, 10),
            };

            var eOrder = new int[] { 1, 2, 3, 4, 5 };

            // Testing BubbleSort
            var driversCopy1 = (Driver[])drivers.Clone();
            SortAlgorithms.BubbleSort(driversCopy1, _testOrder);
            var aOrder1 = driversCopy1.Take(5).Take(5).Select(d => d.Id).ToArray();
            CollectionAssert.AreEquivalent(eOrder, aOrder1, "BubbleSort failed for extreme coordinates");

            // Testing QuickSort
            var driversCopy2 = (Driver[])drivers.Clone();
            SortAlgorithms.QuickSort(driversCopy2, _testOrder);
            var aOrder2 = driversCopy2.Take(5).Select(d => d.Id).ToArray();
            CollectionAssert.AreEquivalent(eOrder, aOrder1, "QuickSort failed for extreme coordinates");

            // Testing InsertionSort
            var driversCopy3 = (Driver[])drivers.Clone();
            SortAlgorithms.InsertionSort(driversCopy3, _testOrder);
            var aOrder3 = driversCopy3.Take(5).Select(d => d.Id).ToArray();
            CollectionAssert.AreEquivalent(eOrder, aOrder1, "InsertionSort failed for extreme coordinates");
        }
    }
}