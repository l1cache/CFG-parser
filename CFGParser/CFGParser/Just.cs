using System;
using System.Collections.Generic;
using System.Linq;

namespace CFGParser
{
    public class Just<T> : IParser<T>
    {
        private readonly IParser<T> _parser;

        public Just(IParser<T> parser)
        {
            _parser = parser;
        }

        public List<Tuple<string, T>> Parse(string s)
        {
            var tuples = _parser.Parse(s);
            return tuples.Where(tuple => tuple.Item1 == "").ToList();
        }
    }
}