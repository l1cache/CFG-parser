using System;
using System.Collections.Generic;
using System.Linq;

namespace CFGParser
{
    public class Successively<T1, T2> : IParser<Tuple<T1, T2>>
    {
        private readonly IParser<T1> _parser1;
        private readonly IParser<T2> _parser2;

        public Successively(IParser<T1> parser1, IParser<T2> parser2 )
        {
            _parser1 = parser1;
            _parser2 = parser2;
        }

        public List<Tuple<string, Tuple<T1, T2>>> Parse(string s)
        {
            return (from tuple in _parser1.Parse(s)
                    let tuples2 = _parser2.Parse(tuple.Item1)
                    from tuple1 in tuples2
                    select new Tuple<string, Tuple<T1, T2>>(tuple1.Item1, new Tuple<T1, T2>(tuple.Item2, tuple1.Item2))).ToList();
        }
    }
}