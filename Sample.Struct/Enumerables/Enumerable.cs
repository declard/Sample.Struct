using System.Collections;
using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public readonly ref struct Enumerable<T, TEnumerator, TEnumerable> 
        where TEnumerator : IEnumerator<T> 
        where TEnumerable : IEnumerable<T, TEnumerator>
    {        
        Enumerable(TEnumerable value) => Value = value;

        public TEnumerable Value { get; }

        public TEnumerator GetEnumerator() => Value.GetEnumerator();

        public static implicit operator Enumerable<T, TEnumerator, TEnumerable>(TEnumerable value) => new Enumerable<T, TEnumerator, TEnumerable>(value);
        public static implicit operator TEnumerable(Enumerable<T, TEnumerator, TEnumerable> value) => value.Value;
    }

    public readonly struct Enumerable<T> : IEnumerable<T, IEnumerator<T>>
    {
        internal Enumerable(IEnumerable<T> unwrap) => Value = unwrap;

        public IEnumerable<T> Value { get; }

        public IEnumerator<T> GetEnumerator() => Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}