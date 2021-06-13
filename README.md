[![.NET](https://github.com/aimenux/ValueObjectsBenchDemo/actions/workflows/ci.yml/badge.svg)](https://github.com/aimenux/ValueObjectsBenchDemo/actions/workflows/ci.yml)

# ValueObjectsBenchDemo
```
Benchmarking various ways of creating value objects
```

> *Value objects are one of the building blocks introduced in [DDD](https://en.wikipedia.org/wiki/Domain-driven_design). Value objects are immutable. They have no identity like we found in entity. Two value objects can be considered equal if both of them have the same type and the same attributes (fields / properties).*

In this demo, i m using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) library in order to benchmark various ways of creating value objects :
>
> :one: Using an [implementation proposed by Jimmy Bogard](http://grabbagoft.blogspot.com/2007/06/generic-value-object-equality.html)
>
> :two: Using an [implementation proposed by Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects#value-object-implementation-in-c)
>
> :three: Using another implementation proposed by Microsoft Docs
>
> :four: Using an adhoc implementation based on IEquatable interface
>
> :five: Using an implementation based on records
>



In order to run benchmarks, type these commands in your favorite terminal :
>
> :writing_hand: `.\App.exe --filter DateValueObjectsBench`
>
> :writing_hand: `.\App.exe --filter AddressValueObjectsBench`
>

```
|              Method | Length |       Mean |     Error |    StdDev |     Median |        Min |        Max | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------- |------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|-----:|-------:|------:|------:|----------:|
| EqualsMethodForWayD |   1000 |   8.778 ns | 0.1936 ns | 0.1811 ns |   8.730 ns |   8.517 ns |   9.166 ns |    1 |      - |     - |     - |         - |
| EqualsMethodForWayE |   1000 |  19.877 ns | 0.4177 ns | 0.4102 ns |  19.864 ns |  19.273 ns |  20.623 ns |    2 |      - |     - |     - |         - |
| EqualsMethodForWayC |   1000 | 110.109 ns | 1.9097 ns | 1.6929 ns | 109.881 ns | 107.864 ns | 114.281 ns |    3 | 0.0191 |     - |     - |      80 B |
| EqualsMethodForWayB |   1000 | 114.465 ns | 2.2894 ns | 3.2835 ns | 113.917 ns | 109.650 ns | 122.895 ns |    4 | 0.0191 |     - |     - |      80 B |
| EqualsMethodForWayA |   1000 | 302.717 ns | 6.0271 ns | 5.6378 ns | 302.365 ns | 294.047 ns | 316.349 ns |    5 | 0.0191 |     - |     - |      80 B |
|                     |        |            |           |           |            |            |            |      |        |       |       |           |
| EqualsMethodForWayD |  10000 |   8.709 ns | 0.1748 ns | 0.1635 ns |   8.730 ns |   8.450 ns |   9.025 ns |    1 |      - |     - |     - |         - |
| EqualsMethodForWayE |  10000 |  18.703 ns | 0.2971 ns | 0.2779 ns |  18.740 ns |  18.275 ns |  19.108 ns |    2 |      - |     - |     - |         - |
| EqualsMethodForWayC |  10000 | 109.554 ns | 2.2236 ns | 2.5607 ns | 109.810 ns | 105.564 ns | 115.236 ns |    3 | 0.0191 |     - |     - |      80 B |
| EqualsMethodForWayB |  10000 | 120.547 ns | 1.9521 ns | 1.8260 ns | 119.944 ns | 118.172 ns | 124.191 ns |    4 | 0.0191 |     - |     - |      80 B |
| EqualsMethodForWayA |  10000 | 302.636 ns | 6.0935 ns | 6.7729 ns | 301.768 ns | 290.772 ns | 314.163 ns |    5 | 0.0191 |     - |     - |      80 B |
|                     |        |            |           |           |            |            |            |      |        |       |       |           |
| EqualsMethodForWayD | 100000 |   8.979 ns | 0.1866 ns | 0.3727 ns |   8.826 ns |   8.513 ns |   9.807 ns |    1 |      - |     - |     - |         - |
| EqualsMethodForWayE | 100000 |  19.401 ns | 0.3954 ns | 0.4553 ns |  19.433 ns |  18.627 ns |  20.156 ns |    2 |      - |     - |     - |         - |
| EqualsMethodForWayC | 100000 | 109.872 ns | 2.1334 ns | 2.6200 ns | 109.679 ns | 105.666 ns | 115.077 ns |    3 | 0.0191 |     - |     - |      80 B |
| EqualsMethodForWayB | 100000 | 112.487 ns | 1.8952 ns | 1.6800 ns | 112.333 ns | 110.234 ns | 115.281 ns |    4 | 0.0191 |     - |     - |      80 B |
| EqualsMethodForWayA | 100000 | 310.033 ns | 6.0567 ns | 8.8778 ns | 308.713 ns | 300.472 ns | 342.655 ns |    5 | 0.0191 |     - |     - |      80 B |
```

**`Tools`** : vs19, net 5.0