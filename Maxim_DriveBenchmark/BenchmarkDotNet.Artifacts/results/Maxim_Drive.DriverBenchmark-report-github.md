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
| InsertionSortBenchmark | 100         |     547.6 μs |     3.66 μs |     2.86 μs |       - |   1.12 KB |
| QuickSortBenchmark     | 100         |     547.9 μs |     6.50 μs |     5.76 μs |       - |   1.12 KB |
| QuickSortBenchmark     | 1000        |     556.6 μs |     9.13 μs |     8.09 μs |  0.9766 |   8.15 KB |
| BubbleSortBenchmark    | 100         |     562.3 μs |     8.87 μs |     8.29 μs |       - |   1.12 KB |
| InsertionSortBenchmark | 1000        |     598.7 μs |     7.43 μs |     6.59 μs |  0.9766 |   8.15 KB |
| QuickSortBenchmark     | 10000       |   1,147.6 μs |     8.27 μs |     7.73 μs | 11.7188 |   78.5 KB |
| BubbleSortBenchmark    | 1000        |   2,290.5 μs |    24.57 μs |    22.98 μs |       - |   8.15 KB |
| InsertionSortBenchmark | 10000       |  42,493.0 μs |   297.35 μs |   278.14 μs |       - |  78.48 KB |
| BubbleSortBenchmark    | 10000       | 267,435.8 μs | 2,707.24 μs | 2,532.36 μs |       - |  78.48 KB |
