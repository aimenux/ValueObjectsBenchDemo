using App.Helpers;
using BenchmarkDotNet.Attributes;
using AddressValueObjectWayA = Lib.ValueObjects.WayA.Address;
using AddressValueObjectWayB = Lib.ValueObjects.WayB.Address;
using AddressValueObjectWayC = Lib.ValueObjects.WayC.Address;
using AddressValueObjectWayD = Lib.ValueObjects.WayD.Address;
using AddressValueObjectWayE = Lib.ValueObjects.WayE.Address;

namespace App.Benchmarks
{
    [Config(typeof(BenchConfig))]
    [BenchmarkCategory(nameof(BenchCategory.AddressValueObjects))]
    public class AddressValueObjectsBench
    {
        private (AddressValueObjectWayA first, AddressValueObjectWayA second) _objA;
        private (AddressValueObjectWayB first, AddressValueObjectWayB second) _objB;
        private (AddressValueObjectWayC first, AddressValueObjectWayC second) _objC;
        private (AddressValueObjectWayD first, AddressValueObjectWayD second) _objD;
        private (AddressValueObjectWayE first, AddressValueObjectWayE second) _objE;

        [Params(1000, 10000, 100000)]
        public int Length { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var street = RandomHelper.RandomString(10);
            var city = RandomHelper.RandomString(10);
            var country = RandomHelper.RandomString(10);
            _objA = (new AddressValueObjectWayA(street, city, country), new AddressValueObjectWayA(street, city, country));
            _objB = (new AddressValueObjectWayB(street, city, country), new AddressValueObjectWayB(street, city, country));
            _objC = (new AddressValueObjectWayC(street, city, country), new AddressValueObjectWayC(street, city, country));
            _objD = (new AddressValueObjectWayD(street, city, country), new AddressValueObjectWayD(street, city, country));
            _objE = (new AddressValueObjectWayE(street, city, country), new AddressValueObjectWayE(street, city, country));
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
