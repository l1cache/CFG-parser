using System;
using System.Collections.Generic;
using System.Linq;

namespace CFGParser
{
    public class Parallel<T> : IParser<T>
    {
        private readonly IParser<T>[] _parsers;

        public Parallel(params IParser<T>[] parsers)
        {
            _parsers = parsers;
        }

        public List<Tuple<string, T>> Parse(string s)
        {
            return _parsers.SelectMany(parser => parser.Parse(s)).ToList();
        }
    }
}