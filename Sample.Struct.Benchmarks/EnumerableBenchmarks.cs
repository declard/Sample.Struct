﻿using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Sample.Struct.Enumerables;
using Sample.Struct.Indexables;
using Sample.Struct.Summators;

namespace Sample.Struct.Benchmarks
{
    [MemoryDiagnoser]
    [Config(typeof(Runtimes))]
    public class EnumerableBenchmarks
    {
        [Benchmark(Baseline = true)]
        public void SumArrayBenchmark() => _array.Sum();

        [Benchmark]
        public void SpecialSumArrayBenchmark()
        {
            var sum = 0;
            foreach (var n in _array)
                sum += n;
        }
       
        [Benchmark]
        public void SpecialSumListBenchmark()
        {
            var sum = 0;
            foreach (var n in _list)
                sum += n;
        }        

        [Benchmark]
        public void SpecialForSumListBenchmark()
        {
            var sum = 0;
            for (var i = 0; i < _list.Count; i++)
                sum += _list[i];
        }

        [Benchmark]
        public void IndexableSumArrayBenchmark() => _array.AsIndexable().Sum(0.AsAdditive());

        [Benchmark]
        public void StructSumArrayBenchmark() => _array.AsStructEnumerable().Sum();

        [Benchmark]
        public void StructGenericSumArrayBenchmark() => _array.AsStructEnumerable().Sum(0.AsAdditive());

        [Benchmark]
        public void IndexableSumListBenchmark() => _list.AsIndexable().Sum(0.AsAdditive());

        [Benchmark]
        public void StructSumListBenchmark() => _list.AsStructEnumerable().Sum();

        static int[] _array = Enumerable.Range(0, 1000).ToArray();
        static List<int> _list = _array.ToList();
    }
}