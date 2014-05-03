using System;
using System.Collections.Generic;
using System.Linq;

namespace CFGParser
{
    public class Change<T1,T2> : IParser<T2>
    {
        private readonly IParser<T1> _parser;
        private readonly Func<T1, T2> _f;

        public Change(IParser<T1> parser, Func<T1,T2> f)
        {
            _parser = parser;
            _f = f;
        }

        public List<Tuple<string, T2>> Parse(string s)
        {
            return _parser.Parse(s).Select(tuple => new Tuple<string, T2>(tuple.Item1, _f(tuple.Item2))).ToList();
        }
    }
}