```

BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.7171)
12th Gen Intel Core i5-12450H 2.00GHz, 1 CPU, 12 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3

Job=.NET 10.0  Runtime=.NET 10.0  

```
| Method                 | DriverCount | Mean         | Error       | StdDev      | Gen0    | Allocated |
|----------------------- |------------ |-------------:|------------:|------------:|--------:|----------:|
| QuickSortBenchmark     | 100         |     534.4 μs |     4.17 μs |     3.26 μs |       - |   1.13 KB |
| InsertionSortBenchmark | 100         |     541.6 μs |     9.01 μs |    13.21 μs |       - |   1.15 KB |
| QuickSortBenchmark     | 1000        |     544.1 μs |     5.58 μs |     4.35 μs |  0.9766 |   8.19 KB |
| BubbleSortBenchmark    | 100         |     548.1 μs |    10.88 μs |    11.65 μs |       - |   1.15 KB |
| InsertionSortBenchmark | 1000        |     580.5 μs |     8.53 μs |     7.12 μs |  0.9766 |   8.19 KB |
| QuickSortBenchmark     | 10000       |   1,206.2 μs |     9.90 μs |     9.26 μs | 11.7188 |   78.5 KB |
| BubbleSortBenchmark    | 1000        |   2,136.2 μs |    25.22 μs |    23.59 μs |       - |   8.15 KB |
| InsertionSortBenchmark | 10000       |  42,180.8 μs |   321.46 μs |   300.69 μs |       - |   78.5 KB |
| BubbleSortBenchmark    | 10000       | 308,291.7 μs | 1,658.90 μs | 1,470.57 μs |       - |   78.5 KB |
