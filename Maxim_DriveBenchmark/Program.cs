using Maxim_Drive.DriverModel;
using Maxim_Drive.MapModel;
using Maxim_Drive.OrderModel;
using Maxim_Drive.SortModel;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Toolchains.CsProj;
using BenchmarkDotNet.Toolchains.DotNetCli;
using System.Reflection;
using BenchmarkDotNet.Columns;

namespace Maxim_Drive
{
    class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<DriverBenchmark>();
        }
    }
}