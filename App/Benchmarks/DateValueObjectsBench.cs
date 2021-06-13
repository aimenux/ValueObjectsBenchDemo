using App.Helpers;
using BenchmarkDotNet.Attributes;
using DateValueObjectWayA = Lib.ValueObjects.WayA.Date;
using DateValueObjectWayB = Lib.ValueObjects.WayB.Date;
using DateValueObjectWayC = Lib.ValueObjects.WayC.Date;
using DateValueObjectWayD = Lib.ValueObjects.WayD.Date;
using DateValueObjectWayE = Lib.ValueObjects.WayE.Date;

namespace App.Benchmarks
{
    [Config(typeof(BenchConfig))]
    [BenchmarkCategory(nameof(BenchCategory.DateValueObjects))]
    public class DateValueObjectsBench
    {
        private (DateValueObjectWayA first, DateValueObjectWayA second) _objA;
        private (DateValueObjectWayB first, DateValueObjectWayB second) _objB;
        private (DateValueObjectWayC first, DateValueObjectWayC second) _objC;
        private (DateValueObjectWayD first, DateValueObjectWayD second) _objD;
        private (DateValueObjectWayE first, DateValueObjectWayE second) _objE;

        [Params(1000, 10000, 100000)]
        public int Length { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var value = RandomHelper.RandomDate();
            _objA = (new DateValueObjectWayA(value), new DateValueObjectWayA(value));
            _objB = (new DateValueObjectWayB(value), new DateValueObjectWayB(value));
            _objC = (new DateValueObjectWayC(value), new DateValueObjectWayC(value));
            _objD = (new DateValueObjectWayD(value), new DateValueObjectWayD(value));
            _objE = (new DateValueObjectWayE(value), new DateValueObjectWayE(value));
        }

        [Benchmark]
        public bool EqualsMethodForWayA()
        {
            return _objA.first.Equals(_objA.second);
        }

        [Benchmark]
        public bool EqualsMethodForWayB()
        {
            return _objB.first.Equals(_objB.second);
        }

        [Benchmark]
        public bool EqualsMethodForWayC()
        {
            return _objC.first.Equals(_objC.second);
        }

        [Benchmark]
        public bool EqualsMethodForWayD()
        {
            return _objD.first.Equals(_objD.second);
        }

        [Benchmark]
        public bool EqualsMethodForWayE()
        {
            return _objE.first.Equals(_objE.second);
        }
    }
}
