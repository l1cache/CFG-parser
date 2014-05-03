using System;
using System.Collections.Generic;

namespace CFGParser
{
    public class SkipSpaces<T> : IParser<T>
    {
        private readonly IParser<T> _parser;

        public SkipSpaces(IParser<T> parser)
        {
            _parser = parser;
        }

        public List<Tuple<string, T>> Parse(string s)
        {
            return _parser.Parse(s.TrimStart(' '));
        }
    }
}