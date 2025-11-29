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
        public int DriverCount{get; set;}

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random();

            _order = new Order(0, random.Next(0, DriverCount), random.Next(0, DriverCount));
            _drivers = new Driver[DriverCount];

            var occupiedCoords = new HashSet<(int x, int y)>();
            occupiedCoords.Add((_order.X, _order.Y));

            for (int i = 0; i < DriverCount; i++)
            {
                int x, y;
                do
                {
                    x = random.Next(0, 100);
                    y = random.Next(0, 100);
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