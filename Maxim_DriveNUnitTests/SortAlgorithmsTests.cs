using Maxim_Drive.DriverModel;
using Maxim_Drive.OrderModel;
using Maxim_Drive.SortModel;
using Maxim_Drive.MapModel;

namespace Maxim_Drive.Tests
{
    [TestFixture]
    public class SortAlgorithmsTests
    {
        private Order _testOrder;

        [SetUp]
        public void Setup()
        {
            _testOrder = new Order(0, 5, 5);

            int mapLenght = 10;
            int mapWidth = 10;

            var map_b = new Map(mapLenght, mapWidth);
            string[,] map = map_b.BuildMap();

        }

        // --- Tests for BubbleSort ---
        [Test]
        public void BubbleSort_EmptyArray_DoesNotThrow()
        {
            var drivers = Array.Empty<Driver>();
            SortAlgorithms.BubbleSort(drivers, _testOrder);
            Assert.That(drivers, Is.Empty);
        }

        [Test]
        public void BubbleSort_SingleElement_ArrayUnchanged()
        {
            var drivers = new Driver[] { new Driver(1, 6, 6) };
            var expectedX = drivers[0].X;
            var expectedY = drivers[0].Y;
            var expectedId = drivers[0].Id;

            SortAlgorithms.BubbleSort(drivers, _testOrder);

            Assert.Multiple(() =>
            {
                Assert.That(drivers[0].X, Is.EqualTo(expectedX));
                Assert.That(drivers[0].Y, Is.EqualTo(expectedY));
                Assert.That(drivers[0].Id, Is.EqualTo(expectedId));
            });
        }

        [Test]
        public void BubbleSort_SortedArray_RemainsSorted()
        {
            var farDriver = new Driver(3, 10, 10);
            var midDriver = new Driver(2, 8, 8);
            var closeDriver = new Driver(1, 6, 6);

            var drivers = new Driver[] { closeDriver, midDriver, farDriver };

            SortAlgorithms.BubbleSort(drivers, _testOrder);

            Assert.Multiple(() =>
            {
                Assert.That(drivers[0].Id, Is.EqualTo(1));
                Assert.That(drivers[1].Id, Is.EqualTo(2));
                Assert.That(drivers[2].Id, Is.EqualTo(3));
            });
        }

        [Test]
        public void BubbleSort_UnsortedArray_BecomesSorted()
        {
            var farDriver = new Driver(3, 10, 10);
            var closeDriver = new Driver(1, 6, 6);
            var midDriver = new Driver(2, 8, 8);

            var drivers = new Driver[] { farDriver, closeDriver, midDriver };

            SortAlgorithms.BubbleSort(drivers, _testOrder);

            Assert.Multiple(() =>
            {
                Assert.That(drivers[0].Id, Is.EqualTo(1));
                Assert.That(drivers[1].Id, Is.EqualTo(2));
                Assert.That(drivers[2].Id, Is.EqualTo(3));
            });
        }

        // --- Tests for QuickSort ---
        [Test]
        public void QuickSort_EmptyArray_DoesNotThrow()
        {
            var drivers = Array.Empty<Driver>();
            SortAlgorithms.QuickSort(drivers, _testOrder);
            Assert.That(drivers, Is.Empty);
        }

        [Test]
        public void QuickSort_SingleElement_ArrayUnchanged()
        {
            var drivers = new Driver[] { new Driver(1, 6, 6) };
            var expectedX = drivers[0].X;
            var expectedY = drivers[0].Y;
            var expectedId = drivers[0].Id;

            SortAlgorithms.QuickSort(drivers, _testOrder);

            Assert.Multiple(() =>
            {
                Assert.That(drivers[0].X, Is.EqualTo(expectedX));
                Assert.That(drivers[0].Y, Is.EqualTo(expectedY));
                Assert.That(drivers[0].Id, Is.EqualTo(expectedId));
            });
        }

        [Test]
        public void QuickSort_SortedArray_RemainsSorted()
        {
            var farDriver = new Driver(3, 10, 10);
            var midDriver = new Driver(2, 8, 8);
            var closeDriver = new Driver(1, 6, 6);

            var drivers = new Driver[] { closeDriver, midDriver, farDriver };

            SortAlgorithms.QuickSort(drivers, _testOrder);

            Assert.Multiple(() =>
            {
                Assert.That(drivers[0].Id, Is.EqualTo(1));
                Assert.That(drivers[1].Id, Is.EqualTo(2));
                Assert.That(drivers[2].Id, Is.EqualTo(3));
            });
        }

