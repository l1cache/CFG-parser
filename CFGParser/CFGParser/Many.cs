using System;
using System.Collections.Generic;
using System.Linq;

namespace CFGParser
{
    public class Many<T> : IParser<T[]>
    {
        private readonly IParser<T> _parser;

        public Many(IParser<T> parser)
        {
            _parser = parser;
        }

        public List<Tuple<string, T[]>> Parse(string s)
        {
            return new Parallel<T[]>(
                new Change<Tuple<T, T[]>, T[]>(new Successively<T, T[]>(_parser, new Many<T>(_parser)),
                                                     tuple => new[] {tuple.Item1}.Union(tuple.Item2).ToArray()),
                new Succeed<T[]>(new T[0])
                ).Parse(s);
        }
    }
}