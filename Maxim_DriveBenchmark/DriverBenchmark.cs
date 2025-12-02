using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using Maxim_Drive.DriverModel;
using Maxim_Drive.OrderModel;
using Maxim_Drive.SortModel;
using Maxim_Drive.MapModel;
using System;

namespace Maxim_Drive
{
    [SimpleJob(RuntimeMoniker.Net10_0)]
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]

    public class DriverBenchmark
    {
        private Driver[] _drivers;
        private Order _order;

        [Params(100, 1000, 10000)]
        public int DriverCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random();
            int mapLenght = 1000;
            int mapWidth = 1000;

            var map_b = new Map(mapLenght, mapWidth);
            string[,] map = map_b.BuildMap();


            _order = new Order(0, random.Next(0, mapLenght), random.Next(0, mapWidth));
            _drivers = new Driver[DriverCount];

            var occupiedCoords = new HashSet<(int x, int y)>();
            occupiedCoords.Add((_order.X, _order.Y));

            for (int i = 0; i < DriverCount; i++)
            {
                int x, y;
                do
                {
                    x = random.Next(0, mapWidth);
                    y = random.Next(0, mapWidth);
                } while (occupiedCoords.Contains((x, y)));
                occupiedCoords.Add((x, y));
                _drivers[i] = new Driver(i, x, y);
            }
        }

        [Benchmark]
        public void BubbleSortBenchmark()
        {
            var driversCopy = (Driver[])_drivers.Clone();
            SortAlgorithms.BubbleSort(driversCopy, _order);
        }

        [Benchmark]
        public void QuickSortBenchmark()
        {
            var driversCopy = (Driver[])_drivers.Clone();
            SortAlgorithms.QuickSort(driversCopy, _order);
        }

        [Benchmark]
        public void InsertionSortBenchmark()
        {
            var driversCopy = (Driver[])_drivers.Clone();
            SortAlgorithms.InsertionSort(driversCopy, _order);
        }
    }
}