        [Test]
        public void QuickSort_UnsortedArray_BecomesSorted()
        {
            var farDriver = new Driver(3, 10, 10);
            var closeDriver = new Driver(1, 6, 6);
            var midDriver = new Driver(2, 8, 8);

            var drivers = new Driver[] { farDriver, closeDriver, midDriver };

            SortAlgorithms.QuickSort(drivers, _testOrder);

            Assert.Multiple(() =>
            {
                Assert.That(drivers[0].Id, Is.EqualTo(1));
                Assert.That(drivers[1].Id, Is.EqualTo(2));
                Assert.That(drivers[2].Id, Is.EqualTo(3));
            });
        }

        // --- Tests for InsertionSort ---
        [Test]
        public void InsertionSort_EmptyArray_DoesNotThrow()
        {
            var drivers = Array.Empty<Driver>();
            SortAlgorithms.InsertionSort(drivers, _testOrder);
            Assert.That(drivers, Is.Empty);
        }

        [Test]
        public void InsertionSort_SingleElement_ArrayUnchanged()
        {
            var drivers = new Driver[] { new Driver(1, 6, 6) };
            var expectedX = drivers[0].X;
            var expectedY = drivers[0].Y;
            var expectedId = drivers[0].Id;

            SortAlgorithms.InsertionSort(drivers, _testOrder);

            Assert.Multiple(() =>
            {
                Assert.That(drivers[0].X, Is.EqualTo(expectedX));
                Assert.That(drivers[0].Y, Is.EqualTo(expectedY));
                Assert.That(drivers[0].Id, Is.EqualTo(expectedId));
            });
        }

        [Test]
        public void InsertionSort_SortedArray_RemainsSorted()
        {
            var farDriver = new Driver(3, 10, 10);
            var midDriver = new Driver(2, 8, 8);
            var closeDriver = new Driver(1, 6, 6);

            var drivers = new Driver[] { closeDriver, midDriver, farDriver };

            SortAlgorithms.InsertionSort(drivers, _testOrder);

            Assert.Multiple(() =>
            {
                Assert.That(drivers[0].Id, Is.EqualTo(1));
                Assert.That(drivers[1].Id, Is.EqualTo(2));
                Assert.That(drivers[2].Id, Is.EqualTo(3));
            });
        }

        [Test]
        public void InsertionSort_UnsortedArray_BecomesSorted()
        {
            var farDriver = new Driver(3, 10, 10);
            var closeDriver = new Driver(1, 6, 6);
            var midDriver = new Driver(2, 8, 8);

            var drivers = new Driver[] { farDriver, closeDriver, midDriver };

            SortAlgorithms.InsertionSort(drivers, _testOrder);

            Assert.Multiple(() =>
            {
                Assert.That(drivers[0].Id, Is.EqualTo(1));
                Assert.That(drivers[1].Id, Is.EqualTo(2));
                Assert.That(drivers[2].Id, Is.EqualTo(3));
            });
        }

        // --- Test for all Algorithms---
        [Test]
        [TestCaseSource(nameof(GetSortMethods))]
        public void AllSorts_SameResult(Action<Driver[], Order> sortMethod)
        {
            var farDriver = new Driver(3, 10, 10);
            var closeDriver = new Driver(1, 6, 6);
            var midDriver = new Driver(2, 8, 8);

            var originalDrivers = new Driver[] { farDriver, closeDriver, midDriver };
            var expectedOrder = new int[] { 1, 2, 3 };

            var driversCopy1 = (Driver[])originalDrivers.Clone();
            var driversCopy2 = (Driver[])originalDrivers.Clone();
            var driversCopy3 = (Driver[])originalDrivers.Clone();

            SortAlgorithms.BubbleSort(driversCopy1, _testOrder);
            SortAlgorithms.QuickSort(driversCopy2, _testOrder);
            SortAlgorithms.InsertionSort(driversCopy3, _testOrder);

            var actualOrder1 = driversCopy1.Select(d => d.Id).ToArray();
            var actualOrder2 = driversCopy2.Select(d => d.Id).ToArray();
            var actualOrder3 = driversCopy3.Select(d => d.Id).ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(actualOrder1, Is.EqualTo(expectedOrder));
                Assert.That(actualOrder2, Is.EqualTo(expectedOrder));
                Assert.That(actualOrder3, Is.EqualTo(expectedOrder));
            });
        }

        // Вспомогательный метод для TestCaseSource
        private static IEnumerable<Action<Driver[], Order>> GetSortMethods()
        {
            yield return SortAlgorithms.BubbleSort;
            yield return SortAlgorithms.QuickSort;
            yield return SortAlgorithms.InsertionSort;
        }
    }
}