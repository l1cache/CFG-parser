using System;
using System.Collections.Generic;

namespace CFGParser
{
    public class Succeed<T> : IParser<T>
    {
        private readonly T _o;

        public Succeed(T o)
        {
            _o = o;
        }

        public List<Tuple<string, T>> Parse(string s)
        {
            return new List<Tuple<string, T>>
                {
                    new Tuple<string, T>(s, _o)
                };
        }
    }
}